using FluentValidation;
using SistemasDistribuidos.Application;

namespace ServidorEspecializadoPotencia
{
    public class ServidorEspecializadoPotenciaService : IServidorService
    {
        private readonly ICalculadoraFactory _calculadoraFactory;
        private readonly CalculoInputValidator _inputValidator;

        public ServidorEspecializadoPotenciaService(ICalculadoraFactory calculadoraFactory)
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
            catch(Exception ex)
            {
                if (ex is OverflowException overflowException)
                {
                    throw new Exception("O resultado da operação era menor ou maior do que o suportado pelo tipo Double.");
                }

                throw;
            }
        }
    }
}