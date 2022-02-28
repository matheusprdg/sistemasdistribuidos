using System.Threading.Tasks;

namespace SistemasDistribuidos.Application
{
    public interface IServidorService
    {
        Task<IResponseOutput> Execute(IRequestInput input);
    }
}