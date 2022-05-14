using Microsoft.EntityFrameworkCore;
using WebServer.Data.DTO;
using WebServer.Data.Models;
using WebServer.Data.Repositories;

namespace WebServer.Data.Services
{
    public class SupplyService
    {
        private readonly SupplyRepository _supplyRepository;

        public SupplyService(SupplyRepository supplyRepository)
        {
            _supplyRepository = supplyRepository;
        }

        public async Task<Supply?> AddSupply(Supply supply) // Разные добавления для IN и OUT
        {
            Supply newSupply = new Supply()
            {
                Date = supply.Date,
                Division = supply.Division,
                Time = supply.Time,
                Type = supply.Type
            };

            if (supply.Products.Any())
            {
                //int[] productsId = supply.Products.Select(prod => prod.Id).ToArray(); - для OUT

                newSupply.Products = supply.Products;
            }

            if (supply.Supplier != null)
            {
                newSupply.Supplier = await _supplyRepository.GetSupplierAsync(supply.Supplier.CompanyName); ;
            }

            if (supply.Client != null)
            {
                newSupply.Client = await _supplyRepository.GetClientAsync(supply.Client.CompanyName);
            }

            var result = await _supplyRepository.AddSupplyAsync(newSupply);
            return await Task.FromResult(result);
        }

        public async Task<Supply?> GetSupply(int Id)
        {
            var result = await _supplyRepository.GetSupplyByIdAsync(Id);
            return await Task.FromResult(result);
        }

        public async Task<List<Supply>> GetSupplies()
        {
            var result = await _supplyRepository.GetAllSuppliesAsync();
            return await Task.FromResult(result);
        }

        public async Task<List<SupplyDTO>?> GetSupplyDTO()
        {
            var result = await _supplyRepository.GetAllSuppliesAsync();

            if (result.Any())
            {
                List<SupplyDTO> supplyDTOs = new List<SupplyDTO>();
                foreach (var supply in result)
                {
                    supplyDTOs.Add(new SupplyDTO()
                    {
                        Date = supply.Date,
                        Division = supply.Division,
                        Supplier = supply.Supplier.CompanyName,
                        Time = supply.Time,
                        Type = supply.Type
                    });
                }
                return await Task.FromResult(supplyDTOs);
            }
            return null;
        }
        public async Task<Supply?> UpdateSupply(Supply newSupply)
        {
            var supply = await _supplyRepository.GetSupplyByIdAsync(newSupply.Id);

            if (supply != null)
            {
                supply.Id = newSupply.Id;
                supply.Division = newSupply.Division;
                supply.Type = newSupply.Type;
                supply.Date = newSupply.Date;
                supply.Time = newSupply.Time;

                if (supply.Products.Any())
                {
                    int[] productsId = supply.Products.Select(prod => prod.Id).ToArray();
                    supply.Products = await _supplyRepository.GetProductsAsync(productsId);
                }

                if (supply.Supplier != null)
                {
                    newSupply.Supplier = await _supplyRepository.GetSupplierAsync(supply.Supplier.CompanyName); ;
                }

                if (supply.Client != null)
                {
                    newSupply.Client = await _supplyRepository.GetClientAsync(supply.Client.CompanyName);
                }


                var result = await _supplyRepository.UpdateSupplyAsync(supply);
                return await Task.FromResult(result);
            }
            return null;
        }

        public async Task<bool> DeleteSupply(int Id)
        {
            var supply = await _supplyRepository.GetSupplyByIdAsync(Id);

            if (supply != null)
            {
                var result = await _supplyRepository.DeleteSupplyAsync(supply);
                return true;
            }

            return false;
        }
    }
}
