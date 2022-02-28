using Microsoft.AspNetCore.Mvc;
using SistemasDistribuidos.Application;

namespace ServidorEspecializadoRaizQuadrada.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EspecializadoRaizQuadradaController : ControllerBase
    {
        private readonly IServidorService _raizQuadradaService;

        public EspecializadoRaizQuadradaController(IServidorService raizQuadradaService)
        {
            _raizQuadradaService = raizQuadradaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(double primeiroValor)
        {
            var resposta = await _raizQuadradaService.Execute(
                new RequestInput
                {
                    PrimeiroValor = primeiroValor,
                });

            return Ok(resposta);
        }
    }
}