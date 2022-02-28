using SistemasDistribuidos.Application;

namespace ServidorWorker
{
    public class CalculadoraAdicao : ICalculadora
    {
        public TipoOperacao TipoOperacao => TipoOperacao.Adicao;

        public double Calcular(IRequestInput input)
        {
            return input.PrimeiroValor + input.SegundoValor;
        }
    }

    public class CalculadoraSubtracao : ICalculadora
    {
        public TipoOperacao TipoOperacao => TipoOperacao.Subtracao;

        public double Calcular(IRequestInput input)
        {
            return input.PrimeiroValor - input.SegundoValor;
        }
    }

    public class CalculadoraMultiplicacao : ICalculadora
    {
        public TipoOperacao TipoOperacao => TipoOperacao.Multiplicacao;

        public double Calcular(IRequestInput input)
        {
            return input.PrimeiroValor * input.SegundoValor;
        }
    }

    public class CalculadoraDivisao : ICalculadora
    {
        public TipoOperacao TipoOperacao => TipoOperacao.Divisao;

        public double Calcular(IRequestInput input)
        {
            return input.PrimeiroValor / input.SegundoValor;
        }
    }
}
