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
using BaoDienTu.Web.Models.SearchContent;

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

        [Route("/Home/GetsTop5LastestPost")]
        public JsonResult GetsTop5LastestPost()
        {
            var lastestpost = new List<Top5LastestPost>();
            lastestpost = ApiHelper<List<Top5LastestPost>>.HttpGetAsync($"{Helper.ApiUrl}api/post/GetsTop5LastestPost");
            return Json(new { lastestpost });
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
        public IActionResult GetsCategory()
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
      
        [Route("/Home/CreatePost")]
        public JsonResult Create([FromBody] CreatePost model)
        {
            var post = new CreatePostResult();
            post = ApiHelper<CreatePostResult>.HttpGetAsync($"{Helper.ApiUrl}api/post/create");
            return Json(new { post });
        }
        [Route("/Home/UpdatePost")]
        public JsonResult Update([FromBody] UpdatePost model)
        {
            var updatePost = new UpdatePostResult();
            updatePost = ApiHelper<UpdatePostResult>.HttpGetAsync($"{Helper.ApiUrl}api/post/update");
            return Json(new { updatePost });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("Home/Search")]           
        public IActionResult Search(string moviename)
        {
            var post = new List<SearchPost>();
            post = ApiHelper<List<SearchPost>>.HttpGetAsync($"{Helper.ApiUrl}api/post/search/{moviename}");
            var searchresult = new List<SearchPost>();        
            if (post != null)
            {
                ViewBag.Ten = post;
                ViewBag.Keyword = moviename;

                foreach (var item in post)
                {
                    if (item.Title.ToLower().Contains(moviename))
                    {
                        searchresult.Add(item);                  
                    }
                }
                return View(searchresult);
            }
            return View("~/Home/Index");

        }

        [Route("Home/SearchContent")]
        public IActionResult SearchContent(string moviename)
        {
            var post = new List<SearchContent>();
            post = ApiHelper<List<SearchContent>>.HttpGetAsync($"{Helper.ApiUrl}api/post/searchcontent/{moviename}");
            var searchresult = new List<SearchContent>();
            if (post != null)
            {
                ViewBag.Key = moviename;             
                foreach (var item in post)
                {
                    if (item.Title.ToLower().Contains(moviename))
                    {
                        searchresult.Add(item);
                    }
                }
                return View(searchresult);
            }
            return View("~/Home/Index");
        }

        [Route("Home/SearchDate")]
        public IActionResult SearchDate(string moviename)
        {
            var post = new List<SearchDate>();
            post = ApiHelper<List<SearchDate>>.HttpGetAsync($"{Helper.ApiUrl}api/post/searchdate/{moviename}");
            var searchresult = new List<SearchDate>();
            if (post != null)
            {
                ViewBag.Date = moviename;
               
                foreach (var item in post)
                {
                    if (item.Title.ToLower().Contains(moviename))
                    {
                        searchresult.Add(item);
                    }
                }
                return View(searchresult);
            }
            return View("~/Home/Index");
        }

    }

}
