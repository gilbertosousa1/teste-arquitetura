using Integrador.Domain.Entities.ConsolidadoDB;
using Microsoft.EntityFrameworkCore;


namespace Integrador.Infrastructure.Persistence.ConsolidadoDB
{

    public class Context : DbContext
    {
        public DbSet<SaldoDiario> SaldosDiario { get; set; }


        public Context(DbContextOptions<Context> options) : base(options) { }

    }
}