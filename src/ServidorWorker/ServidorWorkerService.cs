using FluentValidation;
using SistemasDistribuidos.Application;

namespace ServidorWorker
{
    public class ServidorWorkerService : IServidorService
    {
        private readonly ICalculadoraProvider _calculadoraProvider;
        private readonly IServidorEspecializadoProvider _servidorEspecializadoProvider;
        private readonly IServidorEspecializadoRequestFactory _servidorEspecializadoRequestFactory;
        private readonly IResponseGetter _responseGetter;
        private readonly IConfiguration _configuration;
        private readonly CalculoInputValidator _inputValidator;

        public ServidorWorkerService(
            ICalculadoraProvider calculadoraProvider,
            IServidorEspecializadoProvider servidorEspecializadoProvider,
            IServidorEspecializadoRequestFactory servidorEspecializadoRequestFactory,
            IResponseGetter responseGetter,
            IWebHostEnvironment webHostEnvironment,
            IConfiguration configuration)
        {
            _calculadoraProvider = calculadoraProvider;
            _servidorEspecializadoProvider = servidorEspecializadoProvider;
            _servidorEspecializadoRequestFactory = servidorEspecializadoRequestFactory;
            _responseGetter = responseGetter;
            _configuration = configuration;
            _inputValidator = new CalculoInputValidator();
        }

        public async Task<IResponseOutput> Execute(IRequestInput input)
        {
            var projectRootPath = _configuration.GetValue<string>("CaminhoArquivosServidores");

            try
            {
                _inputValidator.ValidateAndThrow(input);

                var calculadora = _calculadoraProvider.Obter((TipoOperacao)input.TipoOperacao);

                if (calculadora is not null)
                {
                    var resultado = calculadora.Calcular(input);

                    return new ResponseOutput
                    {
                        Resultado = resultado
                    };
                }

                var servidorEspecializado = _servidorEspecializadoProvider.Obter(projectRootPath, (TipoOperacao)input.TipoOperacao);

                var request = _servidorEspecializadoRequestFactory.CreateRequest(servidorEspecializado, input);
                var resposta = await _responseGetter.ObterResposta(request);

                return resposta;
            }
            catch (Exception ex)
            {
                if (ex is ValidationException validationException)
                {
                    var mensagemErroValidacao = this.ObterMensagemErro(validationException);

                    throw new Exception(mensagemErroValidacao);
                }

                throw new Exception(ex.Message);
            }
        }

        private string ObterMensagemErro(ValidationException ex)
        {
            var mensagens = ex.Errors.Select(f => f.ErrorMessage);

            if (mensagens.Any() && mensagens.Count() == 1)
                return $"Erro de validação: {mensagens.First()}";

            return $"Erros de validação: {string.Join(" ", mensagens)}";
        }
    }
}
