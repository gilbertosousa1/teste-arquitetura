using Lancamentos.Infrastructure.Persistence.RabbitMq.Interface;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Lancamentos.Infrastructure.Persistence.RabbitMq
{
    public class RabbitMqPublisher : IRabbitMqPublisher
    {
        private readonly IRabbitMqConnection _connection;

        public RabbitMqPublisher(IRabbitMqConnection connection)
        {
            _connection = connection;
        }

        public async Task PublishAsync<T>(string exchange, string routingKey, T message)
        {
            var conn = await _connection.GetConnectionAsync();
            await using var channel = await conn.CreateChannelAsync();

            await channel.ExchangeDeclareAsync(
                exchange: exchange,
                type: ExchangeType.Direct,
                durable: true
            );

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            await channel.BasicPublishAsync(
                exchange: exchange,
                routingKey: routingKey,
                body: body
            );
        }
    }

}
