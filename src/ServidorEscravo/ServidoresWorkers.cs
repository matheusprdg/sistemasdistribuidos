using SistemasDistribuidos.Application;

namespace ServidorEscravo
{
    public class ServidorWorkerAlpha : IServidorEscravo
    {
        public bool Compativel(int id) => this.Id == id;

        public int Id => 1;

        public string Porta => "59590";
    }

    public class ServidorWorkerBravo : IServidorEscravo
    {
        public bool Compativel(int id) => this.Id == id;

        public int Id => 2;

        public string Porta => "59591";
    }
}