using Blazor.Data.Models;

namespace Blazor.Services
{
    public interface IClientProvider
    {
        Task<List<Client>> GetAll();
        Task<Client> GetOne(int id);
        Task<bool> Add(Client client);
        Task<Client> Edit(Client client);
        Task<bool> Remove(int id);
    }
}
