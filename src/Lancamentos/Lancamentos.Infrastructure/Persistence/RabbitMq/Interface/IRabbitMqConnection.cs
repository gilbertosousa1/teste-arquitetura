using RabbitMQ.Client;

namespace Lancamentos.Infrastructure.Persistence.RabbitMq.Interface
{
    public interface IRabbitMqConnection
    {
        Task<IConnection> GetConnectionAsync();
    }
}
