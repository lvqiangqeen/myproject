using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Domain.OccaModel;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Web.filter;


namespace AIYunNet.CMS.Web.Areas.PeopleCenter.Controllers
{
    [AuthorityFilter]
    public class CenterWorkerController : Controller
    {
        WebWorkerService worSer = new WebWorkerService();
        WebBuidTogetherService TogSer = new WebBuidTogetherService();
        DecDemandAcceptService Deacc = new DecDemandAcceptService();
        WebBuidingService buiSer = new WebBuidingService();
        WebBuidingSingleService SingSer = new WebBuidingSingleService();
        // GET: PeopleCenter/CenterWorker
        #region 选择合作伙伴
        //选择合作工人
        [HttpGet]
        public ActionResult SelectWorker()
        {
            return View();
        }
        [HttpPost]
        public JsonResult WorkerListExceptSelf(int wokerid = 0,string WorkerName="")
        {
            List<WebWorker> list = new List<WebWorker>();
            list = worSer.GetWorkerExceptSelf(wokerid, WorkerName);
            if (list == null)
            {
                list= new List<WebWorker>();
            }
            return Json(new { code=0, msg="", count= list.Count(), data = list });
        }
        [HttpPost]
        public JsonResult SendWorkTogether(WebBuidTogether tog)
        {
            int ret = 0;
            int ishave=TogSer.IsHaveTogther(tog.buidingID, tog.StageID);
            if (ishave == 0)
            {
                ret = TogSer.AddBuidTogether(tog);
            }        
            return Json(new { RetCode = ret });
        }
        #endregion

        #region 合作项目清单
        [HttpGet]
        public ActionResult WorkerTogetherList(int GetWorkerid=0)
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetTogetherList(int GetWorkerid = 0,int IsAccept=0,bool IsAll=false)
        {
            List<BuidTogether> list = TogSer.GetTogetherList(GetWorkerid, IsAccept, IsAll);
            return Json(new { code = 0, msg = "", count = list.Count(), data = list });
        }
        //接受或拒绝
        [HttpPost]
        public JsonResult IsAcceptTogether(int id,int accept)
        {
            int ret = 0;
            ret= TogSer.IsAccept(id, accept);
            return Json(new { RetCode = ret });
        }
        #endregion

        #region 发给工人的需求
        [HttpGet]
        public ActionResult DemandListToWorker()
        {
            return View();
        }

        [HttpPost]
        public JsonResult DemandListToWorker(int GetUserID, int PageSize, int CurPage)
        {
            List<AcceptDemand> list = Deacc.GetDemandListByUserID(GetUserID, PageSize, CurPage);
            return Json(new { code = 0, msg = "", count = list.Count(), data = list });
        }
        //工人发布流程
        [HttpGet]
        public ActionResult AddOrEditBuidingToWorker(int DemandID)
        {
            IWebCommon commonService = new WebCommonService();
            List<WebLookup> commonworkPosition = commonService.GetLookupList("Buiding_process");
            IEnumerable<SelectListItem> workPositionList = commonworkPosition.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });
            ViewBag.workPositionList = workPositionList;

            WebBuiding buidling = buiSer.GetWebBuidingByDemandID(DemandID);

            if (buidling == null)
            {
                buidling = new WebBuiding();
            }
            return View(buidling);
        }
        #endregion
    }
}