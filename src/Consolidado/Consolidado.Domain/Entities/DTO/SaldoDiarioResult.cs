using Consolidado.Domain.Entities.ConsolidadoDB;
using Consolidado.Util.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
