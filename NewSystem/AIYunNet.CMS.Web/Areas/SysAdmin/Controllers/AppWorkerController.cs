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
        WebBuidingCaseService buidingcase = new WebBuidingCaseService();
        WebWorkerService workerSer = new WebWorkerService();
        WebCaseService caSer = new WebCaseService();

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

        public ActionResult buidingcaseList()
        {
            List<WebBuidingCase> list = buidingcase.GetBuidingCaseList();
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public JsonResult deleteCase(int id)
        {
            int ret = 0;
            ret = buidingcase.deleteBuidingCase(id);
            return Json(new { RetCode = ret });
        }
        [HttpGet]
        public ActionResult updateAndaddbuidingcase(int id=0)
        {
            WebBuidingCase model = new WebBuidingCase();

            List<WebWorker> workerlist = new List<WebWorker>();
            workerlist = workerSer.GetWebWorkerList();
            IEnumerable<SelectListItem> list= workerlist.Select(com => new SelectListItem { Value = com.WorkerID.ToString(), Text = com.WorkerName });
            ViewBag.workerlist = list;

            if (id == 0)
            {

            }else
            {
                model= buidingcase.GetBuidingCaseByID(id);
                
            }
   
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AddOrEditBuidingCase(WebBuidingCase webca)
        {
            WebWorker worker = workerSer.GetWebWorkerByID(webca.WorkerID);
            int ret = 0;

            string[] list = null;
            string thum = "";
            if (webca.textimg==""|| webca.textimg == null)
            {

            }else
            {
                list = ImageHelper.GetHvtImgUrls(webca.textimg);
                foreach (string item in list)
                {
                    thum += item + "|";
                }
                webca.textthumbnailImage = thum;
                
            }
            webca.UserID = worker.UserID;
            if (webca.id == 0)
            {
                ret = buidingcase.addBuidingCase(webca);
            }
            else
            {
                ret = buidingcase.updateBuidingCase(webca);
            }
            return Json(new { RetCode = ret });
        }
    }
}