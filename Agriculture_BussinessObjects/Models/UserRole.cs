using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agriculture_BussinessObjects.Models
{
    public class UserRole
    {
        [Key]
        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        //Navigation proberty
        public List<User> Users { get; set; } = new List<User>();
    }
}
