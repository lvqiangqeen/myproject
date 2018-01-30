using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Web.filter;

namespace AIYunNet.CMS.Web.Areas.CompanyCenter.Controllers
{
    [CompanyFilter]
    public class CompanyCommentController : Controller
    {
        Z_CommentService comser = new Z_CommentService();
        // GET: CompanyCenter/CompanyComment
        public ActionResult CommentList(int topic_id)
        {
            List<Z_Comment> comlist=comser.GetCommentList("WebCompany", topic_id);
            ViewBag.comlist = comlist;
            return View();
        }
        //回答问题
        [HttpGet]
        public ActionResult CommentAnswer(int id)
        {
            Z_Comment com = comser.GetCommentByID(id);
            ViewBag.com = com;
            Z_replyComment recom = comser.GetreplyCommentByGUID(com.comment_guid);
            return View(recom);
        }

        [HttpPost]
        public ActionResult AnswerComment(Z_replyComment recom)
        {
            int result = 0;
            if (recom.id == 0)
            {
                result = comser.AddZ_replyComment(recom);
                if (recom.content.Replace(" ","")!= "")
                {
                    comser.MarkIsAnswer(recom.comment_Guid);
                }
            }
            else
            {
                result = comser.updateZ_replyComment(recom);
                if (recom.content.Replace(" ", "") != "")
                {
                    comser.MarkIsAnswer(recom.comment_Guid);
                }
            }
            return Json(new { retCode = result }, JsonRequestBehavior.AllowGet);
        }
    }
}