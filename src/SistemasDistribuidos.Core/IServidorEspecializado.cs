namespace SistemasDistribuidos.Application
{
    public interface IServidorEspecializado : IServidor
    {
        TipoOperacao TipoOperacao { get; }
    }
}