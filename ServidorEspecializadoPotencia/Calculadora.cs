using SistemasDistribuidos.Application;

namespace ServidorEspecializadoPotencia
{
    public class Calculadora : ICalculadora
    {
        public TipoOperacao TipoOperacao => TipoOperacao.Potencia;

        public double Calcular(IRequestInput input)
        {
            return Math.Pow(input.PrimeiroValor, input.SegundoValor);
        }
    }
}