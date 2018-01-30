using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.Web.Security;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.BLL.IService;
namespace AIYunNet.CMS.Web.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /Member/

        //NetCms.BLL.WebUser bll = new NetCms.BLL.WebUser();
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult Add()
        {
            return View();

        }

        public ActionResult Login() {

            return View();
        }

        //[HttpPost]
        //public ActionResult Login(WebUser model) {
        //    model.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password, "md5");
        //    string strWhere = " UserName='" + model.UserName + "' and Password='" + model.Password + "'";
        //    List<WebUser> list=  bll.GetModelList(strWhere);
        //    if (list.Count > 0)
        //    {
        //        this.HttpContext.Session["username"]= model.UserName;
        //        return View("~/Views/Index/Index.cshtml");
        //    }
        //    else {
        //        return View("no");
        //    }
            
            
        //}

        //[Description("添加会员")]
        //[ValidateInput(false)]
        //[HttpPost]
        //public ActionResult Add(NetCms.Model.WebUser model)
        //{
        //    model.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password, "md5");
        //    model.InTime = DateTime.Now.ToLocalTime();
        //    int flag = bll.Add(model);
        //    if (flag == 1)
        //    {
        //        ViewBag.Status = "注册成功";
        //    }
        //    else {
        //        ViewBag.Status = "注册失败";
            
        //    }

        //   return View();
        //}

    }
}
