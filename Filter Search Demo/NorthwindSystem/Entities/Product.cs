using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace NorthwindSystem.Entities
{
    //all entity or data classes in this course will be singular in name
    //all classes by default are private, change to public

    //an annotation that will point this class to the appropriate
    //   sql table is needed in front of the class header
    // an annotation is [annotation]
    //syntax [Table("mysqltablename"[,Schema="sqlschemaname"])]
    //sometimes your sql database will de divided into groups:
    //   these groups are called schemas
    //   you can recongize a schema on a table by the name it is
    //       using: ie. HumanResources.Employees
    //IF your database does NOT have schemas then you OMIT the schema
    //    attribute from your annotation
    //the creation of this class is called MAPPING. You are supplying
    //    a definition of the sql table to your application

    [Table("Products")]
    public class Product
    {
        //all sql attributes will  have a corresponding class property
        //IF you use the attribute name as your property name
        //    the phyiscal order of the properties do NOT nedd to 
        //    match the sql attribute order

        //you need a [Key] annotation for your primary key field
        //use [Key] on an identity pkey field (default)
        //can also be coded as [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //used [Key, Column(Order=n)] for compound primary keys where
        //    n represents the PHYSICAL order of the components
        //    n starts at 1 (natural number)
        //use [Key, DataGenerated(DataGeneratedOption.None)] for
        //    primary keys that are NOT compound OR they are user supplied (NOT Identity)

        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        //  [ForeignKey]  DO NOT USE
        //This is optional 
        //use this annotation ONLY IF your foreign key
        //    sql field name is NOT the same as the associated 
        //    primary key field name OR if you use a different
        //    name in your mapping
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public Int16? UnitsInStock { get; set; }
        public Int16? UnitsOnOrder { get; set; }
        public Int16? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        //optionally add your constructors (default and greedy)

        //other annotation examples
        //computed field does exist on the database
        //this field does NOT expect data from the user nor does
        //EntityFramework expect data to be pass to this sql attribute

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public decimal Total { get; set; }

        //Read-only application property
        //lets assume you would like to concatenate some fields together
        //   within your application ons several occasions such as
        //   creating a full name out of two attributes like FirstName and LastName

        //these read-only properties are NON Mapped fields
        //they do NOT exist on the sql table
        //EntityFramework as not expected to be supplied data nor will it
        //   supply data for the property
        [NotMapped]
        public string ProductandID
        {
            get
            {
                return ProductName + "(" + ProductID + ")";
            }
        }
    }
}
