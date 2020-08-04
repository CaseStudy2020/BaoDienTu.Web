using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaoDienTu.Web.Models.Category
{
    public class CreateCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Message { get; set; }
    }
}
