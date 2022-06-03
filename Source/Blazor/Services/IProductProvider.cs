using Blazor.Data.Models;

namespace Blazor.Services
{
    public interface IProductProvider
    {
        Task<List<ProductDTO>> GetAllDTO();
        Task<List<Product>> GetAll();
        Task<Product> GetOne(int id);
        Task<bool> Add(Product product);
        Task<Product> Edit(Product product);
        Task<bool> Remove(int id);
    }
}
