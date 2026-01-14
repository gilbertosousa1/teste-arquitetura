using Lancamentos.Domain;
using Xunit;

namespace Lancamentos.Tests
{
    public class LancamentoTests
    {
        [Fact]
        public void Deve_criar_lancamento_valido()
        {
            var lancamento = new Lancamento(DateTime.Today, 100, TipoLancamento.Credito);
            Assert.NotNull(lancamento);
        }

        [Fact]
        public void Nao_deve_criar_lancamento_com_valor_invalido()
        {
            Assert.Throws<ArgumentException>(() =>
                new Lancamento(DateTime.Today, 0, TipoLancamento.Debito));
        }
    }
}
