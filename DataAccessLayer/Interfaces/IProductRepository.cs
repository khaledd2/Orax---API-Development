using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IProductRepository
    {
        // Create
        Task<Product> AddProductAsync(Product product);

        // Read
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync();

        // Update
        Task<Product> UpdateProductAsync(Product product);

        // Delete
        Task<bool> DeleteProductAsync(int id);
    }
}
