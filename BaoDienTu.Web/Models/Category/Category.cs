using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BaoDienTu.Web.Models.Catagory
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [Display(Name ="Thể Loại")]
        public string CategoryName { get; set; }
        [Display(Name ="Số Lượng")]
        public int SoLuong { get; set; }
    }
}
