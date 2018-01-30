using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.BLL.IService;


namespace AIYunNet.CMS.Web.Controllers
{
    public class MessageController : Controller
    {
        //NetCms.BLL.WebMessage webMessageService = new NetCms.BLL.WebMessage();
        //
        // GET: /Message/

        public ActionResult Index()
        {
            return View("Add");
        }

        public ActionResult Add() {
            return View();
        }

        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult Add(WebMessage model) {
        //    model.InTime = DateTime.Now.ToLocalTime();
        //    int flag= webMessageService.Add(model);
        //    if (flag == 1)
        //    {
        //        ViewBag.Status = "留言提交成功，请耐心等待回复";
        //    }
        //    else {
        //        ViewBag.Status = "留言提交失败，请重新填写";
        //    }
        //    return View();
        //}

    }
}
