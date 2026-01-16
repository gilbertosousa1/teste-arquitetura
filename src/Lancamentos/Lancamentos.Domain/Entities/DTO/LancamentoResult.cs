using Lancamentos.Util.Entities;

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
