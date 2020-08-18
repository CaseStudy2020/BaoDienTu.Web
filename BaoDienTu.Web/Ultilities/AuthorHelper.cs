using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaoDienTu.Web.Ultilities
{
    public  static class AuthorHelper
    {
        public static string APIcreatePost = Helper.ApiUrl + "api/post/create";
        public static string APIupdatePost = Helper.ApiUrl + "api/post/update";
        public static string APIdeletePost = Helper.ApiUrl + "api/post/delete/";
        public static string APIgetListCategory = Helper.ApiUrl + "api/category/gets";
        public static string APIgetListSubCategory = Helper.ApiUrl + "api/subcategory/getsubbycategoryid/";
    }
}
