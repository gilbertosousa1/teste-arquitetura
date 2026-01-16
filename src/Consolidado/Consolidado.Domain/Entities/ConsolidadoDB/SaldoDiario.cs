using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consolidado.Domain.Entities.ConsolidadoDB
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

        [Column("SaldoFinal")]
        public decimal SaldoFinal { get; private set; }

        [Column("DataAlteracao")]
        public DateTime DataAlteracao { get; private set; }

    }
}
