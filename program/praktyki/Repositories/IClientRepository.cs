using praktyki.Models;

namespace praktyki.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client?> GetByIdAsync(int id);
        Task AddAsync(Client client);
        Task UpdateAsync(Client client);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task AddAddressAsync(int clientId, ClientAddress address);

        Task UpdateAddressAsync(ClientAddress address);
        Task DeleteAddressAsync(int addressId);
    }
}
