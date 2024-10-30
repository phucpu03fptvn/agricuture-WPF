using Agriculture_BussinessObjects.Models;
using Agriculture_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agriculture_Services
{
    public class AgricultureCategoryService : IAgricultureCategoryService
    {
        private IAgricultureCategoryRepo _repo;
        public AgricultureCategoryService()
        {
            _repo = new AgricultureCategoryRepo();
        }
        public bool AddAgricultureCategory(AgricultureCategory agricultureCategory) => _repo.AddAgricultureCategory(agricultureCategory);

        public bool DeleteAgricultureCategory(int id) => _repo.DeleteAgricultureCategory(id);

        public AgricultureCategory GetAgricultureCategory(int id) => _repo.GetAgricultureCategory(id);

        public List<AgricultureCategory> GetAllAgricultureCategories() => _repo.GetAllAgricultureCategories();

        public bool UpdateAgricultureProduct(AgricultureCategory agricultureCategory) => _repo.UpdateAgricultureProduct(agricultureCategory);
    }
}
