using System.Collections.Generic;
using Ecommerce.Model;
using System.IO;
using System.Threading.Tasks;
using Ecommerce.Utilities;
using System.Linq;
using Ecommerce.Data.IRepository;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace Ecommerce.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly string _dataLocation = Path.Combine($"{new DirectoryInfo(".").Parent}", "Ecommerce.Data");
        private List<User> _allUsers = new List<User>();
        public List<User> AllUser { 
            get { return _allUsers; }
            set { _allUsers = value; } 
        }
        /// <summary>
        /// add the user instance to tyhe database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Task<bool></returns>
        public async Task<bool> Register(User user)
        {
            try
            {
                var fileLocation = Path.Combine(_dataLocation, "UserFile.json");
                bool IsExisting;
                AllUser = await FileHandler.Reader<List<User>>(fileLocation);
                if (AllUser == null)
                {
                    AllUser = new List<User>();
                    IsExisting = true;
                }
                else
                {
                    IsExisting = AllUser.Where(x => x.Email == user.Email).Count() <= 0;
                }
                if (IsExisting)
                {
                    AllUser.Add(user);
                    FileHandler.Writer(fileLocation, AllUser);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<User>> Login()
        {
            var fileLocation = Path.Combine(_dataLocation, "UserFile.json");
            AllUser = await FileHandler.Reader<List<User>>(fileLocation);
            return AllUser;
        }
    }
}
