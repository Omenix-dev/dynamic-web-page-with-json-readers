using Ecommerce.Data.IRepository;
using System.Threading.Tasks;
using Ecommerce.Model;
using Ecommerce.Core.IServices;
using EasyEncryption;
using System.Linq;

namespace Ecommerce.Core.Services
{
	public class UserServices : IUserServices
	{
		private readonly IUserRepository _repository;
		public UserServices(IUserRepository productRepo)
		{
			_repository = productRepo;
		}
		/// <summary>
		/// Registers the uswer to the back end
		/// returns an awaitable 
		/// </summary>
		/// <param name="email"></param>
		/// <param name="password"></param>
		/// <returns>Task<User></returns>
		public async Task<User> RegisterUser(string email,string password)
		{
			User newUser = new User(email,SHA.ComputeSHA256Hash(password));
			bool IsRegistered = await _repository.Register(newUser);
			if (IsRegistered)
			{
				return newUser;
			}
			return null;
		}
		/// <summary>
		/// Provides the Logic for the user Login
		/// and awaitable
		/// </summary>
		/// <param name="email"></param>
		/// <param name="password"></param>
		/// <returns>string</returns>
		public async Task<string> Login(string email,string password)
		{
			var allUser = await _repository.Login();
            var user = allUser.FirstOrDefault(x => x.Email == email && x.Password == SHA.ComputeSHA256Hash(password));
            if (user != null)
            {
                return user.UserId;
            }
            return "NOT_FOUND";
		}
	}
}
