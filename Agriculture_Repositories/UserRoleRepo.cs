using Agriculture_BussinessObjects.Models;
using Agriculture_Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agriculture_Repositories
{
    public class UserRoleRepo : IUserRoleRepo
    {

        public bool AddUserRole(UserRole userRole) => UserRoleDAO.Instance.AddUserRole(userRole);

        public bool DeleteUserRole(int id) => UserRoleDAO.Instance.DeleteUserRole(id);

        public List<UserRole> GetAllUserRoles() => UserRoleDAO.Instance.GetAllUserRoles();

        public UserRole GetUserRole(int id) => UserRoleDAO.Instance.GetUserRole(id);

        public bool UpdateUserRole(UserRole userRole) => UserRoleDAO.Instance.UpdateUserRole(userRole);
    }
}
