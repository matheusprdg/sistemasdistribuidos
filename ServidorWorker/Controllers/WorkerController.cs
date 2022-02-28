using Microsoft.AspNetCore.Mvc;
using SistemasDistribuidos.Application;

namespace ServidorWorker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkerController : ControllerBase
    {
        private readonly IServidorService _servidorWorkerService;

        public WorkerController(IServidorService servidorWorkerService)
        {
            _servidorWorkerService = servidorWorkerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(double primeiroValor, double segundoValor, int operacao)
        {
            var resposta = await _servidorWorkerService.Execute(
                new RequestInput
                {
                    PrimeiroValor = primeiroValor,
                    SegundoValor = segundoValor,
                    TipoOperacao = operacao,
                });

            return Ok(resposta);
        }
    }
}