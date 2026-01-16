using Integrador.Domain.Entities.ConsolidadoDB;
using Integrador.Domain.Entities.RabitMq.Evests;
using Integrador.Infrastructure.Persistence.ConsolidadoDB;
using Integrador.Infrastructure.Persistence.RabbitMq;
using Integrador.Infrastructure.Persistence.RabbitMq.Interface;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;


namespace Integrador.Worker
{
    public class SaldoConsolidadoConsumer : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IRabbitMqConnection _connection;
        private readonly RabbitMqOptions _options;
        private readonly ILogger<SaldoConsolidadoConsumer> _logger;

        private IChannel _channel;

        public SaldoConsolidadoConsumer(
            IServiceScopeFactory scopeFactory,
            IRabbitMqConnection connection,
            IOptions<RabbitMqOptions> options,
            ILogger<SaldoConsolidadoConsumer> logger)
        {
            _scopeFactory = scopeFactory;
            _connection = connection;
            _options = options.Value;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var conn = await _connection.GetConnectionAsync();
            _channel = await conn.CreateChannelAsync();

            await _channel.QueueBindAsync(
            queue: "lancamentos.queue",
            exchange: "lancamentos.exchange",
            routingKey: "lancamento.criado",
            cancellationToken: stoppingToken);

            await _channel.BasicQosAsync(0, 1, false);

            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.ReceivedAsync += ProcessMessageAsync;

            await _channel.BasicConsumeAsync(
                queue: _options.Queue,
                autoAck: false,
                consumer: consumer);

            _logger.LogInformation("🟢 Worker iniciado. Escutando fila {Queue}", _options.Queue);

            await Task.Delay(Timeout.Infinite, stoppingToken);
        }

        private async Task ProcessMessageAsync(object sender, BasicDeliverEventArgs ea)
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<Context>();

            try
            {
                var body = ea.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);

                var lancamento = JsonSerializer.Deserialize<Lancamento>(json);

                if (lancamento == null)
                    throw new Exception("Mensagem inválida");

                var data = lancamento.DataLancamento.Date;

                var saldo = context.SaldosDiario
                    .FirstOrDefault(x => x.DataLancamento == data);

                if (saldo == null)
                {
                    saldo = new SaldoDiario(lancamento);
                    context.SaldosDiario.Add(saldo);
                }
                else
                {
                    saldo.Atualizar(lancamento);                       
                }

                context.SaveChanges();

                await _channel.BasicAckAsync(ea.DeliveryTag, false);

                _logger.LogInformation(
                    "✔ Consolidado atualizado | Data: {Data} | Valor: {Valor} | Tipo: {Tipo}",
                    data, lancamento.Valor, lancamento.Tipo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Erro ao processar mensagem");
                await _channel.BasicNackAsync(ea.DeliveryTag, false, true);
            }
        }

        public override async Task<Task?> StopAsync(CancellationToken cancellationToken)
        {
           await _channel?.CloseAsync();
            var x = base.StopAsync(cancellationToken);

            return x;
        }
    }
}
