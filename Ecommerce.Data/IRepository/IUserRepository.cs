using Ecommerce.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Data.IRepository
{
    public interface IUserRepository
    {
        Task<List<User>> Login();
        Task<bool> Register(User user);
        List<User> AllUser { get; set; }
    }
}