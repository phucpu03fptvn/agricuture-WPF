using Agriculture_BussinessObjects.Models;
using Agriculture_Repositories;
using Agriculture_Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agriculture_Services
{
    public class AgricultureProductService : IAgricultureProductService
    {
        private IAgricultureProductRepo _repo;
        public AgricultureProductService()
        {
            _repo = new AgricultureProductRepo();
        }
        public bool AddAgricultureProduct(AgricultureProduct agricultureProduct) => _repo.AddAgricultureProduct(agricultureProduct);

        public bool DeleteAgricultureProduct(int id) => _repo.DeleteAgricultureProduct(id);

        public AgricultureProduct GetAgricultureProduct(int id) => _repo.GetAgricultureProduct(id);
        public List<AgricultureProductDTO> GetAgricultureProducts() => _repo.GetAgricultureProducts();

        public bool UpdateAgricultureProduct(AgricultureProduct agricultureProduct) => _repo.UpdateAgricultureProduct(agricultureProduct);
    }
}
