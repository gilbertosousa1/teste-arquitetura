using Consolidado.Domain.Entities.DTO;

namespace Consolidado.Business.LancamentoBLL.Interface
{
    public interface IGetData
    {
        SaldoDiarioResult CarregarSaldo(string dataLancamento);
    }
}
