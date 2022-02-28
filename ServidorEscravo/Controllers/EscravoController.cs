using Microsoft.AspNetCore.Mvc;
using SistemasDistribuidos.Application;

namespace ServidorEscravo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EscravoController : ControllerBase
    {
        private readonly IServidorService _servidorEscravoService;

        public EscravoController(IServidorService servidorEscravoService)
        {
            _servidorEscravoService = servidorEscravoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(double primeiroValor, double segundoValor, int operacao)
        {
            var retorno = await _servidorEscravoService.Execute(
                new RequestInput
                {
                    PrimeiroValor = primeiroValor,
                    SegundoValor = segundoValor,
                    TipoOperacao = operacao,
                });

            return Ok(retorno);
        }
    }
}