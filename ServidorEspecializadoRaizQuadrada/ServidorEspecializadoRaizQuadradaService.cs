using FluentValidation;
using SistemasDistribuidos.Application;

namespace ServidorEspecializadoRaizQuadrada
{
    public class ServidorEspecializadoRaizQuadradaService : IServidorService
    {
        private readonly ICalculadoraFactory _calculadoraFactory;
        private readonly CalculoInputValidator _inputValidator;

        public ServidorEspecializadoRaizQuadradaService(ICalculadoraFactory calculadoraFactory)
        {
            _calculadoraFactory = calculadoraFactory;
            _inputValidator = new CalculoInputValidator();
        }

        public async Task<IResponseOutput> Execute(IRequestInput input)
        {
            try
            {
                _inputValidator.ValidateAndThrow(input);

                var calculadora = _calculadoraFactory.Create();
                var resultado = calculadora.Calcular(input);

                return await Task.FromResult(new ResponseOutput
                {
                    Resultado = resultado
                });
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