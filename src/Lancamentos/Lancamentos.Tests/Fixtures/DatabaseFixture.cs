using LancamentosDbContext = Lancamentos.Infrastructure.Persistence.LancamentosDB.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Lancamentos.Tests.Fixtures
{
    public class DatabaseFixture : IAsyncLifetime
    {
        public DbContextOptions<LancamentosDbContext>? Options { get; private set; }

        //public Task InitializeAsync()
        //{
        //    var configuration = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.Test.json", optional: false)
        //        .Build();

        //    var connectionString = configuration.GetConnectionString("lancamentosDB");

        //    if (string.IsNullOrWhiteSpace(connectionString))
        //        throw new InvalidOperationException("Connection string 'lancamentosDB' não encontrada.");

        //    Options = new DbContextOptionsBuilder<LancamentosDbContext>()
        //        .UseSqlServer(connectionString)
        //        .Options;

        //    using var context = new LancamentosDbContext(Options);
        //    context.Database.EnsureCreated();

        //    return Task.CompletedTask;
        //}

        //public Task DisposeAsync()
        //{
        //    using var context = new LancamentosDbContext(Options);
        //    context.Database.EnsureDeleted();
        //    return Task.CompletedTask;
        //}
    }
}
