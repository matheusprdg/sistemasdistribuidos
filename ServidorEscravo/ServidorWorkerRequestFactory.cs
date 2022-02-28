using SistemasDistribuidos.Application;
using System.Text;

namespace ServidorEscravo
{
    public class ServidorWorkerRequestFactory : IServidorEscravoRequestFactory
    {
        public HttpRequestMessage CreateRequest(IServidorEscravo servidorWorker, IRequestInput input)
        {
            var stringBuilder = new StringBuilder();

            var request = new HttpRequestMessage(
                HttpMethod.Get,
                stringBuilder
                    .Append($"https://localhost:{servidorWorker.Porta}/Worker")
                    .Append($"?primeiroValor={input.PrimeiroValor}")
                    .Append($"&segundoValor={input.SegundoValor}")
                    .Append($"&operacao={input.TipoOperacao}")
                .ToString());

            return request;
        }
    }
}