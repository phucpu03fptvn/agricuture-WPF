using Agriculture_BussinessObjects.Models;
using Agriculture_Daos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agriculture_Daos
{
    public class AgricultureCategoryDAO
    {
        private AgricultureManagementContext agricultureManagementContext;
        private static AgricultureCategoryDAO instance;
        public static AgricultureCategoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AgricultureCategoryDAO();
                }
                return instance;
            }
        }


        public AgricultureCategoryDAO()
        {
            agricultureManagementContext = new AgricultureManagementContext();
        }

        public bool AddAgricultureCategory(AgricultureCategory agricultureCategory)
        {
            bool isSuccess = false;
            try
            {
                agricultureManagementContext.AgricultureCategories.Add(agricultureCategory);
                agricultureManagementContext.SaveChanges();
                isSuccess = true;
            }
            finally
            {

            }
            return isSuccess;
        }

        public AgricultureCategory GetAgricultureCategory(int id)
        {
            try
            {
                var category = agricultureManagementContext.AgricultureCategories.FirstOrDefault(x => x.CategoryId == id);

                return category;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<AgricultureCategory> GetAllAgricultureCategories() => agricultureManagementContext.AgricultureCategories.ToList();

        public bool UpdateAgricultureProduct(AgricultureCategory agricultureCategory)
        {
            bool isSuccess = false;
            try
            {
                agricultureManagementContext.AgricultureCategories.Update(agricultureCategory);
                agricultureManagementContext.SaveChanges();
                isSuccess = true;
            }
            finally
            {

            }
            return isSuccess;
        }

        public bool DeleteAgricultureCategory(int id)
        {
            bool isSuccess = false;
            try
            {
                agricultureManagementContext.AgricultureCategories.Remove(GetAgricultureCategory(id));
                agricultureManagementContext.SaveChanges();
                isSuccess = true;
            }
            finally
            {

            }
            return isSuccess;
        }
    }
}
