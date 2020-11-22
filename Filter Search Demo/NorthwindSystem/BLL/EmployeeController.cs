using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthwindSystem.Entities;
using NorthwindSystem.DAL;
using System.Data.SqlClient;
#endregion

namespace NorthwindSystem.BLL
{
    public class EmployeeController
    {
        public List<EmployeeOfTerritory> Employee_GetByTerritory(string territoryid)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<EmployeeOfTerritory> results =
                    context.Database.SqlQuery<EmployeeOfTerritory>("Employees_GetByTerritory @TerritoryID",
                                    new SqlParameter("TerritoryID", territoryid));
                return results.ToList();
            }
        }
    }
}
