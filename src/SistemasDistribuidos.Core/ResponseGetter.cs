using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SistemasDistribuidos.Application
{
    public class ResponseGetter : IResponseGetter
    {
        private readonly IHttpClientFactory _clientFactory;

        public ResponseGetter(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IResponseOutput> ObterResposta(HttpRequestMessage request)
        {
            var responseString = string.Empty;

            try
            {
                var response = await _clientFactory.CreateClient().GetAsync(request.RequestUri);

                responseString = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();

                var retorno = JsonConvert.DeserializeObject<ResponseOutput>(responseString);

                return retorno;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("recusou", StringComparison.InvariantCultureIgnoreCase)
                    || e.Message.Contains("nenhuma conexão", StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new Exception(e.Message);
                }

                var exceptionMessage = this.ObterMensagemErro(responseString);
                throw new Exception(exceptionMessage, e);
            }
        }

        private string ObterMensagemErro(string responseString)
        {
            var retorno = JsonConvert.DeserializeObject<ErrorMessage>(responseString);

            return retorno.Message;
        }
    }

    public class ErrorMessage
    {
        public string Message { get; set; }
    }
}