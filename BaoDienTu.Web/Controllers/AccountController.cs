using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaoDienTu.Web.Models.Account;
using BaoDienTu.Web.Ultilities;
using Microsoft.AspNetCore.Mvc;

namespace BaoDienTu.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = new LoginResult();
                var loginRequest = new LoginRequest()
                {
                    Email = model.Email,
                    Password = model.Password
                };
                result = ApiHelper<LoginResult>.HttpPostAsync(
                                                        $"{Helper.ApiUrl}api/account/login",
                                                        loginRequest
                                                    );
                if (result.Success)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attemp");
                    if (!string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                }
            }
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var registerRequest = new RegisterRequest()
                {
                    Email = model.Email,
                    Password = model.Password,
                    ConfirmPassword=model.ConfirmPassword,
                    Address=model.Address,
                    Avatar=model.Avatar,
                    DoB=model.DoB,
                    FullName=model.FullName,
                    Gender=model.Gender,
                    PhoneNumber=model.PhoneNumber
                };
                var result = new RegisterResult();
                result = result = ApiHelper<RegisterResult>.HttpPostAsync(
                                                        $"{Helper.ApiUrl}api/account/register",
                                                        registerRequest
                                                    );
                if (result.Success)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", result.Message);
                return View();
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            var result = true;
            return Json(new { result });
        }
    }
}
