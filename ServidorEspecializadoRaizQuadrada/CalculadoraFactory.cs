using SistemasDistribuidos.Application;

namespace ServidorEspecializadoRaizQuadrada
{
    public class CalculadoraFactory : ICalculadoraFactory
    {
        public ICalculadora Create() => new Calculadora();
    }
}