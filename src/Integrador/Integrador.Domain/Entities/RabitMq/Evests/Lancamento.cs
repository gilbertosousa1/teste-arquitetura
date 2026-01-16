using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Domain.Entities.RabitMq.Evests
{
    public class Lancamento
    {
        //{
        //  "Id":"51720d62-d757-4e04-98b2-a353354efbc0",
        //  "Valor":100,
        //  "Tipo":1,
        //  "DataLancamento":"2026-01-16T03:23:20.035Z",
        //  "DataCriacao":"2026-01-16T03:23:20.035Z"
        //  }
        public string Id { get; set; }
        public decimal Valor { get; set; }
        public int Tipo { get; set; }
        public DateTime DataLancamento { get; set; }
        public DateTime DataCriacao { get; set; }
    }

    public enum TipoLancamento
    {
        Credito = 1,
        Debito = 2
    }
}
