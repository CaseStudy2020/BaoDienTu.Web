using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaoDienTu.Web.Models.SubCategory
{
    public class SubByCategoryId
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
        public string Message { get; set; }
    }
}
