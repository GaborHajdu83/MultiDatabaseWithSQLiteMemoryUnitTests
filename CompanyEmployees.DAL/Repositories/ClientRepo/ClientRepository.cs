using Entities.Models;

namespace CompanyEmployess.DAL.Repositories.ClientRepo
{
    public class ClientRepository : RepositoryBase<ExternalClientContext, Client>, IClientRepository
    {
        public ClientRepository(ExternalClientContext clientContext)
            :base(clientContext)
        {
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync() => _context.Clients.ToList();
    }
}
