using Agriculture_BussinessObjects.Models;
using Agriculture_Daos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agriculture_Daos
{
    public class UserRoleDAO
    {
        private AgricultureManagementContext agricultureManagementContext;
        private static UserRoleDAO instance;

        public static UserRoleDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserRoleDAO();
                }
                return instance;
            }
        }

        public UserRoleDAO()
        {
            agricultureManagementContext = new AgricultureManagementContext();
        }

        public bool AddUserRole(UserRole userRole)
        {
            bool isSuccess = false;
            try
            {
                agricultureManagementContext.Roles.Add(userRole);
                agricultureManagementContext.SaveChanges();
                isSuccess = true;
            }
            finally
            {
                // handle any cleanup if needed
            }
            return isSuccess;
        }

        public UserRole GetUserRole(int id)
        {
            try
            {
                var role = agricultureManagementContext.Roles.FirstOrDefault(x => x.RoleId == id);
                return role;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<UserRole> GetAllUserRoles() => agricultureManagementContext.Roles.ToList();

        public bool UpdateUserRole(UserRole userRole)
        {
            bool isSuccess = false;
            try
            {
                agricultureManagementContext.Roles.Update(userRole);
                agricultureManagementContext.SaveChanges();
                isSuccess = true;
            }
            finally
            {
                // handle any cleanup if needed
            }
            return isSuccess;
        }

        public bool DeleteUserRole(int id)
        {
            bool isSuccess = false;
            try
            {
                agricultureManagementContext.Roles.Remove(GetUserRole(id));
                agricultureManagementContext.SaveChanges();
                isSuccess = true;
            }
            finally
            {
                // handle any cleanup if needed
            }
            return isSuccess;
        }
    }

}
