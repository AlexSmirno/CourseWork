using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;
using WebServer.Data.DTO;
using WebServer.Data.Models;

namespace WebServer.Data.Repositories
{
    public class ProductRepository
    {
        private readonly StorageContext _storageContext;

        public ProductRepository(StorageContext storageContext) => _storageContext = storageContext;

        public async Task<Product?> AddProductAsync(Product product)
        {
            var result = _storageContext.Products.Add(product);
            await _storageContext.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }

        public async Task<List<Product>?> GetAllProductAsync()
        {
            var result = await _storageContext.Products.Where(pr => pr.IsDeleted == false)
                                                        .Include(prod => prod.Supply).ToListAsync();

            if (result.Count == 0)
            {
                return await Task.FromResult(result);
            }

            result.ForEach(el => el.Supply =
                    _storageContext.Supplies.Include(sup => sup.Supplier).Include(sup => sup.Client).FirstOrDefault());

            return await Task.FromResult(result);
        }

        public async Task<Product?> GetProductByIdAsync(int Id)
        {
            var result = await _storageContext.Products.Where(pr => pr.IsDeleted == false).Include(pr => pr.Supply).FirstOrDefaultAsync(product => product.Id == Id);
           
            return await Task.FromResult(result);
        }
        public async Task<string?> GetClientCompanyByIdProduct(int SupplyId)
        {
            var result = _storageContext.Supplies
                .Join(_storageContext.Clients, sup => sup.ClientId, cl => cl.Id, (sup, cl) => new { CompanyName = cl.CompanyName });

            return await Task.FromResult(result.FirstOrDefault().CompanyName);
        }

        public async Task<string?> GetSupplierCompanyByIdProduct(int SupplyId)
        {
            var result = _storageContext.Supplies
                .Join(_storageContext.Suppliers, sup => sup.SupplierId, supr => supr.Id, (sup, supr) => new {CompanyName = supr.CompanyName});

            return await Task.FromResult(result.FirstOrDefault().CompanyName);
        }

        public async Task<Product?> UpdateProductAsync(Product product)
        {
            var result = _storageContext.Update(product);
            _storageContext.Entry(product).State = EntityState.Modified;
            await _storageContext.SaveChangesAsync();

            return await Task.FromResult(result.Entity);
        }

        public async Task<bool> DeleteProductAsync(int Id)
        {
            var product = await _storageContext.Products.FirstOrDefaultAsync(prod => prod.Id == Id);

            if (product != null)
            {
                _storageContext.Products.Remove(product);
                await _storageContext.SaveChangesAsync();
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }

    }
}
