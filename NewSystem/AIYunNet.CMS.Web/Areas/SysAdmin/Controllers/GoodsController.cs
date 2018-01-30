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
    public class GoodsController : BaseController
    {
        WebGoodsService webGoodsService = new WebGoodsService();
        WebCommonService webCommonService = new WebCommonService();
        // GET: SysAdmin/Goods
        public ActionResult GoodsList()
        {
            List<WebGoods> webGoodsList = webGoodsService.GetWebGoodsList();
            ViewBag.webGoodsList = webGoodsList;
            return View();
        }
        [HttpGet]
        public ActionResult AddOrEditGoods(int Goodid)
        {
            WebGoods webgood = webGoodsService.GetWebGoodsByID(Goodid);
            if (webgood == null)
            {
                webgood = new WebGoods();
            }
            List<WebLookup> goodtypelist = webCommonService.GetLookupList("Goods_type");

            IEnumerable<SelectListItem> goodtype = goodtypelist.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });
            ViewBag.goodtypelist = goodtype;
            return View(webgood);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddOrEditGoods(WebGoods webGood)
        {
            int result = 0;
            if (webGood != null && webGood.GoodsID > 0)
            {
                result = webGoodsService.UpdateWebGoods(webGood);
            }
            else
            {
                result = webGoodsService.AddWebGoods(webGood);
            }
            return Json(new { retCode = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteWebGoods(int GoodsID)
        {
            webGoodsService.DeleteWebGoods(GoodsID);
            return Json(new { RetCode = 1 }, JsonRequestBehavior.AllowGet);
        }
    }
}