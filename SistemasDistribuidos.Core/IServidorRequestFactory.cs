using System.Net.Http;

namespace SistemasDistribuidos.Application
{
    public interface IServidorEscravoRequestFactory
    {
        HttpRequestMessage CreateRequest(IServidorEscravo servidorEscravo, IRequestInput input);

    }

    public interface IServidorEspecializadoRequestFactory
    {
        HttpRequestMessage CreateRequest(IServidorEspecializado servidorEscravo, IRequestInput input);
    }
}