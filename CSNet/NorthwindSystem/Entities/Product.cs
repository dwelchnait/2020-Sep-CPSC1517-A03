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
    //annotations are use to assist EntityFramework in the mapping
    //      of your class to the sql table

    // annotations for properties are placed BEFORE the property!!!!!

    [Table("Products")]
    public class Product
    {
        //private data member
        private string _QuantityPerUnit;

        //if you use the same name as the sql attribute
        //      for your property name, order of the prooperties
        //      does not matter
        //if your name are different then order is required

        //[Key] single attribute primary identity key
        //[Key, Column(Order=n)] compount primary key,
        //      required in front of each each property of the key
        //      n represents the PHYISCAL order as found on the sql table
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.xxxx)]
        //      where .xxx -> Identity: primary key on sql is
        //                               an Identity key (default)
        //                 -> None: primary key is NOT Identity, user entered 
        [Key]
        public int ProductID { get; set; }

        //validation annotations (sql constraints and null/not null)

        [Required(ErrorMessage ="Product Name is requried")]
        [StringLength(40, ErrorMessage ="Product Name is limited to 40 characters")]
        public string ProductName { get; set; }

        //foreignkeys
        //these foreign kyes are nullable on the sql table (don't forget the ?)
        //you may be tempted to use the [ForeignKey] annotation
        //          !!!!*****  BUT DON'T  *****!!!!!
        //The [ForeignKey] annotation is ONLY required if the
        //      sql table does not use the same name for it's
        //      foreign key as it's parent primary key
        //OR
        //if your property name does not match the sql attribute name
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }

        //you can use fully implemented properties in mapping
        [StringLength(20, ErrorMessage = "Quantity per unit is limited to 20 characters")]
        public string QuantityPerUnit 
        {  
            get { return _QuantityPerUnit; } 
            set { _QuantityPerUnit = string.IsNullOrEmpty(value) ? null : value; } 
        }

        //money requires the us of decimal, if it complains use double
        //UnitPrice is nullable
        //nullable numerics DO NOT need to be fully implemented
        [Range(0.0, double.MaxValue, ErrorMessage ="Unit Price must be (or more) 0.00")]
        public decimal? UnitPrice { get; set; }

        [Range(0, 32767, ErrorMessage = "Units in Stock must be (or more) 0")]
        public Int16? UnitsInStock { get; set; }

        [Range(0, 32767, ErrorMessage = "Units on Order must be (or more) 0")]
        public Int16? UnitsOnOrder { get; set; }

        [Range(0, 32767, ErrorMessage = "Reorder level must be (or more) 0")]
        public Int16? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
