using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.Model;
using Newtonsoft.Json;

namespace AIYunNet.CMS.Web.Areas.SysAdmin.Controllers
{
    public class LookupController : BaseController
    {
        IWebCommon webCommonService = new WebCommonService();

        ///<summary>
        ///类别分组
        ///</summary>
        public ActionResult LookupList()
        {
            //类别分组
            List<string> loouplist = webCommonService.GetLookupGroupNameList();
            ViewBag.loouplist = loouplist;
            return View();
        }
        ///<summary>
        ///根据名称获取所有类别
        ///</summary>
        public ActionResult GetLookUpListByGroupName(string groupName)
        {
            List<WebLookup> list = webCommonService.GetLookupList(groupName);
            return Json(new { list = list}, "text/html");
        }
        ///<summary>
        ///删除类别信息
        ///</summary>
        public ActionResult DeleteLookup(string id)
        {
            int RetCode=webCommonService.DeleteLookup(Convert.ToInt32(id));
            return Json(new { RetCode = RetCode }, JsonRequestBehavior.AllowGet);
        }
        ///<summary>
        ///添加修改类别信息
        ///</summary>
        [HttpPost]
        public ActionResult AddLookup(WebLookup webLookup)
        {
            int result = 0;
            if (webLookup != null && webLookup.LookupID > 0)
            {
                result = webCommonService.UpdateLookup(webLookup);
            }
            else
            {
                result = webCommonService.AddLookup(webLookup);
            }
            return Json(new { RetCode = result }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddLookup(string id)
        {
            //类别分组
            List<string> loouplist = webCommonService.GetLookupGroupNameList();
            IEnumerable<SelectListItem> loouplist1 = loouplist.Select(com => new SelectListItem { Value = com.ToString(), Text = com });
            ViewBag.grouplist = loouplist1;

            WebLookup weblookup = webCommonService.GetLookup(Convert.ToInt32(id));
            return View(weblookup);
        }
    }
}