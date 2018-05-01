using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.Web.filter;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.Common.Utility;

namespace AIYunNet.CMS.Web.Areas.MobileApp.Controllers
{
    public class MoblieBuidingController : Controller
    {
        WebBuidingService buidSer = new WebBuidingService();
        DemandService DemandSer = new DemandService();
        WebBuidingStagesService WebBuidingStagesSer = new WebBuidingStagesService();
        //案例详情
        // GET: MobileApp/MoblieBuiding
        public ActionResult mBuidingDetail(int id)
        {
            WebBuiding buiding = buidSer.GetWebBuidingByID(id);
            DecDemand demand = DemandSer.GetDecDemandByID(buiding.DemandID);
            WebBuidingStages buidingstage = new WebBuidingStages();
            //工人在constructionstageID中只有单个id
            if (buiding.constructionstageID != "" && buiding.constructionstageID != null)
            {
                buidingstage = WebBuidingStagesSer.GetWebBuidingStagesByID(id, Convert.ToInt32(buiding.constructionstageID.Replace(",", "")));
            }
            
            if (buidingstage == null)
            {
                buidingstage = new WebBuidingStages();
            }
            ViewBag.buidingstage = buidingstage;
            ViewBag.demand = demand;
            return View(buiding);
        }
        //装修流程页面
        [MobileUserFilter]
        [HttpGet]
        public ActionResult buidingStage(int DemandID = 0, int BuidingID = 0)
        {
            IWebCommon commonService = new WebCommonService();
            List<WebLookup> commonworkPosition = commonService.GetLookupList("Buiding_process");
            IEnumerable<SelectListItem> workPositionList = commonworkPosition.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });
            ViewBag.workPositionList = workPositionList;

            WebBuiding buidling = buidSer.GetWebBuidingByDemandID(DemandID);
            if (BuidingID != 0 && DemandID == 0)
            {
                buidling = buidSer.GetWebuidingByID(BuidingID);
            }
            if (BuidingID == 0 && DemandID == 0)
            {
                buidling = new WebBuiding();
            }

            if (buidling == null)
            {
                buidling = new WebBuiding();
            }
            return View(buidling);
        }
        [MobileUserFilter]
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AddOrEditBuidingStages(WebBuiding webBuiding)
        {
            WebBuidingService service = new WebBuidingService();
            if (webBuiding.BuidingID > 0)
            {
                service.UpdateWebBuiding(webBuiding);
            }
            else
            {
                webBuiding.WorkerID = Convert.ToInt32(SessionHelper.Get("PositionID"));
                service.AddWebBuiding(webBuiding);
            }

            return Json(new { RetCode = 1 });
        }
    }
}