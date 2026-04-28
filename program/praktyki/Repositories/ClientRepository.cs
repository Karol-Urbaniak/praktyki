using Microsoft.EntityFrameworkCore;
using praktyki.Data;
using praktyki.Models;
using praktyki.Repositories;

namespace praktyki.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients
            .Include(c => c.Addresses)    
            .ToListAsync();
        }

        public async Task<Client?> GetByIdAsync(int id)
        {
            return await _context.Clients
            .Include(c => c.Addresses)
            .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Clients.AnyAsync(e => e.Id == id);
        }

        public async Task AddAddressAsync(int clientId, ClientAddress address)
        {
            _context.ClientAddresses.Add(address);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAddressAsync(ClientAddress address)
        {
            _context.Entry(address).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAddressAsync(int addressId)
        {
            var address = await _context.ClientAddresses.FindAsync(addressId);
            if (address != null)
            {
                _context.ClientAddresses.Remove(address);
                await _context.SaveChangesAsync();
            }
        }
    }
}