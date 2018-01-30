using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.BLL.IService;

namespace AIYunNet.CMS.Web.Controllers
{
    public class GoodsController : Controller
    {
        //
        // GET: /Goods/
        //NetCms.BLL.WebOrder bll = new NetCms.BLL.WebOrder();
       
        //NetCms.BLL.WebOrderGoods bllg = new NetCms.BLL.WebOrderGoods();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Info()
        {
            return View();
        }
        public ActionResult List()
        {
            return View();
        }
      
        //[Description("添加订单")]
        //[ValidateInput(false)]
        //[HttpPost]
        //public ActionResult Add(NetCms.Model.WebOrderGoods modelg)
        //{
        //    NetCms.Model.WebOrder model = new NetCms.Model.WebOrder();
        //    int count = bll.GetList("1=1").Tables[0].Rows.Count+1;
        //    string date = DateTime.Now.ToString("yyyyMMdd"); ;
        //    model.OrderNumber = date+count.ToString().PadLeft(5, '0');
        //    int flag = bll.Add(model);



        //    modelg.GoodsID = Request["goodsid"] != null ? int.Parse(Request["goodsid"]) : 0;
        //    modelg.OrderID = flag;
        //    bllg.Add(modelg);

        //    return JavaScript("alert('保存成功')"); ;
        //}
    }
}
