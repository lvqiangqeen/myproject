using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.Web.Areas.SysAdmin.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /SysAdmin/Account/
        ISysAdminUser sysAdminService = new SysAdminUserService();

        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userAccount, string userPassword)
        {
            string password = FormsAuthentication.HashPasswordForStoringInConfigFile(userPassword, "md5");
            bool exist = sysAdminService.ExistUser(userAccount, password);
            if (exist)
            {
                SysAdminUser adminUser = sysAdminService.GetSysUserByAccount(userAccount, password);
                if (adminUser != null)
                {
                    SessionHelper.SetSession("companyID", adminUser.CompanyID);
                    SessionHelper.SetSession("companyName", adminUser.CompanyName);
                }
                SessionHelper.SetSession("userAccount", userAccount);
                return RedirectToAction("Index", "SysAdmin", new { Area = "SysAdmin" });
            }
            else
            {
                return Redirect("/SysAdmin/Account/Index");
            }
        }

        public ActionResult ChangePassword()
        {
            if (HttpContext.Session["userAccount"] != null)
            {
                string userAccount = SessionHelper.Get("userAccount");
                ViewBag.UserAccount = userAccount;
                return View();
            }
            else
            {
                return Redirect("/SysAdmin/Account/Index");
            }

        }

        public ActionResult ChangedPassword(string UserAccount, string UserPassword, string UserPassword1)
        {
            if (HttpContext.Session["userAccount"] != null)
            {
                int result = 0;
                if (UserPassword == UserPassword1)
                {
                    string password = FormsAuthentication.HashPasswordForStoringInConfigFile(UserPassword, "md5");
                    result = sysAdminService.UpdateAdminUserPassword(UserAccount, password);
                }
                return Json(new { RetCode = result });
            }
            else
            {
                return Redirect("/SysAdmin/Account/Index");
            }

        }


    }
}
