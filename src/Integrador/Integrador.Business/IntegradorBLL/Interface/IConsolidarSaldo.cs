using Integrador.Domain.Entities.DTO;
using RabbitMQ.Client.Events;

namespace Integrador.Business.IntegradorBLL.Interface
{
    public interface IConsolidarSaldo
    {
        Task<SaldoDiarioData> Integrar(BasicDeliverEventArgs ea);
    }
}
