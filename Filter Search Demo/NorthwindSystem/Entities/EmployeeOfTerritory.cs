using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace NorthwindSystem.Entities
{
    //this is not a database table (entity)
    //this is a definition of a database view, DO NOT create a DbSet<> for this class
    public class EmployeeOfTerritory
    {
        public string TerritoryID { get; set; }
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}
