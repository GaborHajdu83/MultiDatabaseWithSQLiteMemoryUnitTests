using AutoMapper;
using CompanyEmployess.DAL.Repositories;
using Entities.DataTransferObjects;
using Entities.Models;

namespace CompanyEmployees.BusinessLayer.Services.ClientServ
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ClientService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public ClientDto AddClient(ClientDto clientDto)
        {
            ArgumentNullException.ThrowIfNull(clientDto);

            if (string.IsNullOrWhiteSpace(clientDto.Name))
            {
                throw new ArgumentNullException("Client name is null or empty");
            }

            Client client = _mapper.Map<Client>(clientDto);
            try
            {
                _uow.ClientRepository.Add(client);

                _uow.SaveChangesClient();
            }
            catch (Exception ex)
            {
                throw;
            }

            return _mapper.Map<ClientDto>(client);
        }

        public async Task DeleteClientById(Guid id)
        {
            Client client = await _uow.ClientRepository.GetByIdAsync(id);

            if (client != null)
            {
                _uow.ClientRepository.Remove(client);
                _uow.SaveChangesClient();
            }
        }

        public async Task<ClientDto> GetClientById(Guid id)
        {
            Client client = await _uow.ClientRepository.GetByIdAsync(id);

            ClientDto clientDto = _mapper.Map<ClientDto>(client);

            return clientDto;
        }

        public async Task<IEnumerable<ClientDto>> GetClients()
        {
            IEnumerable<Client> clients = await _uow.ClientRepository.GetAllClientsAsync();

            IEnumerable<ClientDto> clientsDto = _mapper.Map<IEnumerable<Client>, List<ClientDto>>(clients);

            return clientsDto;
        }
    }
}
