using SistemasDistribuidos.Application;

namespace ServidorEspecializadoPotencia
{
    public class CalculadoraFactory : ICalculadoraFactory
    {
        public ICalculadora Create() => new Calculadora();
    }
}