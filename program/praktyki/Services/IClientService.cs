using praktyki.Models;

namespace praktyki.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<Client?> GetClientByIdAsync(int id);
        Task CreateClientAsync(Client client);
        Task UpdateClientAsync(int id, Client client);
        Task DeleteClientAsync(int id);
        Task AddAddressAsync(int clientId, ClientAddress address);
        Task UpdateAddressAsync(ClientAddress address);
        Task DeleteAddressAsync(int addressId);
    }
}