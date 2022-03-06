namespace SistemasDistribuidos.Application
{
    public class ServidorEscravo : IServidorEscravo
    {
        public int Id { get; set; }

        public string Porta { get; set; }

        public bool Compativel(int id) => this.Id == id;
    }
}