using Lancamentos.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lancamentos.Domain.Entities.LancamentosDB
{
    public class Lancamento
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public decimal Valor { get; private set; }
        public TipoLancamento Tipo { get; private set; }
        public DateTime DataLancamento { get; private set; }
        public DateTime DataCriacao { get; private set; }

        protected Lancamento() { }

        public Lancamento(LancamentoRequest request)
        {
            DataLancamento = request.DataLancamento;
            Valor = request.Valor;
            Tipo = request.Tipo;
            DataCriacao = request.DataCriacao;

        }

        public Lancamento(DateTime data, decimal valor, TipoLancamento tipo, DateTime dataCriacao)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor deve ser maior que zero");

            DataLancamento = data;
            Valor = valor;
            Tipo = tipo;
            DataCriacao = dataCriacao;
        }
    }

    public enum TipoLancamento
    {
        Credito = 1,
        Debito = 2
    }
}
