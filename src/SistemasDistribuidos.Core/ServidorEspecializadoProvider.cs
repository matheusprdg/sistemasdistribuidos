using Newtonsoft.Json;
using System;
using System.IO;

namespace SistemasDistribuidos.Application
{
    public class ServidorEspecializadoProvider : IServidorEspecializadoProvider
    {
        private const string NomeArquivoServidorPotencia = "ServidorPotencia.txt";
        private const string NomeArquivoServidorRaizQuadrada = "ServidorRaizQuadrada.txt";

        public IServidorEspecializado Obter(string rootPath, TipoOperacao tipoOperacao)
        {
            return this.ObterServidor(rootPath, tipoOperacao);
        }

        public IServidorEspecializado ObterServidor(string rootPath, TipoOperacao tipoOperacao)
        {
            var arquivoUsar = tipoOperacao == TipoOperacao.Potencia
                ? NomeArquivoServidorPotencia
                : NomeArquivoServidorRaizQuadrada;

            var pasta = "Especializados";

            var path = Path.Combine(rootPath, pasta, arquivoUsar);

            if (!File.Exists(path))
            {
                throw new Exception("Arquivo do servidor não econtrado.");
            }

            string content = File.ReadAllText(path);

            var servidor = JsonConvert.DeserializeObject<ServidorEspecializado>(content);

            if (servidor is null)
            {
                throw new Exception("Servidor não encontrado");
            }

            return new ServidorEspecializado { Porta = servidor.Porta };
        }
    }
}