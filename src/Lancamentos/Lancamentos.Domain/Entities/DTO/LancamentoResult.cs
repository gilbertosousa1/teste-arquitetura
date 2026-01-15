using Lancamentos.Util.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lancamentos.Domain.Entities.DTO
{
    public class LancamentoResult
    {
        public StatusResponse Status { get; set; }

        public LancamentoResult()
        {
            Status = new StatusResponse();
        }
      
    }
}
