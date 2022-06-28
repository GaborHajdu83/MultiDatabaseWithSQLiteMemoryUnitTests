using Entities.Models;

namespace CompanyEmployess.DAL.Repositories.ClientRepo
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();
    }
}
