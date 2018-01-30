using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.Model;
using System.Web.Security;

namespace AIYunNet.CMS.Web.Areas.SysAdmin.Controllers
{
    public class SysAdminController : BaseController
    {
        //
        // GET: /SysAdmin/SysAdmin/

        public ActionResult Index()
        {

            return View();
        }

        #region 系统用户管理
        public ActionResult ListSysUsers()
        {
            SysAdminUserService sysAdminService = new SysAdminUserService();
            ViewBag.SysUserList = sysAdminService.GetSysUserList();
            return View();
        }

        [HttpGet]
        public ActionResult AddOrEditSysUser(int userID)
        {
            SysAdminUserService sysAdminService = new SysAdminUserService();
            SysAdminUser sysUser = sysAdminService.GetSysUserByID(userID);
            if (sysUser == null)
            {
                sysUser = new SysAdminUser();
            }
            WebCompanyService webCompanyService = new WebCompanyService();
            List<WebCompany> companyList = webCompanyService.GetWebCompanyList();
            IEnumerable<SelectListItem> companys = companyList.Select(com => new SelectListItem { Value = com.CompanyID.ToString(), Text = com.CompanyName });
            List<SelectListItem> companyItemList = companys.ToList();
            companyItemList.Insert(0, new SelectListItem { Value = "0", Text = "------------" });
            ViewBag.Companys = companyItemList;

            IList<SelectListItem> roleTypes = new List<SelectListItem>();
            roleTypes.Add(new SelectListItem() { Value = "1", Text = "超级管理员" });
            roleTypes.Add(new SelectListItem() { Value = "2", Text = "一般用户" });
            ViewBag.RoleTypes = roleTypes;
            return View(sysUser);
        }

        [HttpPost]
        public JsonResult AddOrEditSysUser(SysAdminUser sysUser)
        {
            SysAdminUserService userService = new SysAdminUserService();
            WebCompanyService webCompanyService = new WebCompanyService();
            int companyID = sysUser.CompanyID != null ? (int)sysUser.CompanyID : 0;
            WebCompany company = webCompanyService.GetWebCompanyByID(companyID);
            if (company != null)
            {
                sysUser.CompanyName = company.CompanyName;
            }
            int result = 0;
            if (sysUser.UserID > 0)
            {
                result = userService.UpdateAdminUser(sysUser);
            }
            else
            {
                sysUser.UserPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(sysUser.UserPassword, "md5");
                result = userService.AddAdminUser(sysUser);
            }
            return Json(new { RetCode = result });
        }
        #endregion

    }
}
