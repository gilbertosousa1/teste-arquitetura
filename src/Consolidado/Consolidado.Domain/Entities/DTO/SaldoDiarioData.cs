using Consolidado.Domain.Entities.ConsolidadoDB;

namespace Consolidado.Domain.Entities.DTO
{
    public class SaldoDiarioData
    {
        public DateTime DataLancamento { get; private set; }
        public decimal TotalCreditos { get; private set; }
        public decimal TotalDebitos { get; private set; }
        public decimal SaldoFinal { get; private set; }

        public SaldoDiarioData(SaldoDiario saldoDiario)
        {
            DataLancamento = saldoDiario.DataLancamento;
            TotalCreditos = saldoDiario.TotalCreditos;
            TotalDebitos = saldoDiario.TotalDebitos;
            SaldoFinal = saldoDiario.SaldoFinal;
        }
    }
}
