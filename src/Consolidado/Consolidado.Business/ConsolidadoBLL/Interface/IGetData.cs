using Consolidado.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidado.Business.LancamentoBLL.Interface
{
    public interface IGetData
    {
        SaldoDiarioResult CarregarSaldo(string dataLancamento);
    }
}
