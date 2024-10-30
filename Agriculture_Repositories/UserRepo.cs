using Agriculture_BussinessObjects.Models;
using Agriculture_Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agriculture_Repositories
{
    public class UserRepo : IUserRepo
    {
        public bool AddUser(User user) => UserDAO.Instance.AddUser(user);

        public bool DeleteUser(int id) => UserDAO.Instance.DeleteUser(id);

        public List<User> GetAllUsers() => UserDAO.Instance.GetAllUsers();

        public User GetUser(string email) => UserDAO.Instance.GetUser(email);

        public User GetUser(int id) => UserDAO.Instance.GetUser(id);

        public bool UpdateUser(User user) => UserDAO.Instance.UpdateUser(user);
    }
}
