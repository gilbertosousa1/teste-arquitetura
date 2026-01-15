using Consolidado.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Consolidado.Domain.Entities.ConsolidadoDB
{
    public class SaldoDiario
    {
        [Key]
        public DateTime DataLancamento { get; private set; }
        public decimal TotalCreditos { get; private set; }
        public decimal TotalDebitos { get; private set; }
        public decimal SaldoFinal { get; private set; }
        public DateTime DataAlteracao { get; private set; }

    }
}
