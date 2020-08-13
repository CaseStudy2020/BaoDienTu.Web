using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaoDienTu.Web.Models.Category
{
    public class UpdateCategoryResult
    {
        public int CategoryId { get; set; }
        public string Message { get; set; }
        public string CategoryName { get; set; }
    }
}
