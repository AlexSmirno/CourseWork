using Microsoft.EntityFrameworkCore;
using WebServer.Data.Models;

namespace WebServer.Data.Repositories
{
    public class ClientRepository
    {
        private readonly StorageContext _storageContext;

        public ClientRepository(StorageContext storageContext) => _storageContext = storageContext;

        public async Task<Client?> AddClientAsync(Client client)
        {
            var result = _storageContext.Clients.Add(client);
            await _storageContext.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }
        public async Task<List<Client>?> GetAllClientAsync()
        {
            return await _storageContext.Clients.Include(cl => cl.Supplies).ToListAsync();
        }

        public async Task<Client?> GetClientByIdAsync(int Id)
        {
            return await _storageContext.Clients.FirstOrDefaultAsync(client => client.Id == Id);
        }

        public async Task<Client?> UpdateClientAsync(Client client)
        {
            var result = _storageContext.Update(client);
            _storageContext.Entry(client).State = EntityState.Modified;
            await _storageContext.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }

        public async Task<bool> DeleteClientAsync(Client client)
        {
            _storageContext.Clients.Remove(client);
            await _storageContext.SaveChangesAsync();
            return true;
        }
    }
}
