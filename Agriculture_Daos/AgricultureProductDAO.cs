using Agriculture_BussinessObjects.Models;
using Agriculture_Daos.Data;
using Agriculture_Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agriculture_Daos
{
    public class AgricultureProductDAO
    {

        private AgricultureManagementContext agricultureManagementContext;
        private static AgricultureProductDAO instance;
        public static AgricultureProductDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AgricultureProductDAO();
                }
                return instance;
            }
        }

        public AgricultureProductDAO()
        {
            agricultureManagementContext = new AgricultureManagementContext();
        }

        public bool AddAgricultureProduct(AgricultureProduct agricultureProduct)
        {
            bool isSuccess = false;
            try
            {
                agricultureManagementContext.AgricultureProducts.Add(agricultureProduct);
                agricultureManagementContext.SaveChanges();
                isSuccess = true;
            }
            finally
            {

            }
            return isSuccess;
        }

        public AgricultureProduct GetAgricultureProduct(int id)
        {
            try
            {
                var product = agricultureManagementContext.AgricultureProducts.FirstOrDefault(x => x.ProductId == id);

                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<AgricultureProductDTO> GetAllAgricultureProducts()
        {
            var products = from p in agricultureManagementContext.AgricultureProducts
                           join c in agricultureManagementContext.AgricultureCategories on p.CategoryId equals c.CategoryId
                           select new AgricultureProductDTO
                           {
                               ProductId = p.ProductId,
                               ProductName = p.ProductName,
                               Price = p.Price,
                               StockQuantity = p.StockQuantity,
                               Description = p.Description,
                               CategoryName = c.CategoryName, // Chỉ lấy CategoryName
                               Thumbnail = p.Thumbnail
                           };

            return products.ToList();
        }

        public bool UpdateAgricultureProduct(AgricultureProduct agricultureProduct)
    {
        bool isSuccess = false;
        try
        {
            agricultureManagementContext.AgricultureProducts.Update(agricultureProduct);
            agricultureManagementContext.SaveChanges();
            isSuccess = true;
        }
        finally
        {

        }
        return isSuccess;
    }

    public bool DeleteAgricultureProduct(int id)
    {
        bool isSuccess = false;
        try
        {
            agricultureManagementContext.AgricultureProducts.Remove(GetAgricultureProduct(id));
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
