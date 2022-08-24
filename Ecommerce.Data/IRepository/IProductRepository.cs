using Ecommerce.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Data.IRepository
{
    public interface IProductRepository
    {
        List<Product> AllProducts { get; set; }

        Task<List<Product>> GetAllProductAsync();
        bool SaveProduct();
    }
}