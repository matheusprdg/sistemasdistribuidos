using SistemasDistribuidos.Application;

namespace ServidorWorker
{
    public class ServidorEspecializadoPotencia : IServidorEspecializado
    {
        public TipoOperacao TipoOperacao => TipoOperacao.Potencia;

        public string Porta => "48774";
    }

    public class ServidorEspecializadoRaizQuadrada : IServidorEspecializado
    {
        public TipoOperacao TipoOperacao => TipoOperacao.RaizQuadrada;

        public string Porta => "48775";
    }
}
