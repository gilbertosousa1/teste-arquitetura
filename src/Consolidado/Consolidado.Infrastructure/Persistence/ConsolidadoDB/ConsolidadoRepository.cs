using Consolidado.Domain.Entities.ConsolidadoDB;
using Microsoft.EntityFrameworkCore;
using ConsolidadoDBContext = Consolidado.Infrastructure.Persistence.ConsolidadoDB.Context;

namespace Consolidado.Infrastructure.Persistence.ConsolidadoDB
{

    public class ConsolidadoRepository : Interface.IConsolidadoRepository
    {
        private readonly ConsolidadoDBContext _context;

        public ConsolidadoRepository(ConsolidadoDBContext context)
        {
            _context = context;
            Console.WriteLine(context.Database.GetConnectionString() ?? "CONNECTION STRING NULL");
        }

        public List<SaldoDiario> GetSaldo(DateTime dataLancamento)
        {
            return _context.SaldosDiario.AsNoTracking().Where(s => s.DataLancamento == dataLancamento).ToList();
        }
    }
}
