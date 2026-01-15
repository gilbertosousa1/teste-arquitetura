using Lancamentos.Business.LancamentoBLL;
using Lancamentos.Business.LancamentoBLL.Interface;
using Lancamentos.Domain.Entities.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lancamentos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentoController : ControllerBase
    {
        private readonly IPostData _service;
        //private readonly PostData _postData;


        public LancamentoController(IPostData service)
        {
            _service = service;
           // _postData = postData;
        }

        // POST api/<LancamentoController>
        [HttpPost]
        public async Task<LancamentoResult> Post([FromBody] LancamentoRequest request)
        {
            return await _service.Salvar(request);
        }

    }
}
