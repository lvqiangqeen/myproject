using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.IO;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.Web.Areas.SysAdmin.Controllers
{
    public class AppWorkerController : BaseController
    {
        WebBuidingContractService conSer = new WebBuidingContractService();

        // GET: SysAdmin/AppWorker
        public ActionResult WebBuidingConstractList()
        {
            List<WebBuidingContract> list = new List<WebBuidingContract>();
            list = conSer.GetContractList();
            ViewBag.list = list;
            return View();
        }

        public ActionResult updateWebBuidingConstract(string guid)
        {
            WebBuidingContract model = conSer.GetContractByGuid(guid);
            return View(model);
        }
        [HttpPost]
        public JsonResult updateIspass(string guid,int IsPass)
        {
            int ret = 0;
            ret = conSer.updateIsPass(guid, IsPass);
            return Json(new { RetCode = ret });
        }
        [HttpPost]
        public JsonResult deleteContract(string guid)
        {
            int ret = 0;
            ret = conSer.DeleteContract(guid);
            return Json(new { RetCode = ret });
        }
    }
}