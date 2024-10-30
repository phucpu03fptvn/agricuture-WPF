using Agriculture_BussinessObjects.Models;
using Agriculture_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agriculture_Services
{
    public class UserRoleService : IUserRoleService
    {
        public IUserRoleRepo _repo;
        public UserRoleService()
        {
            _repo = new UserRoleRepo(); 
        }
        public bool AddUserRole(UserRole userRole) => _repo.AddUserRole(userRole);

        public bool DeleteUserRole(int id) => _repo.DeleteUserRole(id);

        public List<UserRole> GetAllUserRoles() => _repo.GetAllUserRoles();

        public UserRole GetUserRole(int id) => GetUserRole(id);

        public bool UpdateUserRole(UserRole userRole) => _repo.UpdateUserRole(userRole);
    }
}
