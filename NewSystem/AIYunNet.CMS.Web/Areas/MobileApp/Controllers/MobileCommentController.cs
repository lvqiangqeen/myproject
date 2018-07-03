﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AIYunNet.CMS.Web.filter;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Common.Utility;

namespace AIYunNet.CMS.Web.Areas.MobileApp.Controllers
{
    [MobileUserFilter]
    public class MobileCommentController : Controller
    {
        WebBuidingCaseCommentService commerSer = new WebBuidingCaseCommentService();
        WebBuidingService buidingSer = new WebBuidingService();

        public ActionResult BuidingContract(string guid)
        {

            return View();
        }
        public ActionResult Commentlist(int UserID = 0)
        {
            List<WebBuidingCaseComment> list = new List<WebBuidingCaseComment>();
            
            list=commerSer.GetCommentListByGetUserID(UserID, "WebBuiding", 0);

            ViewBag.list = list;
            
            return View();
        }
        [HttpPost]
        public ActionResult GetCommentlist(int UserID, int CurPage,int PageSize,int score)
        {
            List<WebBuidingCaseComment> list = new List<WebBuidingCaseComment>();
            list = commerSer.GetCommentlist(UserID, "WebBuiding", score, PageSize, CurPage);
            return Json(list);
        }
        // GET: MobileApp/MobileComment
        public ActionResult CommentDetail(int CaseID=0)
        {
            WebBuidingCaseComment comm = new WebBuidingCaseComment();
            comm = commerSer.GetCommentByTypeAndID("WebBuiding", CaseID);
            if (comm == null)
            {
                comm = new WebBuidingCaseComment();
            }
            return View(comm);
        }
        //总体审核
        [HttpPost]
        public JsonResult IsUserEnd(int buidingID, int IsUserend)
        {
            int ret = 0;
            ret = buidingSer.IsUserEnd(buidingID, IsUserend);
            return Json(new { RetCode = ret });
        }
        [HttpPost]
        public JsonResult AddOrEditComment(WebBuidingCaseComment comm)
        {
            int ret = 0;
            if (comm.id == 0)
            {
                ret = commerSer.AddWebBuidingCaseComment(comm);
            }
            else
            {
                ret = commerSer.updateWebBuidingCaseComment(comm);
            }
            return Json(new { RetCode = ret });
        }
    }
}