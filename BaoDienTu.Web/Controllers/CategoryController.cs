using BaoDienTu.Web.Models.Catagory;
using BaoDienTu.Web.Models.Category;
using BaoDienTu.Web.Ultilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaoDienTu.Web.Controllers
{
    public class CategoryController:Controller
    {
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Index Category";
            return View();
        }
        //[Route("/category/gets")]
        [Route("/Category/Gets")]
        public JsonResult Gets()
        {
            var categorys = new List<Category>();
            categorys = ApiHelper<List<Category>>.HttpGetAsync($"{Helper.ApiUrl}api/category/gets");
            return Json(new { categorys });
        }

        //[Route("/Category/Update")]
        //public JsonResult Update([FromBody] UpdateCategory category)
        //{
        //    var result = new UpdateCategoryResult();
        //    result = ApiHelper<UpdateCategoryResult>.HttpPostAsync($"{Helper.ApiUrl}api/category/update",category);
        //    return Json(new { result });
        //}

        [Route("/category/delete/{id}")]
        public JsonResult Delete(int id)
        {
            var categorys = new DeleteCategoryResult();
            categorys = ApiHelper<DeleteCategoryResult>.HttpGetAsync($"{Helper.ApiUrl}api/category/delete/{id}", "DELETE");
            return Json(new { categorys });
        }

        public JsonResult Create([FromBody] Category category)
        {
            var categorys = new CreateCategoryResult();
            categorys = ApiHelper<CreateCategoryResult>.HttpPostAsync(
                                                   $"{Helper.ApiUrl}api/category/create",
                                                   category
                                               );
            return Json(new { categorys });
        }
        [Route("category/get/{id}")]
        public JsonResult Get(int id)
        {
            var categorys = new CategoryView();
            categorys = ApiHelper<CategoryView>.HttpGetAsync($"{Helper.ApiUrl}api/category/get/{id}");
            return Json(new { categorys });
        }
    }
}
