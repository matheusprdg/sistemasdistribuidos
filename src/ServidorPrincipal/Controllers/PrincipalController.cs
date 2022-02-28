using Microsoft.AspNetCore.Mvc;
using SistemasDistribuidos.Application;

namespace ServidorPrincipal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrincipalController : ControllerBase
    {
        private readonly IServidorService _servidorPrincipalService;

        public PrincipalController(IServidorService servidorPrincipalService)
        {
            _servidorPrincipalService = servidorPrincipalService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(double primeiroValor, double segundoValor, int tipoOperacao)
        {
            var retorno = await _servidorPrincipalService.Execute(
                new RequestInput
                {
                    PrimeiroValor = primeiroValor,
                    SegundoValor = segundoValor,
                    TipoOperacao = tipoOperacao,
                });

            return Ok(retorno);
        }
    }
}