namespace SistemasDistribuidos.Application
{
    public interface IServidorEscravo : IServidor
    {
        bool Compativel(int id);

        int Id { get; }
    }
}