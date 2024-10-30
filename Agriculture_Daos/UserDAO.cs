using Agriculture_BussinessObjects.Models;
using Agriculture_Daos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Agriculture_Daos
{
    public class UserDAO
    {
        private AgricultureManagementContext userContext;
        private static UserDAO instance;
        public static UserDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDAO();
                }
                return instance;
            }
        }

        public UserDAO()
        {
            userContext = new AgricultureManagementContext();
        }

        // Thêm người dùng
        public bool AddUser(User user)
        {
            bool isSuccess = false;
            try
            {
                userContext.Users.Add(user);
                userContext.SaveChanges();
                isSuccess = true;
            }
            finally
            {
                // handle any cleanup if needed
            }
            return isSuccess;
        }

        // Lấy người dùng theo email
        public User GetUser(string email)
        {
            return userContext.Users.SingleOrDefault(x => x.Email.Equals(email));
        }

        // Lấy người dùng theo id
        public User GetUser(int id)
        {
            return userContext.Users.FirstOrDefault(x => x.UserId == id);
        }

        // Lấy tất cả người dùng
        public List<User> GetAllUsers()
        {
            return userContext.Users.ToList();
        }

        // Cập nhật người dùng
        public bool UpdateUser(User user)
        {
            bool isSuccess = false;
            try
            {
                userContext.Users.Update(user);
                userContext.SaveChanges();
                isSuccess = true;
            }
            finally
            {
                // handle any cleanup if needed
            }
            return isSuccess;
        }

        // Xóa người dùng
        public bool DeleteUser(int id)
        {
            bool isSuccess = false;
            try
            {
                var user = GetUser(id);
                if (user != null)
                {
                    userContext.Users.Remove(user);
                    userContext.SaveChanges();
                    isSuccess = true;
                }
            }
            finally
            {
                // handle any cleanup if needed
            }
            return isSuccess;
        }


    }
}
