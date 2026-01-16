using Integrador.Business.IntegradorBLL;
using Integrador.Infrastructure.Persistence.ConsolidadoDB;
using Integrador.Infrastructure.Persistence.RabbitMq;
using Integrador.Infrastructure.Persistence.RabbitMq.Interface;
using Integrador.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

await Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        // 🔹 Configuração RabbitMQ
        services.Configure<RabbitMqOptions>(context.Configuration.GetSection("RabbitMQ"));

        services.AddSingleton<IRabbitMqConnection, RabbitMqConnection>();

        // 🔹 Configuração Banco Consolidado
        services.AddDbContext<Context>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("ConsolidadoDB"))
            );

        // 🔹 Consumer como serviço hospedado
        services.AddHostedService<SaldoConsolidadoConsumer>();
    })
    .Build()
    .RunAsync();