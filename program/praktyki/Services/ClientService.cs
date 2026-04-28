using praktyki.Models;
using praktyki.Repositories;

namespace praktyki.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Client?> GetClientByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateClientAsync(Client client)
        {
            client.IsCompany = !string.IsNullOrEmpty(client.Nip);
            await _repository.AddAsync(client);
        }

        public async Task UpdateClientAsync(int id, Client client)
        {
            if (id != client.Id) throw new ArgumentException("ID mismatch");

            client.IsCompany = !string.IsNullOrEmpty(client.Nip);
            await _repository.UpdateAsync(client);
        }

        public async Task DeleteClientAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task AddAddressAsync(int clientId, ClientAddress address)
        {
            await _repository.AddAddressAsync(clientId, address);
        }

        public async Task UpdateAddressAsync(ClientAddress address)
        {
            await _repository.UpdateAddressAsync(address);
        }

        public async Task DeleteAddressAsync(int addressId)
        {
            await _repository.DeleteAddressAsync(addressId);
        }
    }
}