using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
namespace AIYunNet.CMS.Web.Controllers
{
    public class QuestionController : Controller
    {
        //
        // GET: /Question/
        //NetCms.BLL.WebMessage bll = new NetCms.BLL.WebMessage();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();

        }
        //[Description("添加留言")]
        //[ValidateInput(false)]
        //[HttpPost]
        //public ActionResult Add(NetCms.Model.WebMessage model)
        //{
        //    model.Sex = Request["Sex"];
        //    int flag = bll.Add(model);
        //    return JavaScript("alert('保存成功')"); ;
        //}
    }
}
