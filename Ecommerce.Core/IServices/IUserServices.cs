using Ecommerce.Model;
using System.Threading.Tasks;

namespace Ecommerce.Core.IServices
{
    public interface IUserServices
    {
        Task<string> Login(string email, string password);
        Task<User> RegisterUser(string email, string password);
    }
}