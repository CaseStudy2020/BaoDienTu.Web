﻿using System;
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
using BaoDienTu.Web.Models.SubCategory;

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
            var categories = new List<Category>();
            categories = ApiHelper<List<Category>>.HttpGetAsync($"{Helper.ApiUrl}api/category/gets");
            ViewBag.Categories = categories;

            List<ListSubByCategoryId> listSub = new List<ListSubByCategoryId>();
            for (int i = 0; i < categories.Count; i++)
            {
                ListSubByCategoryId listsub = new ListSubByCategoryId();
                listsub.allSub = GetSubByCategoryId2(categories[i].CategoryId);
                listSub.Add(listsub);
            }
            ViewBag.ListSubByCategoryId = listSub;


            List<ListTop3Post> listTop3Post = new List<ListTop3Post>();
            for(int i = 0; i < categories.Count; i++)
            {
                ListTop3Post top3post = new ListTop3Post();
                top3post.Top3 = GetsTop3PostByCategoryId(categories[i].CategoryId);
                listTop3Post.Add(top3post);
            }
            ViewBag.ListTop3PostByCategoryId = listTop3Post;
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
        [Route("/Home/getByCategoryId/{categoryId}")]
        public JsonResult GetPostByCategoryId(int categoryId)
        {
            var postByCateId = new List<PostByCategoryId>();
            postByCateId = ApiHelper<List<PostByCategoryId>>.HttpGetAsync($"{Helper.ApiUrl}api/post/getByCategoryId/{categoryId}");
            return Json(new { postByCateId });
        }
        [Route("/Home/GetsTop3LastestPostByCategoryId/{categoryId}")]
        public JsonResult GetsTop3LastestPostByCategoryId(int categoryId)
        {
            var post3ByCateId = new List<Top3LastestPostByCategoryId>();
            post3ByCateId = ApiHelper<List<Top3LastestPostByCategoryId>>.HttpGetAsync($"{Helper.ApiUrl}api/post/getTop3LastestPostByCategoryId/{categoryId}");
            return Json(new { post3ByCateId });
        }
        public List<Top3LastestPostByCategoryId> GetsTop3PostByCategoryId(int categoryId)
        {
            var post3ByCateId = new List<Top3LastestPostByCategoryId>();
            post3ByCateId = ApiHelper<List<Top3LastestPostByCategoryId>>.HttpGetAsync($"{Helper.ApiUrl}api/post/getTop3LastestPostByCategoryId/{categoryId}");
            return post3ByCateId;
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
        [Route("/Home/GetsSubCategory")]
        public JsonResult GetsSubCategory()
        {
            var subcategories = new List<SubCategoryView>();
            subcategories = ApiHelper<List<SubCategoryView>>.HttpGetAsync($"{Helper.ApiUrl}api/subcategory/gets");
            return Json(new { subcategories });
        }
        public JsonResult GetSubByCategoryId(int categoryId)
        {
            var subs = new List<SubCategory>();
            subs = ApiHelper<List<SubCategory>>.HttpGetAsync($"{Helper.ApiUrl}api/subcategory/getsubbycategoryid/{categoryId}");
            return Json(new { subs });
        }
        public List<SubCategory> GetSubByCategoryId2(int categoryId)
        {
            var subs = new List<SubCategory>();
            subs = ApiHelper<List<SubCategory>>.HttpGetAsync($"{Helper.ApiUrl}api/subcategory/getsubbycategoryid/{categoryId}");
            return subs;
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
    }
}
