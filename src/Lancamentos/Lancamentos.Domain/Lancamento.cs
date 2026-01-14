using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lancamentos.Domain
{
    public class Lancamento
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime Data { get; private set; }
        public decimal Valor { get; private set; }
        public TipoLancamento Tipo { get; private set; }

        protected Lancamento() { }

        public Lancamento(DateTime data, decimal valor, TipoLancamento tipo)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor deve ser maior que zero");

            Data = data;
            Valor = valor;
            Tipo = tipo;
        }
    }

    public enum TipoLancamento
    {
        Credito = 1,
        Debito = 2
    }
}
