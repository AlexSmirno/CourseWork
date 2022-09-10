using Blazor.Data.Models;

namespace Blazor.Services
{
    public interface ISupplyProvider
    {
        Task<List<Supply>> GetAll();
        Task<Supply> GetOne(int id);
        Task<bool> Add(SupplyINDTO supply);
        Task<bool> Add(SupplyOutDTO supply);
        Task<Supply> Edit(Supply supply);
        Task<bool> Remove(int id);
    }
}
