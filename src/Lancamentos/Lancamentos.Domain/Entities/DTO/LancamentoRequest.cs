using Lancamentos.Domain.Entities.LancamentosDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lancamentos.Domain.Entities.DTO
{
    public class LancamentoRequest
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public TipoLancamento Tipo { get; set; }
        public DateTime DataLancamento { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
