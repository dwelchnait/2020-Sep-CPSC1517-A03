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
    public class TerritoryController
    {
        public List<Territory> Territory_List()
        {
            //need to connect to the Context class
            //this connection will be done in a transaction coding group
            using (var context = new NorthwindContext())
            {
                //via EnityFrame, make a request for all records,
                //all attributes from the specified DbSet property
                return context.Territories.ToList();
            }
        }

        public Territory Territory_Get(int territoryid)
        {
            //return the record from the database via the DbSet collection
            //where the pkey matches the supplied value
            using (var context = new NorthwindContext())
            {
                return context.Territories.Find(territoryid);
            }
        }

        public List<Territory> Territory_GetByRegion(int regionid)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<Territory> results =
                    context.Database.SqlQuery<Territory>("Territories_GetByRegion @RegionID",
                                    new SqlParameter("RegionID", regionid));
                return results.ToList();
            }
        }
    }
}
