using Consolidado.Domain.Entities.ConsolidadoDB;
using Consolidado.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidado.Infrastructure.Persistence.ConsolidadoDB.Interface
{
    public interface IConsolidadoRepository
    {
        List<SaldoDiario> GetSaldo(DateTime dataLancamento);
    }
}
