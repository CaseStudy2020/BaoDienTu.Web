using BaoDienTu.Web.Models.Catagory;
using BaoDienTu.Web.Models.Category;
using BaoDienTu.Web.Models.SubCategory;
using BaoDienTu.Web.Ultilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaoDienTu.Web.Controllers
{
    public class SubCategoryController:Controller
    {
        private readonly ILogger<SubCategoryController> _logger;

        public SubCategoryController(ILogger<SubCategoryController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index(int id)
        {
            ViewBag.Title = "Index SubCategory";
            var subs = new CategoryView();
            subs = ApiHelper<CategoryView>.HttpGetAsync($"{Helper.ApiUrl}api/category/get/{id}");
            if(subs != null)
            {
                ViewBag.SubCategory = subs;
            }       
            return View();
        }
        public JsonResult GetPostByCategoryId(int id)
        {
            var subs = new List<SubCategory>();
            subs = ApiHelper<List<SubCategory>>.HttpGetAsync($"{Helper.ApiUrl}api/subcategory/getpostbycategoryId/{id}");
            return Json(new { subs });
        }

        [Route("subcategory/get/{id}")]
        public JsonResult Get(int id)
        {
            var subs = new SubCategory();
            subs = ApiHelper<SubCategory>.HttpGetAsync($"{Helper.ApiUrl}api/subcategory/get/{id}");
            return Json(new { subs });
        }
    
        public JsonResult Create([FromBody] SubCategory subCategory)
        {
            var subs = new CreateCategoryResult();
            subs = ApiHelper<CreateCategoryResult>.HttpPostAsync($"{Helper.ApiUrl}api/subcategory/create", subCategory);
            return Json(new { subs });
        }
        [Route("subcategory/delete/{id}")]
        public JsonResult Delete(int id)
        {
            var subs = new DeleteSubCategoryResult();
            subs = ApiHelper<DeleteSubCategoryResult>.HttpGetAsync($"{Helper.ApiUrl}api/subcategory/delete/{id}", "DELETE");
            return Json(new { subs });
        }
        [Route("/subcategory/update/{id}")]
        public JsonResult Update([FromBody] SubCategory update)
        {

            var subs = new UpdateSubCategoryResult();
            subs = ApiHelper<UpdateSubCategoryResult>.HttpPostAsync($"{Helper.ApiUrl}api/subcategory/update", update);
            return Json(new { subs });
        }
    }
}
