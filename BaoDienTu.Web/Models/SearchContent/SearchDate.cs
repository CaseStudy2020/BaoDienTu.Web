﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BaoDienTu.Web.Models.SearchContent
{
    public class SearchDate
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [DataType(DataType.Date)]
        public string DateCreated { get; set; }
        public string Thumbnail { get; set; }
    }
}
