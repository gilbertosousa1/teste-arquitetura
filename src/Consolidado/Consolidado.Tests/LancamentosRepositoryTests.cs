using Lancamentos.Domain.Entities;
using Lancamentos.Infrastructure.Persistence.LancamentosDB;
using Lancamentos.Tests.Fixtures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LancamentosDbContext = Lancamentos.Infrastructure.Persistence.LancamentosDB.Context;

namespace Lancamentos.Tests
{
    public class LancamentosRepositoryTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;

        public LancamentosRepositoryTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        //[Fact]
        //public async Task Deve_salvar_lancamento_no_banco()
        //{
        //    using var context = new LancamentosDbContext(_fixture.Options);
        //    var repo = new LancamentoRepository(context);

        //    var lancamento = new Lancamento(DateTime.Now, 100m, TipoLancamento.Credito, DateTime.Now);

        //    await repo.AddAsync(lancamento);

        //    var salvo = await context.Lancamentos.FirstOrDefaultAsync();

        //    Assert.NotNull(salvo);
        //    Assert.Equal(100m, salvo.Valor);
        //}
    }
}
