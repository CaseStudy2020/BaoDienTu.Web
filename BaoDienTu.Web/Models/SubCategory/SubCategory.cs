using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BaoDienTu.Web.Models.SubCategory
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        [Required]
        [Display(Name= "Tên Danh Mục")]
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
    }
}
