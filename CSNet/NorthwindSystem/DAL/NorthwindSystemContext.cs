using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity;
using NorthwindSystem.Entities;
#endregion

namespace NorthwindSystem.DAL
{
    //connect this class to the EntityFramework by inheriting DbContext
    //  which is within the System.Data.Entity library
    //we want to restrict access to this class to ONLY other classes int
    //  the same project. Therefore the access is internal
    internal class NorthwindSystemContext : DbContext
    {
        //you will need a constructor that passes the connection
        //      string name to EntityFramework via the inherited
        //      DbContext class
        public NorthwindSystemContext() : base("NWDB")
        {
            //default constructor
        }

        //properties to interact with EntityFramework
        //these properties represent the whole table and all
        //      data of the sql database
        public  DbSet<Product> Products { get; set; }
        public DbSet<Region> Regions { get; set; }
    }
}
