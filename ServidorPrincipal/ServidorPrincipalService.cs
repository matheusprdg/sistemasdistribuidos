using SistemasDistribuidos.Application;

namespace ServidorPrincipal
{
    public class ServidorPrincipalService : IServidorService
    {
        private readonly IServidorEscravoProvider _servidorEscravoProvider;
        private readonly IResponseGetter _responseGetter;
        private readonly IServidorEscravoRequestFactory _servidorEscravoRequestFactory;
        public ServidorPrincipalService(
            IServidorEscravoProvider servidorEscravoProvider,
            IResponseGetter responseGetter,
            IServidorEscravoRequestFactory servidorEscravoRequestFactory)
        {
            _servidorEscravoProvider = servidorEscravoProvider;
            _servidorEscravoRequestFactory = servidorEscravoRequestFactory;
            _responseGetter = responseGetter;
        }

        public async Task<IResponseOutput> Execute(IRequestInput input)
        {
            var random = new Random();
            var servidorEscravo = _servidorEscravoProvider.Obter(random.Next(1, 4));

            var request = _servidorEscravoRequestFactory.CreateRequest(servidorEscravo, input);
            var resposta = await _responseGetter.ObterResposta(request);

            return resposta;
        }
    }
}