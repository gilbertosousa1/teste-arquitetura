using RabbitMQ.Client;

namespace Integrador.Infrastructure.Persistence.RabbitMq.Interface
{
    public interface IRabbitMqConnection
    {
        Task<IConnection> GetConnectionAsync();
    }
}
