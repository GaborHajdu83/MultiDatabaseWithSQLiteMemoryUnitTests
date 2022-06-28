using Entities.DataTransferObjects;

namespace CompanyEmployees.BusinessLayer.Services.ClientServ
{
    public interface IClientService
    {
        public Task<IEnumerable<ClientDto>> GetClients();
        public Task<ClientDto> GetClientById(Guid id);
        public ClientDto AddClient(ClientDto companyDto);
        public Task DeleteClientById(Guid id);
    }
}
