﻿using ProductStockTracking.Business.Abstract;
using ProductStockTracking.Core.CrossCuttingConcerns.Security.Web;
using ProductStockTracking.Core.Utilities.Results;
using ProductStockTracking.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProductStockTracking.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        private IUserRoleService _userRoleService ;
        private IRoleService _roleService ;

        public AccountController(IUserService userService, IUserRoleService userRoleService, IRoleService roleService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
            _roleService = roleService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginViewModel model )
        {
            TempData["Message"] = null;
            FormsAuthentication.SignOut();
            if (HttpContext.Response.Cookies[FormsAuthentication.FormsCookieName] != null)
                HttpContext.Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddDays(-1);

            //var saveuser = new Entities.Concrete.User() { FirstName = "Mahsun", LastName = "Emrem", Email = "mahsunemrem@gmail.com", Password = "mahsun", UserName = "mahsun",State=true ,ForgotEmailId=Guid.NewGuid() };
            //var saverole = new Entities.Concrete.Role() { Name = "Admin" };
            //_userService.Add(saveuser);
            //_roleService.Add(saverole);

            //_userRoleService.Add(new Entities.Concrete.UserRole() { RoleId = 1, UserId = 1, });

            var result = _userService.GetByUserNameAndPassword(model.Username,model.Password);

            var user =result.Data ;
            if (user != null)
            {
                AuthenticationHelper.CreateAuthCookie(
                new Guid(), user.UserName,
                user.Email,
                DateTime.Now.AddDays(15),
                _userRoleService.GetList(c => c.UserId== user.Id).Data.Select(u => u.Role.Name).ToArray(),
                model.RememberMe,
                user.FirstName,
                user.LastName);
                return Redirect("/Home/Index");
            }

            ViewBag.Message = result.Message;

            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();  
            if (HttpContext.Response.Cookies[FormsAuthentication.FormsCookieName] != null)
                HttpContext.Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddDays(-1);

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult ForgotPassword(string uniqueId)
        {
            var result=_userService.ExistEmailUniqueCode(uniqueId);
            if (result.Success)
            {
                var user = new UserForgotPasswordViewModel() { UniqueId = Guid.Parse(uniqueId) };
                return View(user);
            }

            throw new Exception();

        }
        [HttpPost]
        public ActionResult ForgotPassword(UserForgotPasswordViewModel model)
        {


            if (model.Password!=model.AgainPasswword || String.IsNullOrEmpty(model.Password) || String.IsNullOrEmpty(model.AgainPasswword))
            {
                ViewBag.Message = "Lütfen Şifreleri doğru bir şekilde giriniz ";
                return View(model);
            }
            var user = _userService.GetList(c => c.ForgotEmailId == model.UniqueId).Data.FirstOrDefault();
            user.Password = model.Password;
            var result =_userService.UpdatePassword(user);
            if (result.Success)
            {
                TempData["NewPasswordMessage"] = "Şifreniz başarıyla değiştirildi";
                return RedirectToAction("Login");
            }

            ViewBag.Message = "Mail gönderirken hata oluştu";
            return View(model);

        }

        public ActionResult SendForgotPasswordEmail(string email)
        {
            

            try
            {
                var result =_userService.SendForgotPasswordEmail(email);
              
                if (result.Success)
                {
                    var resStr = Newtonsoft.Json.JsonConvert.SerializeObject(new SuccessResult());

                    return Json(resStr);
                }

                else
                {
                    var resStr = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                  
                    return Json(resStr);
                }

            }
            catch (Exception)
            {
                var resStr = Newtonsoft.Json.JsonConvert.SerializeObject(new ErrorResult("Email gönderirken hata oluştu."));
                return Json(resStr);
            }
        }
        public ActionResult Error()
        {

            //var Message = Server.GetLastError();

            //ViewBag.Message = Message.Message;
            return View();
        }
    }
}