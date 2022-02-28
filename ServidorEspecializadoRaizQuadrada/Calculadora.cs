using SistemasDistribuidos.Application;

namespace ServidorEspecializadoRaizQuadrada
{
    public class Calculadora : ICalculadora
    {
        public TipoOperacao TipoOperacao => TipoOperacao.RaizQuadrada;

        public double Calcular(IRequestInput input)
        {
            return Math.Sqrt(input.PrimeiroValor);
        }
    }
}