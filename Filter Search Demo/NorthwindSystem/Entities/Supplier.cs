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
    [Table("Suppliers")]
    public class Supplier
    {
        private string _ContactName;
        private string _ContactTitle;
        private string _Address;
        private string _City;
        private string _Region;
        private string _PostalCode;
        private string _Country;
        private string _Phone;
        private string _Fax;
        private string _HomePageTitle;
        private string _HomePageUrl;

        [Key]
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        //public string ContactName { get; set; }
        //public string ContactTitle { get; set; }
        //public string Address { get; set; }
        //public string City { get; set; }
        //public string Region { get; set; }
        //public string PostalCode { get; set; }
        //public string Country { get; set; }
        //public string Phone { get; set; }
        //public string Fax { get; set; }
        //public string HomePageTitle { get; set; }
        //public string HomePageUrl { get; set; }
        public string ContactName
        {
            get { return _ContactName; }
            set { _ContactName = string.IsNullOrEmpty(value) ? null : value.Trim(); }
        }
        public string ContactTitle
        {
            get { return _ContactTitle; }
            set { _ContactTitle = string.IsNullOrEmpty(value) ? null : value.Trim(); }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = string.IsNullOrEmpty(value) ? null : value.Trim(); }
        }
        public string City
        {
            get { return _City; }
            set { _City = string.IsNullOrEmpty(value) ? null : value.Trim(); }
        }
        public string Region
        {
            get { return _Region; }
            set { _Region = string.IsNullOrEmpty(value) ? null : value.Trim(); }
        }
        public string PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = string.IsNullOrEmpty(value) ? null : value.Trim(); }
        }
        public string Country
        {
            get { return _Country; }
            set { _Country = string.IsNullOrEmpty(value) ? null : value.Trim(); }
        }
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = string.IsNullOrEmpty(value) ? null : value.Trim(); }
        }
        public string Fax
        {
            get { return _Fax; }
            set { _Fax = string.IsNullOrEmpty(value) ? null : value.Trim(); }
        }
        public string HomePageTitle
        {
            get { return _HomePageTitle; }
            set { _HomePageTitle = string.IsNullOrEmpty(value) ? null : value.Trim(); }
        }
        public string HomePageUrl
        {
            get { return _HomePageUrl; }
            set { _HomePageUrl = string.IsNullOrEmpty(value) ? null : value.Trim(); }
        }

    }
}
