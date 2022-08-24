using Ecommerce.Model;
using Ecommerce.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Core.IServices
{
    public interface IProductServices
    {
        Task<Product> GetProductById(string id);
        bool SaveProduct();
        Task<List<ProductDisplayDTO>> FirstSixBestSales();
        Task<List<ProductDisplayDTO>> FirstThreeBestSales();
        Task<List<ProductDisplayDTO>> NewSales();
    }
}