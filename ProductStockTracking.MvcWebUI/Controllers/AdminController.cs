using ProductStockTracking.Business.Abstract;
using ProductStockTracking.Core.Utilities.Results;
using ProductStockTracking.Entities.Concrete;
using ProductStockTracking.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductStockTracking.MvcWebUI.Controllers
{
    public class AdminController : Controller
    {
        private IUserService _userService;
        private IUserRoleService _userRoleService;
        private IRoleService _roleService;

        public AdminController(IUserService userService, IUserRoleService userRoleService, IRoleService roleService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
            _roleService = roleService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            var result = _userService.GetList();
            if (result.Success)
                return View(result.Data);
            return View(new List<User>());
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            
            return View(new User());
        }
        [HttpPost]
        public ActionResult AddUser(User model)
        {

            IResult result;
            if (model.Id == 0)
                result = _userService.Add(model);
            else
                result = _userService.Update(model);

            if (result.Success)
                return RedirectToAction("/Users");

            ViewBag.ErrorMessage = result.Message;


            return View(model);
        }
        [HttpGet]
        public ActionResult UpdateUser(int id)
        {

            var result = _userService.GetById(id);
            if (result.Success)
            {
                return View(result.Data);
            }
    

            return View(new User());
        }
        [HttpPost]
        public ActionResult UpdateUser(User model)
        {

            IResult result;            
            result = _userService.Update(model);

            if (result.Success)
                return RedirectToAction("/Users");

            ViewBag.ErrorMessage = result.Message;


            return View(model);
        }
        public ActionResult DelteUser()
        {
            return View();
        }


        #region User-Region Operations

        #endregion User-Region Operations
        public ActionResult UserRoleOperations()
        {       

            var userRoles = _userService.GetList().Data;    

            return View(userRoles);
        }

        [HttpPost]
        public ActionResult SetUserRoles(int userId, int roleId)
        {
            var result = _userRoleService.GetList(c => c.UserId == userId && c.RoleId == roleId);
            string resStr = Newtonsoft.Json.JsonConvert.SerializeObject(new { isSuccess = true });

            if (result.Success)
            {
                var userRole = result.Data.FirstOrDefault();
                if (userRole != null)
                {
                    _userRoleService.Delete(userRole);
                }
                else
                {
                    _userRoleService.Add(new UserRole
                    {
                        RoleId=roleId,
                        UserId=userId,
                        
                    });
                }
                return Json(resStr);

            }
            resStr = Newtonsoft.Json.JsonConvert.SerializeObject(new { isSuccess = false });

            return Json(resStr);

        }

        [HttpPost]
        public ActionResult GetUserRoles(string userId)
        {
            if (userId == "")
                return RedirectToAction("/UserRoleOperations");

            var id = Convert.ToInt32(userId);
            var result = _userRoleService.GetList(c => c.UserId == id);
            var userRoleList = new List<UserRoleViewModel>();
            if (result.Success)
            {
                foreach (var userRole in result.Data)
                {
                    var userRoleViewModel = new UserRoleViewModel() { Id = userRole.Id, RoleId = userRole.RoleId, UserId = userRole.UserId };
                    userRoleList.Add(userRoleViewModel);
                }
            }
                
            string resStr = Newtonsoft.Json.JsonConvert.SerializeObject(new { isSuccess = true, data = userRoleList });

            return Json(resStr);

        }

    }
}