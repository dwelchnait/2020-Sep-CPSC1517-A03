using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Aditional Namespaces
using NorthwindSystem.Entities;
using NorthwindSystem.DAL;
using System.Data.SqlClient; //needed for SqlParameter
#endregion

namespace NorthwindSystem.BLL
{
    public class ProductController
    {
        //lookup all records
        public List<Product> Product_ListAll()
        {
            using (var context = new NorthwindSystemContext())
            {
                return context.Products.ToList();
            }
        }

        //lookup by primary key
        public Product Product_FindByID(int productid)
        {
            using (var context = new NorthwindSystemContext())
            {
                return context.Products.Find(productid);
            }
        }

        //lookup using an non primary key field
        public List<Product> Product_GetByPartialProductName(string productname)
        {
            using (var context = new NorthwindSystemContext())
            {
                IEnumerable<Product> results = context.Database.SqlQuery<Product>(
                    "Products_GetByPartialProductName @PartialName",
                    new SqlParameter("PartialName", productname));
                return results.ToList();
            }
        }
    }
}
