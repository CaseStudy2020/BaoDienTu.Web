using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BaoDienTu.Web.Models.Post
{
    public class Top10MostViewOfDay
    {
        public int PostId { get; set; }
        [Display(Name = "Tiêu Đề")]
        public string Title { get; set; }
        [Display(Name ="Ngày Tạo")]
        public string DateCreated { get; set; }
        [Display(Name = "Số lượng bình luận ")]
        public int NumberOfComment { get; set; }
        [Display(Name ="Ảnh Nhỏ")]
        public string Thumbnail { get; set; }
        [Display(Name = "Lượt Xem")]
        public int View { get; set; }
        [Display(Name = "Nội dung ngắn")]
        public string ShortContent { get; set; }
        [Display(Name ="Lượt Thích")]
        public int Like { get; set; }

    }
}
