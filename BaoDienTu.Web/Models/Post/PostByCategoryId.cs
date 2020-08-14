using BaoDienTu.Web.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaoDienTu.Web.Models.Post
{
    public class PostByCategoryId
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Like { get; set; }
        public string Link { get; set; }
        public Status Status { get; set; }
        public int CategoryId { get; set; }
        public int PostHashTagId { get; set; }
        public string AuthorId { get; set; }
        public int SubCategoryId { get; set; }
        public int View { get; set; }
        public string DateCreated { get; set; }
        public decimal AverageRate { get; set; }
        public string Thumbnail { get; set; }
    }
}

