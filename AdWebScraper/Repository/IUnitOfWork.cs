using System.Threading.Tasks;

namespace AdWebScraper.Repository
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
