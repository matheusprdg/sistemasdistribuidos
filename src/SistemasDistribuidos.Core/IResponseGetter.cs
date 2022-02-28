using System.Net.Http;
using System.Threading.Tasks;

namespace SistemasDistribuidos.Application
{
    public interface IResponseGetter
    {
        Task<IResponseOutput> ObterResposta(HttpRequestMessage request);
    }
}