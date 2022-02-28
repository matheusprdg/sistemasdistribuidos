using SistemasDistribuidos.Application;
using System.Text;

namespace ServidorWorker
{
    public class ServidorEspecializadoRequestFactory : IServidorEspecializadoRequestFactory
    {
        public HttpRequestMessage CreateRequest(IServidorEspecializado servidorEspecializado, IRequestInput input)
        {
            var tipoOperacao = (TipoOperacao)input.TipoOperacao;
            var stringBuilder = new StringBuilder()
                .Append($"https://localhost:{servidorEspecializado.Porta}/")
                .Append($"Especializado{tipoOperacao.ToString()}")
                .Append($"?primeiroValor={input.PrimeiroValor}");

            if (tipoOperacao == TipoOperacao.Potencia)
                stringBuilder.Append($"&segundoValor={input.SegundoValor}");

            return new HttpRequestMessage(HttpMethod.Get, stringBuilder.ToString());
        }
    }
}