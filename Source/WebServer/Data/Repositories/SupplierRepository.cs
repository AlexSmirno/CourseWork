using Microsoft.EntityFrameworkCore;
using WebServer.Data.Models;

namespace WebServer.Data.Repositories
{
    public class SupplierRepository
    {
        private readonly StorageContext _storageContext;

        public SupplierRepository(StorageContext storageContext) => _storageContext = storageContext;

        public async Task<Supplier?> AddSupplierAsync(Supplier supplier)
        {
            var result = _storageContext.Suppliers.Add(supplier);
            await _storageContext.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }

        public async Task<List<Supplier>?> GetAllSupplierAsync()
        {
            return await _storageContext.Suppliers.Include(sup => sup.Supplies).ToListAsync();
        }

        public async Task<Supplier?> GetSupplierByIdAsync(int Id)
        {
            return await _storageContext.Suppliers.Include(sup => sup.Supplies).FirstOrDefaultAsync(supplier => supplier.Id == Id);
        }
        
        public async Task<List<string>> GetAllSupplierNamesAsync()
        {
            return await _storageContext.Suppliers.Select(sup => sup.CompanyName).ToListAsync();
        }
        public async Task<Supplier?> UpdateSupplierAsync(Supplier supplier)
        {
            var result = _storageContext.Update(supplier);
            _storageContext.Entry(supplier).State = EntityState.Modified;
            await _storageContext.SaveChangesAsync();

            return await Task.FromResult(result.Entity);
        }

        public async Task<bool> DeleteSupplierAsync(Supplier supplier)
        {
            _storageContext.Suppliers.Remove(supplier);
            await _storageContext.SaveChangesAsync();
            return true;
        }
    }
}
