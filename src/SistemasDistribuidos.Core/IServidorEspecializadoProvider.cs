namespace SistemasDistribuidos.Application
{
    public interface IServidorEspecializadoProvider
    {
        IServidorEspecializado Obter(TipoOperacao tipoOperacao);
    }
}