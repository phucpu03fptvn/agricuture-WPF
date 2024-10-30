using Agriculture_BussinessObjects.Models;
using Agriculture_Daos;
using Agriculture_Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agriculture_Repositories
{
    public class AgricultureProductRepo : IAgricultureProductRepo
    {
        public bool AddAgricultureProduct(AgricultureProduct agricultureProduct) => AgricultureProductDAO.Instance.AddAgricultureProduct(agricultureProduct);

        public bool DeleteAgricultureProduct(int id) => AgricultureProductDAO.Instance.DeleteAgricultureProduct(id);

        public AgricultureProduct GetAgricultureProduct(int id) => AgricultureProductDAO.Instance.GetAgricultureProduct(id);

        public List<AgricultureProductDTO> GetAgricultureProducts() => AgricultureProductDAO.Instance.GetAllAgricultureProducts();

        public bool UpdateAgricultureProduct(AgricultureProduct agricultureProduct) => AgricultureProductDAO.Instance.UpdateAgricultureProduct(agricultureProduct);
    }
}
