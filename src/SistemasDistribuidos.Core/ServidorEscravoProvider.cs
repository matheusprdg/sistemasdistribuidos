using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SistemasDistribuidos.Application
{
    public class ServidorEscravoProvider : IServidorEscravoProvider
    {
        private const string NomeArquivoServidorEscravo = "ServidoresEscravos.txt";
        private const string NomeArquivoServidorWorker = "ServidoresWorkers.txt";

        public int ObterQuantidadeServidores(string pasta, string rootPath)
        {
            var servidores = ObterServidores(pasta, rootPath);
            return servidores.Count();
        }

        public IServidorEscravo Obter(int id, string pasta, string rootPath)
        {
            var servidoresEscravos = this.ObterServidores(pasta, rootPath);

            var servidorEscravo = servidoresEscravos.FirstOrDefault(x => x.Compativel(id));

            if (servidorEscravo is null)
            {
                throw new Exception($"Servidor de id {id} não encontrado.");
            }
            
            return servidorEscravo;
        }

        public IEnumerable<IServidorEscravo> ObterServidores(string pasta, string rootPath)
        {
            var arquivoUsar =
                pasta.Equals("escravo", StringComparison.InvariantCultureIgnoreCase)
                ? NomeArquivoServidorEscravo
                : NomeArquivoServidorWorker;

            var path = Path.Combine(rootPath, pasta, arquivoUsar);

            if (!File.Exists(path))
            {
                throw new Exception("Arquivo dos servidores não econtrado.");
            }

            string content = File.ReadAllText(path);

            var servidores = JsonConvert.DeserializeObject<IEnumerable<ServidorEscravo>>(content);

            if (!servidores.Any())
            {
                throw new Exception("Nenhum servidor encontrado.");
            }

            foreach (var servidor in servidores)
            {
                yield return new ServidorEscravo
                {
                    Id = servidor.Id,
                    Porta = servidor.Porta,
                };
            }
        }
    }
}