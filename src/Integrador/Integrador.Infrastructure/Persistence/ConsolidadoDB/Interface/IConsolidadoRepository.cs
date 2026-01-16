using Integrador.Domain.Entities.ConsolidadoDB;

namespace Integrador.Infrastructure.Persistence.ConsolidadoDB.Interface
{
    public interface IConsolidadoRepository
    {
        List<SaldoDiario> GetSaldo(DateTime dataLancamento);
    }
}
