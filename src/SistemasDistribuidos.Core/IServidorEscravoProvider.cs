using System.Collections.Generic;

namespace SistemasDistribuidos.Application
{
    public interface IServidorEscravoProvider
    {
        IServidorEscravo Obter(int id, string pasta, string rootPath);

        int ObterQuantidadeServidores(string pasta, string rootPath);

        IEnumerable<IServidorEscravo> ObterServidores(string pasta, string rootPath);
    }
}