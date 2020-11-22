using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthwindSystem.Entities;

using NorthwindSystem.DAL;
#endregion 

namespace NorthwindSystem.BLL
{
    public class SupplierController
    {
        public List<Supplier> Supplier_List()
        {
            //need to connect to the Context class
            //this connection will be done in a transaction coding group
            using (var context = new NorthwindContext())
            {
                //via EnityFrame, make a request for all records,
                //all attributes from the specified DbSet property
                return context.Suppliers.ToList();
            }
        }

        public List<SupplierCategories> Suppliers_GetCategories(int suppilerid)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<SupplierCategories> results =
                    context.Database.SqlQuery<SupplierCategories>("Suppliers_GetCategories @SupplierID",
                                    new SqlParameter("SupplierID", suppilerid));
                return results.ToList();
            }
        }
    }
}
