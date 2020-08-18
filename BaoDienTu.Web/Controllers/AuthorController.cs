using System.Collections.Generic;
using BaoDienTu.Web.Models.Author;
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
        public IActionResult WritePost(){
            
            return View();
        }
        [HttpPost]
        [Route("/author/author/savepost")]
        public IActionResult SavePost([FromBody] CreatePostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = new ResultPostViewModel();
                result = ApiHelper<ResultPostViewModel>.HttpPostAsync(AuthorHelper.APIcreatePost, model);
                return Json(new { result });
            }
            return RedirectToAction("WritePost");
            
        }

        [HttpGet]
        [Route("author/author/GetListCategory")]
        public JsonResult GetListCategory()
        {
            IEnumerable<AuthorCategory> ListCategory = ApiHelper<IEnumerable<AuthorCategory>>.HttpGetAsync(AuthorHelper.APIgetListCategory);
            return Json(new { ListCategory });
        }

        [HttpGet]
        [Route("author/author/GetListSubCategory/{id}")]
        public JsonResult GetListSubCategory(int id)
        {
            string URLToGetListSubCategory = $"{AuthorHelper.APIgetListSubCategory}{id}";
            IEnumerable<AuthorSubCategory> listSubCategory = ApiHelper<IEnumerable<AuthorSubCategory>>.HttpGetAsync(URLToGetListSubCategory);
            return Json(new { listSubCategory });
        }
    }
}
