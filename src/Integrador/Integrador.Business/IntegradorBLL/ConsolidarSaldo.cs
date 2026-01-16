using Integrador.Infrastructure.Persistence.ConsolidadoDB.Interface;
using Integrador.Domain.Entities.DTO;
using Integrador.Infrastructure.Persistence.RabbitMq.Interface;
using Integrador.Util.Entities;
using RabbitMQ.Client.Events;

namespace Integrador.Business.IntegradorBLL
{
    public class ConsolidarSaldo : Interface.IConsolidarSaldo
    {
        private readonly IConsolidadoRepository _repository;
        private readonly IRabbitMqPublisher _publisher;

        public ConsolidarSaldo(IConsolidadoRepository repository, IRabbitMqPublisher publisher)
        {
            _repository = repository;
            _publisher = publisher;
        }


        public async Task<SaldoDiarioData> Integrar(BasicDeliverEventArgs ea)
        {
            SaldoDiarioData ret = new SaldoDiarioData();

            //if (!ret.Status.Valid)
            //{
            //    return ret;
            //}

            //// Use _lancamentoRepository to save the lancamento
            //var lancamento = new Lancamento(request);

            //// 1️ - Persiste no banco
            //lancamento = await _repository.AddAsync(lancamento);

            //// 2️ - Publica evento
            //await _publisher.PublishAsync(exchange: "Integrador.exchange", routingKey: "lancamento.criado", message: lancamento);

            return ret;
        }

        //private SaldoDiarioData ValidateRequest()
        //{
        //    var result = new LancamentoResult();
        //    var lstErrors = new List<ErrorMessage>();

        //    if (request == null)
        //    {
        //        result.Status.Valid = false;
        //        lstErrors.Add(new ErrorMessage(400, "Requisição inválida."));
        //    }
        //    else
        //    {
        //        if (request.Valor <= 0)
        //        {
        //            lstErrors.Add(new ErrorMessage(401, "O valor do lançamento deve ser maior que zero."));
        //        }
        //    }

        //    result.Status = new StatusResponse(!lstErrors.Any(), lstErrors);
        //    return result;
        //}
    }
}
