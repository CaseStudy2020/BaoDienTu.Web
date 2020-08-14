using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaoDienTu.Web.Ultilities;
using BaoDienTu.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BaoDienTu.Web.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult WritePost()
            {
            var writePost = new CreatePostViewModel();
            return View(writePost);
        }
        [HttpPost]
        [Route("author/author/savepost")]
        public IActionResult SavePost([FromBody] CreatePostViewModel model)
        {
            var result = new ResultPostViewModel();
            result = ApiHelper<ResultPostViewModel>.HttpPostAsync(AuthorHelper.APIcreatePost, model);
            return Json(new { result });
        }
    }
}
