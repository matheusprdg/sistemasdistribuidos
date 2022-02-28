using Microsoft.AspNetCore.Mvc;
using SistemasDistribuidos.Application;

namespace ServidorEspecializadoPotencia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EspecializadoPotenciaController : ControllerBase
    {
        private readonly IServidorService _potenciaService;

        public EspecializadoPotenciaController(IServidorService potenciaService)
        {
            _potenciaService = potenciaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(double primeiroValor, double segundoValor)
        {
            var resposta = await _potenciaService.Execute(
                new RequestInput
                {
                    PrimeiroValor = primeiroValor,
                    SegundoValor = segundoValor,
                });

            return Ok(resposta);
        }
    }
}