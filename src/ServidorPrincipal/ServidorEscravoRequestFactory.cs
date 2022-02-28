using SistemasDistribuidos.Application;
using System.Text;

namespace ServidorPrincipal
{
    public class ServidorEscravoRequestFactory : IServidorEscravoRequestFactory
    {
        public HttpRequestMessage CreateRequest(IServidorEscravo servidorEscravo, IRequestInput input)
        {
            var stringBuilder = new StringBuilder();

            var request = new HttpRequestMessage(
                HttpMethod.Get,
                stringBuilder
                    .Append($"https://localhost:{servidorEscravo.Porta}/Escravo")
                    .Append($"?primeiroValor={input.PrimeiroValor}")
                    .Append($"&segundoValor={input.SegundoValor}")
                    .Append($"&operacao={input.TipoOperacao}")
                .ToString());

            return request;
        }
    }
}