using Agriculture_BussinessObjects.Models;
using Agriculture_Daos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agriculture_Repositories
{
    public interface IAgricultureCategoryRepo
    {

        public bool AddAgricultureCategory(AgricultureCategory agricultureCategory);


        public AgricultureCategory GetAgricultureCategory(int id);

        public List<AgricultureCategory> GetAllAgricultureCategories();

        public bool UpdateAgricultureProduct(AgricultureCategory agricultureCategory);

        public bool DeleteAgricultureCategory(int id);
    }
}
