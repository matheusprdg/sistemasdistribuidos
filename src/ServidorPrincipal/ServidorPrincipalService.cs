using SistemasDistribuidos.Application;

namespace ServidorPrincipal
{
    public class ServidorPrincipalService : IServidorService
    {
        private readonly IServidorEscravoProvider _servidorEscravoProvider;
        private readonly IResponseGetter _responseGetter;
        private readonly IServidorEscravoRequestFactory _servidorEscravoRequestFactory;
        private IConfiguration _configuration;

        public ServidorPrincipalService(
            IServidorEscravoProvider servidorEscravoProvider,
            IResponseGetter responseGetter,
            IServidorEscravoRequestFactory servidorEscravoRequestFactory,
            IConfiguration configuration)
        {
            _servidorEscravoProvider = servidorEscravoProvider;
            _servidorEscravoRequestFactory = servidorEscravoRequestFactory;
            _responseGetter = responseGetter;
            _configuration = configuration;
        }

        public async Task<IResponseOutput> Execute(IRequestInput input)
        {
            var projectRootPath = _configuration.GetValue<string>("CaminhoArquivosServidores");
            var pasta = "Escravo";
            var random = new Random();
            var quantidadeServidoresEscravos = _servidorEscravoProvider.ObterQuantidadeServidores(pasta, projectRootPath);

            var servidorEscravo = _servidorEscravoProvider.Obter(random.Next(1, quantidadeServidoresEscravos + 1), pasta, projectRootPath);

            var request = _servidorEscravoRequestFactory.CreateRequest(servidorEscravo, input);
            var resposta = await _responseGetter.ObterResposta(request);

            return resposta;
        }
    }
}