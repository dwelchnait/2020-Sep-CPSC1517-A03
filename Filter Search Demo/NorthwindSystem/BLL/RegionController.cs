
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using NorthwindSystem.Entities;
using NorthwindSystem.DAL;
#endregion

namespace NorthwindSystem.BLL
{
    public class RegionController
    {

        #region Filter Search Demo Interface
        public List<Region> Region_List()
        {
            //need to connect to the Context class
            //this connection will be done in a transaction coding group
            using (var context = new NorthwindContext())
            {
                //via EnityFrame, make a request for all records,
                //all attributes from the specified DbSet property
                return context.Regions.ToList();
            }
        }

        public Region Region_Get(int regionid)
        {
            //return the record from the database via the DbSet collection
            //where the pkey matches the supplied value
            using (var context = new NorthwindContext())
            {
                return context.Regions.Find(regionid);
            }
        }
        #endregion
    }
}
