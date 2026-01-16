using Lancamentos.Domain.Entities.LancamentosDB;

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
