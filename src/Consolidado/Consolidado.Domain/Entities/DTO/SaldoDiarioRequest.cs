using Consolidado.Domain.Entities.ConsolidadoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Consolidado.Domain.Entities.DTO
{
    public class SaldoDiarioRequest
    {
        public string DataLancamento { get; set; }
    }
}
