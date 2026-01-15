using Lancamentos.Domain;
using Lancamentos.Domain.Entities.DTO;
using Lancamentos.Domain.Entities.LancamentosDB;
using Lancamentos.Infrastructure.Persistence.LancamentosDB;
using Lancamentos.Infrastructure.Persistence.LancamentosDB.Interface;
using Lancamentos.Util.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lancamentos.Business.LancamentoBLL
{
    public class PostData : Interface.IPostData
    {
        private readonly ILancamentoRepository _repository;

        public PostData(ILancamentoRepository repository)
        {
            _repository = repository;
        }


        public async Task<LancamentoResult> Salvar(LancamentoRequest request)
        {
            var ret = ValidateRequest(request);

            if (!ret.Status.Valid)
            {
                return ret;
            }

            // Use _lancamentoRepository to save the lancamento
            var lancamento = new Lancamento(request);

            lancamento = await _repository.AddAsync(lancamento);

            return ret;
        }

        private LancamentoResult ValidateRequest(LancamentoRequest request)
        {
            var result = new LancamentoResult();
            var lstErrors = new List<ErrorMessage>();

            if (request == null)
            {
                result.Status.Valid = false;
                lstErrors.Add(new ErrorMessage(400, "Requisição inválida."));
            }
            else
            {
                if (request.Valor <= 0)
                {
                    lstErrors.Add(new ErrorMessage(401, "O valor do lançamento deve ser maior que zero."));
                }
            }

            result.Status = new StatusResponse(!lstErrors.Any(), lstErrors);
            return result;
        }
    }
}
