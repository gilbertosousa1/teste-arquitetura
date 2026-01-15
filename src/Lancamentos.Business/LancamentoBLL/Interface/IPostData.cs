using Lancamentos.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lancamentos.Business.LancamentoBLL.Interface
{
    public interface IPostData
    {
        Task<LancamentoResult> Salvar(LancamentoRequest request);
    }
}
