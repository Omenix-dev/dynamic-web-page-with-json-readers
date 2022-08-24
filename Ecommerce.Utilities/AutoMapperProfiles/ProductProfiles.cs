using AutoMapper;
using Ecommerce.Model;
using Ecommerce.Model.DTO;

namespace Ecommerce.Utilities.AutoMapperProfiles
{
    public class ProductProfiles: Profile
    {
        public ProductProfiles()
        {
            CreateMap<Product, ProductDisplayDTO>();
        }
    }
}
