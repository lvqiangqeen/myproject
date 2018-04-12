using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.Web.filter;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Common.Utility;

namespace AIYunNet.CMS.Web.Areas.MobileApp.Controllers
{
    public class MoblieBuidingController : Controller
    {
        WebBuidingService buidSer = new WebBuidingService();
        DemandService DemandSer = new DemandService();
        WebBuidingStagesService WebBuidingStagesSer = new WebBuidingStagesService();
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
    }
}