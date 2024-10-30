using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agriculture_BussinessObjects.Models
{
    public class AgricultureProduct
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? Description { get; set; }

        public string? Thumbnail { get; set; }

        // Foreign key cho Category
        public int? CategoryId { get; set; }

        // Navigation property - Liên kết tới bảng AgricultureCategory
        public AgricultureCategory? Category { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
