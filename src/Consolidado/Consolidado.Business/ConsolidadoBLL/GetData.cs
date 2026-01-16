using Consolidado.Domain.Entities.DTO;
using Consolidado.Infrastructure.Persistence.ConsolidadoDB.Interface;

using Consolidado.Util.Entities;

namespace Consolidado.Business.LancamentoBLL
{
    public class GetData : Interface.IGetData
    {
        private readonly IConsolidadoRepository _repository;

        public GetData(IConsolidadoRepository repository)
        {
            _repository = repository;
        }


        public SaldoDiarioResult CarregarSaldo(string dataLancamento)
        {
            var ret = ValidateRequest(dataLancamento);

            if (!ret.Status.Valid)
            {
                return ret;
            }

            // 1️ - Pesquisa no banco
            var dtLancamento = DateTime.Parse(dataLancamento);
            var data = _repository.GetSaldo(dtLancamento);

            ret.Data = data.Select(d => new SaldoDiarioData(d)).ToList();

            return ret;
        }

        private SaldoDiarioResult ValidateRequest(string dataLancamento)
        {
            var result = new SaldoDiarioResult();
            var lstErrors = new List<ErrorMessage>();

            if (string.IsNullOrEmpty(dataLancamento))
            {
                result.Status.Valid = false;
                lstErrors.Add(new ErrorMessage(400, "Requisição inválida."));
            }
            else if (!DateTime.TryParse(dataLancamento, out DateTime dataLancamentoTest))
            {
                result.Status.Valid = false;
                lstErrors.Add(new ErrorMessage(401, "DataLancamento inválida."));
            }


            result.Status = new StatusResponse(!lstErrors.Any(), lstErrors);
            return result;
        }
    }
}
