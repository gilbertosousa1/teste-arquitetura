using Consolidado.Domain.Entities.ConsolidadoDB;

namespace Consolidado.Infrastructure.Persistence.ConsolidadoDB.Interface
{
    public interface IConsolidadoRepository
    {
        List<SaldoDiario> GetSaldo(DateTime dataLancamento);
    }
}
