using WebServer.Data.Models;
using WebServer.Data.DTO;
using WebServer.Data.Repositories;
using System.Collections.Generic;

namespace WebServer.Data.Services
{
    public class ProductService
    {
        private ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository) => _productRepository = productRepository;
        public async Task<Product?> AddProduct(ProductDTO product)
        {
            Product newProduct = new Product()
            {
                ProductName = product.ProductName,
                Number = product.Number,
                Brand = product.Brand,
                Color = product.Color,
                Date = product.Date,
                Price = product.Price,
                Size = product.Size,
                //SupplyId = product.Supply
            };

            var result = await _productRepository.AddProductAsync(newProduct);
            return await Task.FromResult(result);
        }
        
        public async Task<ProductDTO?> GetProductDTO(int Id)
        {   
            var product = await _productRepository.GetProductByIdAsync(Id);
            if (product != null)
            {
                ProductDTO productDTO = new ProductDTO()
                {
                    Id = product.Id,
                    Size = product.Size,
                    Brand = product.Brand,
                    Color = product.Color,
                    Date = product.Date,
                    Number = product.Number,
                    Price = product.Price,
                    ProductName = product.ProductName,
                    SupplyId = product.SupplyId
                };

                productDTO.ClientCompany = await _productRepository.GetClientCompanyByIdProduct(product.SupplyId);

                productDTO.SupplierCompany = await _productRepository.GetSupplierCompanyByIdProduct(product.SupplyId);   

                return await Task.FromResult(productDTO);

            }

            return null;
        }

        public async Task<List<ProductDTO>?> GetAllProductDTO()
        {
            var products = await _productRepository.GetAllProductAsync();

            if (products.Any())
            {
                List<ProductDTO> productDTOs = new List<ProductDTO>();
                foreach (var item in products)
                {
                    ProductDTO productDTO = new ProductDTO()
                    {
                        Id = item.Id,
                        Size = item.Size,
                        Brand = item.Brand,
                        Color = item.Color,
                        Date = item.Date,
                        Number = item.Number,
                        Price = item.Price,
                        ProductName = item.ProductName,
                        SupplyId = item.SupplyId
                    };
                    
                    productDTO.ClientCompany = await _productRepository.GetClientCompanyByIdProduct(item.SupplyId);
                    productDTO.SupplierCompany = await _productRepository.GetSupplierCompanyByIdProduct(item.SupplyId);
                    productDTOs.Add(productDTO);
                }

                return await Task.FromResult(productDTOs);
            }
            return null;
        }

        public async Task<Product?> GetProduct(int Id)
        {
            var result = await _productRepository.GetProductByIdAsync(Id);
            return await Task.FromResult(result);
        }

        public async Task<List<Product>?> GetProducts()
        {
            var result = await _productRepository.GetAllProductAsync();
            return await Task.FromResult(result);
        }

        public async Task<Product?> UpdateProduct(ProductDTO newProduct)
        {
            var product = await _productRepository.GetProductByIdAsync(newProduct.Id);
            if (product != null)
            {
                product.ProductName = newProduct.ProductName;
                product.Brand = newProduct.Brand;
                product.Price = newProduct.Price;
                product.Date = newProduct.Date;
                product.Size = newProduct.Size;
                product.Color = newProduct.Color;
                product.Number = newProduct.Number;
                product.SupplyId = newProduct.SupplyId;

                var result = await _productRepository.UpdateProductAsync(product);
                return await Task.FromResult(result);
            }

            return null;
        }

        public async Task<bool> DeleteProduct(int Id)
        {
            var result = await _productRepository.DeleteProductAsync(Id);

            return await Task.FromResult(result);
        }
    }
}
