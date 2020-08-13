using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaoDienTu.Web.ViewModel
{
    public class CreatePostViewModel
    {
        public string title { get; set; }
        public string content { get; set; }
        public string link { get; set; }
        public string authorId { get; set; }
        public string thumbnail { get; set; }
        public int averageRate { get; set; }
    }
}
