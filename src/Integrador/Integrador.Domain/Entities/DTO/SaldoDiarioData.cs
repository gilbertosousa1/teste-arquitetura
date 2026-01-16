using Integrador.Domain.Entities.ConsolidadoDB;

namespace Integrador.Domain.Entities.DTO
{
    public class SaldoDiarioData
    {
        public DateTime DataLancamento { get; private set; }
        public decimal TotalCreditos { get; private set; }
        public decimal TotalDebitos { get; private set; }
        public decimal SaldoFinal { get; private set; }

        public SaldoDiarioData() { }

        public SaldoDiarioData(SaldoDiario saldoDiario)
        {
            DataLancamento = saldoDiario.DataLancamento;
            TotalCreditos = saldoDiario.TotalCreditos;
            TotalDebitos = saldoDiario.TotalDebitos;
        }
    }
}
