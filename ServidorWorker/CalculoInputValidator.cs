using FluentValidation;
using SistemasDistribuidos.Application;

namespace ServidorWorker
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
            if (!Enum.IsDefined(typeof(TipoOperacao), input.TipoOperacao))
            {
                context.AddFailure("Tipo de operação inválida.");
            }

            var tipoOperacao = (TipoOperacao)input.TipoOperacao;

            if (tipoOperacao == TipoOperacao.Divisao
                && input.SegundoValor == 0)
            {
                context.AddFailure("Não é possível realizar divisão por zero.");
            }
        }
    }
}
