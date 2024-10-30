using Agriculture_BussinessObjects.Models;
using Agriculture_Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agriculture_Repositories
{
    public class AgricultureCategoryRepo : IAgricultureCategoryRepo
    {
        public bool AddAgricultureCategory(AgricultureCategory agricultureCategory) => AgricultureCategoryDAO.Instance.AddAgricultureCategory(agricultureCategory);

        public bool DeleteAgricultureCategory(int id) => AgricultureCategoryDAO.Instance.DeleteAgricultureCategory(id);

        public AgricultureCategory GetAgricultureCategory(int id) => AgricultureCategoryDAO.Instance.GetAgricultureCategory(id);

        public List<AgricultureCategory> GetAllAgricultureCategories() => AgricultureCategoryDAO.Instance.GetAllAgricultureCategories();

        public bool UpdateAgricultureProduct(AgricultureCategory agricultureCategory) => AgricultureCategoryDAO.Instance.UpdateAgricultureProduct(agricultureCategory);
    }
}
