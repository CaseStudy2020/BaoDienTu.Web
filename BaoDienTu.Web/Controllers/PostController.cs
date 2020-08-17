using BaoDienTu.Web.Models.Post;
using BaoDienTu.Web.Ultilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaoDienTu.Web.Controllers
{
    public class PostController:Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Index Post";
            return View();
        } 
        public JsonResult Gets()
        {
            var post = new List<PostView>();
            post = ApiHelper<List<PostView>>.HttpGetAsync($"{Helper.ApiUrl}/post/gets");
            return Json(new { post });
        }
        [Route("/api/post/GetTop10MostViewOfDay")]
        public JsonResult GetTop10MostViewOfDay()
        {
            var post = new List<Top10MostViewOfDay>();
            post = ApiHelper<List<Top10MostViewOfDay>>.HttpGetAsync($"{Helper.ApiUrl}post/GetTop10MostViewOfDay");
            return Json(new { post });
        }
       public JsonResult Save([FromBody] PostView save)
        {
            var post = new SavePostResult();
            post = ApiHelper<SavePostResult>.HttpPostAsync($"{Helper.ApiUrl}post/save", save);
            return Json(new { post });
        }
        public JsonResult Update([FromBody] PostView update)
        {
            var post = new UpdatePostResult();
            post = ApiHelper<UpdatePostResult>.HttpPostAsync($"{Helper.ApiUrl}post/update", update);
            return Json(new { post });
        }
        public JsonResult Get(int id)
        {
            var post = new PostView();
            post = ApiHelper<PostView>.HttpGetAsync($"{Helper.ApiUrl}post/get");
            return Json(new { post });
        }
        public JsonResult GetsTop5LastestPost()
        {
            var post = new Top5LastestPost();
            post = ApiHelper<Top5LastestPost>.HttpGetAsync($"{Helper.ApiUrl}post/GetsTop5LastestPost");
            return Json(new { post });
        }
        [HttpGet]
        public IActionResult PostByCategory(int categoryId)
        {
            var postByCateId = new List<PostByCategoryId>();
            postByCateId = ApiHelper<List<PostByCategoryId>>.HttpGetAsync($"{Helper.ApiUrl}api/post/getByCategoryId/{categoryId}");
            return View(postByCateId);
        }
        [HttpGet]
        
        public IActionResult PostBySubCategory(int subCategoryId)
        {
            var postBySubId = new List<PostBySubCategoryId>();
            postBySubId = ApiHelper<List<PostBySubCategoryId>>.HttpGetAsync($"{Helper.ApiUrl}api/post/getBySubCategoryId/{subCategoryId}");
            return View(postBySubId);
        }
        [HttpGet]
        
        public IActionResult PostDetail(int id)
        {
            var postById = new PostView();
            postById = ApiHelper<PostView>.HttpGetAsync($"{Helper.ApiUrl}api/post/get/{id}");
            if (postById != null)
            {
                ViewBag.PostId = postById;
            }
            return View();

        }
    }
}
