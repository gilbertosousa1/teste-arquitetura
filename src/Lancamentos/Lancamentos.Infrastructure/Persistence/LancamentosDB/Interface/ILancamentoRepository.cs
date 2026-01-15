using Lancamentos.Domain.Entities.LancamentosDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lancamentos.Infrastructure.Persistence.LancamentosDB.Interface
{
    public interface ILancamentoRepository
    {
        Task<Lancamento> AddAsync(Lancamento lancamento);
    }
}
