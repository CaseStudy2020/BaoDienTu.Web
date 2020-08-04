using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BaoDienTu.Web.Models;
using BaoDienTu.Web.Models.Post;
using BaoDienTu.Web.Ultilities;
using BaoDienTu.Web.Models.Catagory;

namespace BaoDienTu.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var fastpost = new List<FastInfoPostView>();
            fastpost = ApiHelper<List<FastInfoPostView>>.HttpGetAsync($"{Helper.ApiUrl}api/post/GetsFastInfoPost");
            return View(fastpost);
        }

        [Route("/Home/Gets")]
        public JsonResult Gets()
        {
            var posts = new List<PostView>();
            posts = ApiHelper<List<PostView>>.HttpGetAsync($"{Helper.ApiUrl}api/post/gets");            
            return Json(new { posts });
        }

        [Route("/Home/GetsFastInfoPost")]
        public JsonResult GetsFastInfoPost()
        {
            var fastpost = new List<FastInfoPostView>();
            fastpost = ApiHelper<List<FastInfoPostView>>.HttpGetAsync($"{Helper.ApiUrl}api/post/GetsFastInfoPost");
            return Json(new { fastpost });
        }

        [Route("/Home/Get/{id}")]
        public JsonResult Get(int id)
        {
            var result = new PostView();
            result = ApiHelper<PostView>.HttpGetAsync(
                                                    $"{Helper.ApiUrl}api/post/get/{id}"
                                                );
            return Json(new { result });
        }

        [Route("/Home/GetsCategory")]
        public JsonResult GetsCategory()
        {
            var categories = new List<CategoryView>();
            categories = ApiHelper<List<CategoryView>>.HttpGetAsync($"{Helper.ApiUrl}api/category/gets");
            return Json(new { categories });
        }

        [Route("/Home/GetTop10MostViewOfDay")]
        public JsonResult GetTop10MostViewOfDay()
        {
            var mostviewpost = new List<Top10MostViewOfDay>();
            mostviewpost = ApiHelper<List<Top10MostViewOfDay>>.HttpGetAsync($"{Helper.ApiUrl}api/post/GetTop10MostViewOfDay");
            return Json(new { mostviewpost });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
