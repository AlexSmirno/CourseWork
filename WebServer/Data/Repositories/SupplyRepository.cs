using Microsoft.EntityFrameworkCore;
using WebServer.Data.Models;

namespace WebServer.Data.Repositories
{
    public class SupplyRepository
    {
        private readonly StorageContext _storageContext;

        public SupplyRepository(StorageContext storageContext) => _storageContext = storageContext;

        public async Task<Supply?> AddSupplyAsync(Supply supply)
        {
            var result = _storageContext.Supplies.Add(supply);
            await _storageContext.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }
        public async Task<List<Product>?> GetProductsAsync(int[] productsId)
        {
            return await _storageContext.Products.Where(prod => productsId.Contains(prod.Id)).ToListAsync();
        }
        public async Task<Supplier?> GetSupplierAsync(string companyName)
        {
            return await _storageContext.Suppliers.FirstOrDefaultAsync(s => s.CompanyName == companyName);
        }

        public async Task<Client?> GetClientAsync(string companyName)
        {
            return await _storageContext.Clients.FirstOrDefaultAsync(cl => cl.CompanyName == companyName);
        }

        public async Task<List<Supply>?> GetAllSuppliesAsync()
        {
            return await _storageContext.Supplies.Include(supply => supply.Supplier)
                                                        .Include(supply => supply.Products)
                                                        .Include(supply => supply.Client)
                                                        .ToListAsync();
        }

        public async Task<Supply?> GetSupplyByIdAsync(int Id)
        {
            return await _storageContext.Supplies.Include(supply => supply.Supplier)
                                                        .Include(supply => supply.Products)
                                                        .Include(supply => supply.Client)
                                                        .FirstOrDefaultAsync(supply => supply.Id == Id);
        }

        public async Task<Supply?> UpdateSupplyAsync(Supply supply)
        {
            var result = _storageContext.Update(supply);
            _storageContext.Entry(supply).State = EntityState.Modified;
            await _storageContext.SaveChangesAsync();

            return await Task.FromResult(result.Entity);
        }

        public async Task<bool> DeleteSupplyAsync(Supply supply)
        {
            _storageContext.Supplies.Remove(supply);
            await _storageContext.SaveChangesAsync();
            return true;
        }
    }
}
