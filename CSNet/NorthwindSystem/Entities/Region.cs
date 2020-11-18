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
    [Table("Region")]
    public class Region
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RegionID { get; set; }

        //if your sql is a char or varchar type then use string as your datatype
        [Required(ErrorMessage ="Region description is required")]
        [StringLength(50,ErrorMessage ="Region Description is limited to 50 characters")]
        public string RegionDescription { get; set; }

        //however if RegionDescription was nullable
        //one would fully implement the property

        //private string _RegionDescription;

        // [StringLength(50,ErrorMessage ="Region Description is limited to 50 characters")]
        //public string RegionDescription
        //{
        //  get{return _RegionDescription;}
        //  set{_RegionDescription = string.IsNullOrEmpty(value) ? null : value;}
        //}  
    }
}
