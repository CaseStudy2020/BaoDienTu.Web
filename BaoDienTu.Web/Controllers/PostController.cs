using BaoDienTu.Web.Models.Catagory;
using BaoDienTu.Web.Models.Post;
using BaoDienTu.Web.Models.SubCategory;
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


            var postByCateId = new List<PostByCategoryId>();
            postByCateId = ApiHelper<List<PostByCategoryId>>.HttpGetAsync($"{Helper.ApiUrl}api/post/getByCategoryId/{categoryId}");
            return View(postByCateId);
        }
        [HttpGet]
        
        public IActionResult PostBySubCategory(int subCategoryId)
        {
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


            var postBySubId = new List<PostBySubCategoryId>();
            postBySubId = ApiHelper<List<PostBySubCategoryId>>.HttpGetAsync($"{Helper.ApiUrl}api/post/getBySubCategoryId/{subCategoryId}");
            return View(postBySubId);
        }
        [HttpGet]
        
        public IActionResult PostDetail(int id)
        {
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

            var postById = new PostView();
            postById = ApiHelper<PostView>.HttpGetAsync($"{Helper.ApiUrl}api/post/get/{id}");

            var lastestpost = new List<Top5LastestPost>();
            lastestpost = ApiHelper<List<Top5LastestPost>>.HttpGetAsync($"{Helper.ApiUrl}api/post/GetsTop5LastestPost");
            postById.Top5LastestPosts = lastestpost;

            return View(postById);

        }


        public List<SubCategory> GetSubByCategoryId2(int categoryId)
        {
            var subs = new List<SubCategory>();
            subs = ApiHelper<List<SubCategory>>.HttpGetAsync($"{Helper.ApiUrl}api/subcategory/getsubbycategoryid/{categoryId}");
            return subs;
        }
        [Route("/Home/GetsCategory")]
        public JsonResult GetsCategory()
        {
            var categories = new List<CategoryView>();
            categories = ApiHelper<List<CategoryView>>.HttpGetAsync($"{Helper.ApiUrl}api/category/gets");
            return Json(new { categories });
        }
    }
}
