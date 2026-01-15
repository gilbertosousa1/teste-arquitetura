using Lancamentos.Domain.Entities.LancamentosDB;
using Microsoft.EntityFrameworkCore;
using LancamentosDbContext = Lancamentos.Infrastructure.Persistence.LancamentosDB.Context;

namespace Lancamentos.Infrastructure.Persistence.LancamentosDB
{

    public class LancamentoRepository : Interface.ILancamentoRepository
    {
        private readonly LancamentosDbContext _context;

        public LancamentoRepository(LancamentosDbContext context)
        {
            _context = context;
            Console.WriteLine(context.Database.GetConnectionString()?? "CONNECTION STRING NULL");
        }

        public async Task<Lancamento> AddAsync(Lancamento lancamento)
        {
            _context.Lancamentos.Add(lancamento);
            await _context.SaveChangesAsync();

            return lancamento;
        }
    }
}
