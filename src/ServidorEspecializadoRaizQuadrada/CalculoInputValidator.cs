using FluentValidation;
using SistemasDistribuidos.Application;

namespace ServidorEspecializadoRaizQuadrada
{
    public class CalculoInputValidator : AbstractValidator<IRequestInput>
    {
        public CalculoInputValidator()
        {
            RuleFor(f => f)
                .NotNull()
                .Custom((f, context) => ValidarParametros(f, context));
        }

        private void ValidarParametros(IRequestInput input, ValidationContext<IRequestInput> context)
        {
            if (input.PrimeiroValor < 0)
            {
                context.AddFailure("Não é possível obter Raíz Quadrada de um número negativo.");
            }
        }
    }
}