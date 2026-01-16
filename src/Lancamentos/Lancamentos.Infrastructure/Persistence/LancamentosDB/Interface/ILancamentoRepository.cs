using Lancamentos.Domain.Entities.LancamentosDB;

namespace Lancamentos.Infrastructure.Persistence.LancamentosDB.Interface
{
    public interface ILancamentoRepository
    {
        Task<Lancamento> AddAsync(Lancamento lancamento);
    }
}
