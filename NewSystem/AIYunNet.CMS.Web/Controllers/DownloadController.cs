using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.Common.Utility.Model;
using AIYunNet.CMS.Web.filter;
using AIYunNet.CMS.Common.Utility;

namespace AIYunNet.CMS.Web.Controllers
{
    public class DownloadController : Controller
    {
        //
        // GET: /Download/
        WebCommonService commSer = new WebCommonService();
        DownLoadService DownSer = new DownLoadService();
        WebUserService UerSer = new WebUserService();
        WebCompanyUserService comSer = new WebCompanyUserService();
        WebCompanyService webComSer = new WebCompanyService();
        WebPeopleService WebPeoSer = new WebPeopleService();
        

        public ActionResult DownLoadDetail(int id=0)
        {
            DownLoad model=DownSer.GetDownLoadDetail(id);
            List<DownLoad> list = DownSer.GetDownLoadList(model.firstID);
            ViewBag.list = list;
            if (model.userid != 0)
            {
                if (model.usertype == "WebCompanyUser")
                {
                    WebCompany webCompany = webComSer.GetWebCompanyByUserID(model.userid);
                    ViewBag.webCompany = webCompany;
                }
                else if (model.usertype == "WebUser")
                {
                    WebPeople webpeople = WebPeoSer.GetWebPeopleByUserID(model.userid);
                    ViewBag.webpeople = webpeople;
                }
            }
            return View(model);
        }

        public ActionResult DownLoadList(int LookupID = 1)
        {
            List<WebLookup> list = commSer.GetLookupList("DownLoad_type");
            ViewBag.list = list;
            return View();
        }
        //获取所有类型（页面左侧）
        public ActionResult typelist(int LookupID = 1)
        {
            List<DownloadTypeList> list = DownSer.GetDownloadTypeListByLookupID(LookupID);
            return Json(list);
        }

        public ActionResult DownLoadSth(string url)
        {
            string filePath = Server.MapPath("~") + url;
            long speed = 5000000;
            DownLoadHelper.DownloadFile(HttpContext, filePath, speed);
            return View();
        }
    }
}
