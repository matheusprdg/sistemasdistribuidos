namespace SistemasDistribuidos.Application
{
    public interface IServidorEspecializadoProvider
    {
        IServidorEspecializado Obter(string rootPath, TipoOperacao tipoOperacao);

        IServidorEspecializado ObterServidor(string rootPath, TipoOperacao tipoOperacao);
    }
}