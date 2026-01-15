using Consolidado.Business.LancamentoBLL;
using Consolidado.Business.LancamentoBLL.Interface;
using Consolidado.Domain.Entities.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Consolidado.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaldoDiarioController : ControllerBase
    {
        private readonly IGetData _service;


        public SaldoDiarioController(IGetData service)
        {
            _service = service;
        }

        // GET api/<SaldoDiarioController>
        [HttpGet]
        public SaldoDiarioResult Get(string dataLancamento)
        {
            return _service.CarregarSaldo(dataLancamento);
        }

    }
}
