using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity; //inheritance of DbContext from EntityFramework
using NorthwindSystem.Entities; //points to the data definitions of the entities
#endregion

namespace NorthwindSystem.DAL
{
    //security enhancement using access priviledge: internal
    //restricts the acces to this class to calls from within this project

        //this class needs to be "tied" into EntityFramework
        //this will be done by inheriting the class DbContext
    internal class NorthwindContext:DbContext
    {
        //this class needs to supply DbContent with the application's
        //   connection string name
        //this name is supplied to DbContext using the constructor
        //   of this class
        public NorthwindContext():base("NWDB")
        {

        }

        //we need properties in this class that will be used by
        //    EntityFramework to transport the data into your application
        //each entity wil lhave their own "transportation set"

        //the coding standard for this course will be plural for
        //   the DbSet<T> property names
        public DbSet<Product> Products { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Territory> Territories { get; set; }
    }
}
