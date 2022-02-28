namespace SistemasDistribuidos.Application
{
    public interface ICalculadora
    {
        TipoOperacao TipoOperacao { get; }

        double Calcular(IRequestInput input);
    }
}
