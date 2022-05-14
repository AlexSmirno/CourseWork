using WebServer.Data.Models;
using WebServer.Data.DTO;
using Microsoft.EntityFrameworkCore;
using WebServer.Data.Repositories;

namespace WebServer.Data.Services
{
    public class SupplierService
    {
        private readonly SupplierRepository _supplierRepository;

        public SupplierService(SupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<Supplier?> AddSupplier(SupplierDTO supplierDTO)
        {
            Supplier supplier = new Supplier()
            {
                CompanyName = supplierDTO.CompanyName,
                Address = supplierDTO.Address,
                Phone = supplierDTO.Phone
            };

            var result = await _supplierRepository.AddSupplierAsync(supplier);

            return await Task.FromResult(result);
        }

        public async Task<Supplier?> GetSupplier(int Id)
        {
            var supplier = await _supplierRepository.GetSupplierByIdAsync(Id);
            return await Task.FromResult(supplier);
        }

        public async Task<List<Supplier>?> GetSuppliers()
        {
            var suppliers = await _supplierRepository.GetAllSupplierAsync();
            return await Task.FromResult(suppliers);
        }

        public async Task<Supplier?> UpdateSupplier(SupplierDTO newSupplier)
        {
            var supplier = await _supplierRepository.GetSupplierByIdAsync(newSupplier.Id);
            if (supplier != null)
            {
                supplier.Address = newSupplier.Address;
                supplier.Phone = newSupplier.Phone;
                supplier.CompanyName = newSupplier.CompanyName;

                var result = await _supplierRepository.UpdateSupplierAsync(supplier);

                return await Task.FromResult(result);
            }

            return null;
        }
        
        public async Task<bool> DeleteSupplier(int Id)
        {
            var supplier = await _supplierRepository.GetSupplierByIdAsync(Id);

            if (supplier != null)
            {
                var result = await _supplierRepository.DeleteSupplierAsync(supplier);
                return result;
            }

            return false;
        }
    }
}
