using SistemasDistribuidos.Application;

namespace ServidorPrincipal
{
    public class ServidorEscravoAlpha : IServidorEscravo
    {
        public bool Compativel(int id) => this.Id == id;

        public int Id => 1;

        public string Porta => "48070";
    }

    public class ServidorEscravoBravo : IServidorEscravo
    {
        public bool Compativel(int id) => this.Id == id;

        public int Id => 2;

        public string Porta => "48071";
    }

    public class ServidorEscravoCharlie : IServidorEscravo
    {
        public bool Compativel(int id) => this.Id == id;

        public int Id => 3;

        public string Porta => "48072";
    }
}