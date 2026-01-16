using Consolidado.Domain.Entities.ConsolidadoDB;
using Consolidado.Util.Entities;

namespace Consolidado.Domain.Entities.DTO
{
    public class SaldoDiarioResult
    {
        public List<SaldoDiarioData> Data { get; set; }
        public StatusResponse Status { get; set; }

        public SaldoDiarioResult()
        {
            Data = new List<SaldoDiarioData>();
            Status = new StatusResponse();
        }

        public SaldoDiarioResult(List<SaldoDiario> saldoDiario)
        {
            Data = saldoDiario.Select(sd => new SaldoDiarioData(sd)).ToList();
            Status = new StatusResponse();
        }

    }
}
