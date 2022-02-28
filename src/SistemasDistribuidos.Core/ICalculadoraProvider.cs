namespace SistemasDistribuidos.Application
{
    public interface ICalculadoraProvider
    {
        ICalculadora Obter(TipoOperacao tipoOperacao);
    }
}
