using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agriculture_BussinessObjects.Models
{
    public class AgricultureCategory
    {
        [Key]
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }

        // Navigation property - Liên kết tới danh sách sản phẩm
        public List<AgricultureProduct> Products { get; set; } = new List<AgricultureProduct>();
    }
}
