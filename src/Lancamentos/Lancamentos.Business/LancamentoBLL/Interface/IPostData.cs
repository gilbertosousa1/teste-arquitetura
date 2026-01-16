using Lancamentos.Domain.Entities.DTO;

namespace Lancamentos.Business.LancamentoBLL.Interface
{
    public interface IPostData
    {
        Task<LancamentoResult> Salvar(LancamentoRequest request);
    }
}
