using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.Web.filter;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.OccaModel;

namespace AIYunNet.CMS.Web.Areas.MobileApp.Controllers
{
    [AllSessionFilter]
    public class mOrderController : Controller
    {
        DecDemandAcceptService AcSer = new DecDemandAcceptService();
        // GET: MobileApp/mOrder
        public ActionResult Orderlist()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetOrderlist(int UserID, int PageSize, int CurPage)
        {
            int count = 0;
            List<AcceptDemand> list =  AcSer.mGetDemandListByUserID(UserID, PageSize, CurPage, out count);
            return Json(list);
        }
    }
}