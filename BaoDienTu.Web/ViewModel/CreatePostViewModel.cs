using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BaoDienTu.Web.ViewModel
{
    public class CreatePostViewModel
    {
        [Required]
        public string AuthorId { get; set; }
        public string Thumbnail { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int SubCategoryId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
       
    }
}
