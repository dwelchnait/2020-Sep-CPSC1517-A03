using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindSystem.Views
{
    //Views are NOT table entities
    //View data classes do NOT need annotations
    //View data classes do NOT get DbSet<T> properties in your
    //      context class
    //View data classes can be used in your BLL controller and
    //      your web pages as a Plain Ordinary Common Object (POCOs)
    public class ProductsInCategories
    {
        private string _QuantityPerUnit;
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit
        {
            get { return _QuantityPerUnit; }
            set { _QuantityPerUnit = string.IsNullOrEmpty(value) ? null : value; }
        }
        public Int16? UnitsInStock { get; set; }
        public bool Discontinued { get; set; }

    }
}
