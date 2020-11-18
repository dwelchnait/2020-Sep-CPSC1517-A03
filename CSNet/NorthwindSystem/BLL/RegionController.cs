
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Aditional Namespaces
using NorthwindSystem.Entities;
using NorthwindSystem.DAL;
#endregion

namespace NorthwindSystem.BLL
{
    //this class will be accessed by the web page.
    //the web page is in a separate project
    //therefore this class needs to be public
    public class RegionController
    {
        //the interface is a set of methods that can be 
        //      called by an outside user
        //these methods must be public

        //generally there is two types of lookups
        //a) find a specific record by primary key
        //b) get all records for a specific table

        //lookup by primary key
        public Region Region_FindByID(int regionid)
        {
            //create a section of code that will ensure the sql
            //  connection will be closed when the method
            //  is complete: using(...){...}
            using(var context = new NorthwindSystemContext())
            {
                //there are extension methods within EntityFramework
                //  that allow you to do some very common queries
                //This extension method will allow you to search
                //  your DbSet<T> by primary key value
                return context.Regions.Find(regionid);
            }
        }

        public List<Region> Region_ListAll()
        {
            using (var context = new NorthwindSystemContext())
            {
                //This extension method will allow you to retrieve
                //  all the records of your DbSet<T>
                return context.Regions.ToList();
            }
        }
    }
}
