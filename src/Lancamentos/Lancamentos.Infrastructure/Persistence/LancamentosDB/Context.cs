using Lancamentos.Domain.Entities.LancamentosDB;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;


namespace Lancamentos.Infrastructure.Persistence.LancamentosDB
{

    public class Context : DbContext
    {
        public DbSet<Lancamento> Lancamentos { get; set; }


        public Context(DbContextOptions<Context> options) : base(options) { }

    }
}