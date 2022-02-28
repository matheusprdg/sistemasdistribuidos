namespace SistemasDistribuidos.Application
{
    public interface IServidorEscravoProvider
    {
        IServidorEscravo Obter(int id);
    }
}