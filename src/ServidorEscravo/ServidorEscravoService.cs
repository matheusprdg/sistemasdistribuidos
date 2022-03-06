using SistemasDistribuidos.Application;

namespace ServidorEscravo
{
    public class ServidorEscravoService : IServidorService
    {
        private readonly IServidorEscravoProvider _servidorWorkerProvider;
        private readonly IResponseGetter _responseGetter;
        private readonly IServidorEscravoRequestFactory _servidorWorkerRequestFactory;
        private IConfiguration _configuration;

        public ServidorEscravoService(
            IServidorEscravoProvider servidorWorkerProvider,
            IResponseGetter responseGetter,
            IServidorEscravoRequestFactory servidorWorkerRequestFactory,
            IConfiguration configuration)
        {
            _servidorWorkerProvider = servidorWorkerProvider;
            _servidorWorkerRequestFactory = servidorWorkerRequestFactory;
            _responseGetter = responseGetter;
            _configuration = configuration;
        }

        public async Task<IResponseOutput> Execute(IRequestInput input)
        {
            var projectRootPath = _configuration.GetValue<string>("CaminhoArquivosServidores");
            var pasta = "Worker";
            var random = new Random();
            var quantidadeServidoresWorkers = _servidorWorkerProvider.ObterQuantidadeServidores(pasta, projectRootPath);
            var servidorWorker = _servidorWorkerProvider.Obter(random.Next(1, quantidadeServidoresWorkers + 1), pasta, projectRootPath);

            var request = _servidorWorkerRequestFactory.CreateRequest(servidorWorker, input);
            var resposta = await _responseGetter.ObterResposta(request);

            return resposta;
        }
    }
}