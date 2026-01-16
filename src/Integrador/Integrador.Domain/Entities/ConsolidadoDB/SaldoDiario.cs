using Integrador.Domain.Entities.RabitMq.Evests;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integrador.Domain.Entities.ConsolidadoDB
{
    [Table("SaldoDiario")]
    public class SaldoDiario
    {
        [Key]
        [Column("DataLancamento")]
        public DateTime DataLancamento { get; private set; }

        [Column("TotalCreditos")]
        public decimal TotalCreditos { get; private set; }

        [Column("TotalDebitos")]
        public decimal TotalDebitos { get; private set; }

        [Column("DataAlteracao")]
        public DateTime DataAlteracao { get; private set; }

        public void Atualizar(Lancamento lancamento)
        {
            TotalCreditos += lancamento.Tipo == (int)TipoLancamento.Credito ? lancamento.Valor : 0;
            TotalDebitos += lancamento.Tipo == (int)TipoLancamento.Debito ? lancamento.Valor : 0;
            DataAlteracao = DateTime.UtcNow;
        }
        protected SaldoDiario() { }

        public SaldoDiario(Lancamento lancamento)
        {
            DataLancamento = lancamento.DataLancamento.Date;
            TotalCreditos = lancamento.Tipo == (int)TipoLancamento.Credito ? lancamento.Valor : 0;
            TotalDebitos = lancamento.Tipo == (int)TipoLancamento.Debito ? lancamento.Valor : 0;
            DataAlteracao = DateTime.UtcNow;
        }

    }
}
