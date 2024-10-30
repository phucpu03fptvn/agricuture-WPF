using Agriculture_BussinessObjects.Models;
using Agriculture_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agriculture_Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService()
        {
            _userRepo = new UserRepo();
        }

        public bool AddUser(User user) => _userRepo.AddUser(user);

        public bool DeleteUser(int id) => _userRepo.DeleteUser(id);

        public List<User> GetAllUsers() => _userRepo.GetAllUsers();

        public User GetUser(string email) => _userRepo.GetUser(email);

        public User GetUser(int id) => _userRepo.GetUser(id);

        public bool UpdateUser(User user) => _userRepo.UpdateUser(user);
    }

}
