using Blazor.Data.Models;

namespace Blazor.Services
{
    public interface ISupplierProvider
    {
        Task<List<Supplier>> GetAll();
        Task<List<string>> GetAllNames();
        Task<Supplier> GetOne(int id);
        Task<bool> Add(Supplier supplier);
        Task<Supplier> Edit(Supplier supplier);
        Task<bool> Remove(int id);
    }
}
