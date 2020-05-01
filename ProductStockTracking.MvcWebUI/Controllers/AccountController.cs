using ProductStockTracking.Business.Abstract;
using ProductStockTracking.Core.CrossCuttingConcerns.Security.Web;
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
            FormsAuthentication.SignOut();
            if (HttpContext.Response.Cookies[FormsAuthentication.FormsCookieName] != null)
                HttpContext.Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddDays(-1);

            var saveuser = new Entities.Concrete.User() { FirstName = "Mahsun", LastName = "Emrem", Email = "mahsunemrem@gmail.com", Password = "mahsun", UserName = "mahsun",State=true ,ForgotEmailId=Guid.NewGuid() };
            //var saverole = new Entities.Concrete.Role() { Name = "Admin" };
            _userService.Add(saveuser);
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


            return View(new UserForgotPasswordViewModel());
        }
        [HttpPost]
        public ActionResult ForgotPassword(UserForgotPasswordViewModel model)
        {

            

            return View();
        }
        public ActionResult Error()
        {

            //var Message = Server.GetLastError();

            //ViewBag.Message = Message.Message;
            return View();
        }
    }
}