using Agriculture_BussinessObjects.Models;
using Agriculture_Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agriculture_Services
{
    public interface IAgricultureProductService
    {
        public bool AddAgricultureProduct(AgricultureProduct agricultureProduct);
        public AgricultureProduct GetAgricultureProduct(int id);

        public List<AgricultureProductDTO> GetAgricultureProducts();

        public bool UpdateAgricultureProduct(AgricultureProduct agricultureProduct);

        public bool DeleteAgricultureProduct(int id);
    }
}
