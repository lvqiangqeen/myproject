using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.Common.Utility.Tools;
using AIYunNet.CMS.Domain.DataHelper;
using System.Data;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Web.filter;

namespace AIYunNet.CMS.Web.Controllers
{
    public class CommentController : Controller
    {
        OtherService otherService = new OtherService();
        Z_CommentService z_CommentService = new Z_CommentService();
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 评论
        /// </summary>
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult _CommentCase()
        {
            string from_uname = Request["from_uname"];
            string from_account = Request["from_account"];
            string from_uid_type = Request["from_uid_type"];
            string topic_id = Request["topic_id"];
            string topic_type = Request["topic_type"];
            string commentcontent = Request["commentcontent"];
            int result = 0;
            MsSqlDataSource mysqlD = new MsSqlDataSource();
            string thum = "";//获取缩略图
            if (!String.IsNullOrEmpty(from_account))
            {
                thum = otherService.getPhotoUrlthum(from_account, from_uid_type);
            }
            if (thum == "2")
            {
                return Json(new { RetCode = result }, JsonRequestBehavior.AllowGet);
            }
            //插入评论
            string comment_guid = Guid.NewGuid().ToString();
            string insertStr = string.Format("insert into Z_Comment(topic_id,topic_type,content,from_uname,from_account,from_uid_type,addtime,comment_guid,thum) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", topic_id, topic_type, commentcontent, from_uname, from_account, from_uid_type, DateTime.Now.ToString("yyyy-MM-dd"), comment_guid, thum);
            result = mysqlD.ExecuteNonQuery(insertStr);
            Z_Comment comment = new Z_Comment();
            if (result > 0)
            {
                comment = new Z_Comment
                {
                    from_uname = from_uname,
                    from_account = from_account,
                    from_uid_type = from_uid_type,
                    content = commentcontent,
                    addtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    thum = thum,
                    comment_guid= comment_guid
                };
            }
            return PartialView(comment);
        }

        /// <summary>
        /// 评论回复
        /// </summary>
        public ActionResult _ReComment()
        {
            int result = 0;
            string from_uname = Request["from_uname"];
            string from_account = Request["from_account"];
            string from_uid_type = Request["from_uid_type"];
            string content = Request["content"];
            string comment_Guid = Request["comment_Guid"];
            string to_account = Request["to_account"];
            string to_uid_type = Request["to_uid_type"];
            string to_uname = Request["to_uname"];
            string thum = "";//获取缩略图
            if (!String.IsNullOrEmpty(from_account))
            {
                thum = otherService.getPhotoUrlthum(from_account, from_uid_type);
            }
            if (thum == "2")
            {
                result = 0;
            }
            Z_replyComment model = new Z_replyComment
            {
                from_uname= from_uname,
                from_account= from_account,
                from_uid_type= from_uid_type,
                content= content,
                comment_Guid= comment_Guid,
                to_account= to_account,
                to_uid_type= to_uid_type,
                to_uname= to_uname,
                thum= thum
            };
            //插入评论回复
            result = z_CommentService.AddZ_replyComment(model);
            return Json(new { RetCode = result, Z_replyComment = model }, JsonRequestBehavior.AllowGet);
        }
    }
}