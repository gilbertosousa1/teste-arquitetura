using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lancamentos.Infrastructure.Persistence.RabbitMq.Interface
{
    public interface IRabbitMqPublisher
    {
        Task PublishAsync<T>(string exchange, string routingKey, T message);
    }
}
