using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaoDienTu.Web.ViewModel
{
    public class CreatePostViewModel
    {
        public string Link { get; set; }
        public string AuthorId { get; set; }
        public string Thumbnail { get; set; }
        public int SubCategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
       
    }
}
