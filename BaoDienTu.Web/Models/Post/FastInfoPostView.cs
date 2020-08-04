using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaoDienTu.Web.Models.Post
{
    public class FastInfoPostView
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string DateCreated { get; set; }
        public int NumberOfComment { get; set; }
        public string Thumbnail { get; set; }

    }
}
