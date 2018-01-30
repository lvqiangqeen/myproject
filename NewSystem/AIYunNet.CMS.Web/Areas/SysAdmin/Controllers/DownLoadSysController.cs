using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.Web.Areas.SysAdmin.Controllers
{
    public class DownLoadSysController : Controller
    {
        // GET: SysAdmin/DownLoadSys
        WebCommonService webCommSer = new WebCommonService();
        DownLoadService downloadSer = new DownLoadService();
        public ActionResult DownloadList()
        {
            List<WebLookup> looklist = webCommSer.GetLookupList("DownLoad_type");
            ViewBag.looklist = looklist;

            return View();
        }

        ///<summary>
        ///根据id获取所有类别
        ///</summary>
        public ActionResult GetDownloadtypelist(int lookupid)
        {
            List<DownLoadType> list = downloadSer.GetDownLoadTypeOne(lookupid);
            return Json(new { list = list });
        }
        ///<summary>
        ///根据firstid获取所有类别
        ///</summary>
        public ActionResult GetDownloadtypetwolist(int firstid)
        {
            List<DownLoadType> list = downloadSer.GetDownLoadTypeTwo(firstid);
            return Json(new { list = list });
        }
        ///<summary>
        ///获取下载列表
        ///</summary>
        public ActionResult getDownLoadList(int lookupid,int firstid)
        {
            List<DownLoad> list = downloadSer.GetDownLoadListByLookupAndfistid(lookupid, firstid);
            return Json(new { list = list });
        }

        [HttpGet]
        public ActionResult DownloadSysDetail(int id)
        {
            DownLoad download = downloadSer.GetDownLoadDetail(id);
            if (download == null)
            {
                download = new DownLoad();
            }
            //lookuplist
            List<WebLookup> looklist = webCommSer.GetLookupList("DownLoad_type");
            IEnumerable<SelectListItem> IEnumlooklist = looklist.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });
            ViewBag.looklist = IEnumlooklist;
            //firsttype
            List<DownLoadType> DownLoadTypelist = new List<DownLoadType>();
            if (download.LookupCode != 0)
            {
                DownLoadTypelist = downloadSer.GetDownLoadTypeOne(download.LookupCode);
                ViewBag.DownLoadTypelist = DownLoadTypelist.Select(com => new SelectListItem { Value = com.id.ToString(), Text = com.name });
            }
            else
            {
                ViewBag.DownLoadTypelist = DownLoadTypelist;
            }
            //secondtype
            List<DownLoadType> DownLoadTypeTowlist = new List<DownLoadType>();
            if (download.firstID != 0)
            {
                DownLoadTypeTowlist = downloadSer.GetDownLoadTypeTwo(download.firstID);
                ViewBag.DownLoadTypeTowlist = DownLoadTypeTowlist.Select(com => new SelectListItem { Value = com.id.ToString(), Text = com.name });
            }
            else
            {
                ViewBag.DownLoadTypeTowlist = DownLoadTypeTowlist;
            }

            return View(download);
        }

        [HttpPost]
        public ActionResult DownloadSysDetail(DownLoad download)
        {
            int result = 0;
            if (download != null && download.ID > 0)
            {
                //修改
                result = downloadSer.UpdateDownLoad(download);
            }
            else
            {
                //添加
                result = downloadSer.AddDownLoad(download);
            }
            return Json(new { retCode = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult deleteDownload(int id)
        {
            int ret=downloadSer.DeleteDownLoad(id);
            return Json(new { retCode = ret }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Downloadtype()
        {
            List<WebLookup> looklist = webCommSer.GetLookupList("DownLoad_type");
            ViewBag.looklist = looklist;
            return View();
        }
        public ActionResult deleteDownloadtype(int id)
        {
            int ret = downloadSer.DeleteDownLoadtype(id);
            return Json(new { retCode = ret }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult addDownloadtype(string name,int fatherid,int looupid)
        {
            DownLoadType type = new DownLoadType();
            type.fatherID = fatherid;
            type.LookupID = looupid;
            type.name = name;
            int ret = downloadSer.addDownLoadtype(type);
            return Json(new { retCode = ret }, JsonRequestBehavior.AllowGet);
        }
    }
}