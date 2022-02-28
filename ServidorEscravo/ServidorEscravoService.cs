using SistemasDistribuidos.Application;

namespace ServidorEscravo
{
    public class ServidorEscravoService : IServidorService
    {
        private readonly IServidorEscravoProvider _servidorWorkerProvider;
        private readonly IResponseGetter _responseGetter;
        private readonly IServidorEscravoRequestFactory _servidorWorkerRequestFactory;

        public ServidorEscravoService(
            IServidorEscravoProvider servidorWorkerProvider,
            IResponseGetter responseGetter,
            IServidorEscravoRequestFactory servidorWorkerRequestFactory)
        {
            _servidorWorkerProvider = servidorWorkerProvider;
            _servidorWorkerRequestFactory = servidorWorkerRequestFactory;
            _responseGetter = responseGetter;
        }

        public async Task<IResponseOutput> Execute(IRequestInput input)
        {
            var random = new Random();
            var servidorWorker = _servidorWorkerProvider.Obter(random.Next(1, 3));

            var request = _servidorWorkerRequestFactory.CreateRequest(servidorWorker, input);
            var resposta = await _responseGetter.ObterResposta(request);

            return resposta;
        }
    }
}