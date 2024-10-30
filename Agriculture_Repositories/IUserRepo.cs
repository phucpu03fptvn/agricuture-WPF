using Agriculture_BussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Agriculture_Repositories
{
    public interface IUserRepo
    {
        User GetUser(string email);
        bool AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
        List<User> GetAllUsers();
        User GetUser(int id);

    }
}
