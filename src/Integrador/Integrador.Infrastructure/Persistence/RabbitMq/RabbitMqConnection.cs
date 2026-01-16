using Integrador.Infrastructure.Persistence.RabbitMq.Interface;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Integrador.Infrastructure.Persistence.RabbitMq
{
    public class RabbitMqConnection : IRabbitMqConnection, IAsyncDisposable
    {
        private readonly RabbitMqOptions _options;
        private IConnection? _connection;
        private readonly SemaphoreSlim _lock = new(1, 1);

        public RabbitMqConnection(IOptions<RabbitMqOptions> options)
        {
            _options = options.Value;
        }

        public async Task<IConnection> GetConnectionAsync()
        {
            if (_connection != null && _connection.IsOpen)
                return _connection;

            await _lock.WaitAsync();
            try
            {
                if (_connection != null && _connection.IsOpen)
                    return _connection;

                var factory = new ConnectionFactory
                {
                    HostName = _options.Host,
                    Port = _options.Port,
                    UserName = _options.User,
                    Password = _options.Password,
                    VirtualHost = _options.VirtualHost
                };

                _connection = await factory.CreateConnectionAsync();
                return _connection;
            }
            finally
            {
                _lock.Release();
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_connection != null)
                await _connection.CloseAsync();
        }
    }
}
