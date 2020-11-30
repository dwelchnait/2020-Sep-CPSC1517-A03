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
    [Table("Categories")]
    public class Category
    {
        private string _Description;
        private string _PictureMimeType;
        [Key]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(15, ErrorMessage = "Category name is limited to 15 characters")]
        public string CategoryName { get; set; }

        public string Description
        {
            get { return _Description; }
            set { _Description = string.IsNullOrEmpty(value) ? null : value; }
        }

        public byte[] Picture { get; set; }

        public string PictureMimeType
        {
            get { return _PictureMimeType; }
            set { _PictureMimeType = string.IsNullOrEmpty(value) ? null : value; }
        }
    }
}
