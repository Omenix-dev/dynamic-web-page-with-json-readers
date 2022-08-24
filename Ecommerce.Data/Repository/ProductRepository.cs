using Ecommerce.Model;
using System.IO;
using Ecommerce.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.Data.IRepository;

namespace Ecommerce.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        readonly string _dataLocation = Path.Combine($"{new DirectoryInfo(".").Parent}", "Ecommerce.Data");
        private List<Product> _allProducts = new List<Product>();
        public List<Product> AllProducts
        {
            get { return _allProducts; }
            set { _allProducts = value; }
        }
        public async Task<List<Product>> GetAllProductAsync()
        {
            string fileLocation = Path.Combine(_dataLocation, "Product.json");
            AllProducts = await FileHandler.Reader<List<Product>>(fileLocation);
            return AllProducts;
        }
        public bool SaveProduct()
        {
            string fileLocation = Path.Combine(_dataLocation, "Product.json");
            try
            {
                FileHandler.Writer(fileLocation, AllProducts);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
