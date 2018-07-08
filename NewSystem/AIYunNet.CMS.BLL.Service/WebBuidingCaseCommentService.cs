using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Domain;
using AIYunNet.CMS.Domain.DataHelper;
using System.Data;
using AIYunNet.CMS.Domain.OccaModel;

namespace AIYunNet.CMS.BLL.Service
{
    public class WebBuidingCaseCommentService
    {
        public WebBuidingCaseComment GetWebBuidingCaseCommentByGuid(string guid)
        {
            WebBuidingCaseComment com = new WebBuidingCaseComment();
            using (AIYunNetContext context = new AIYunNetContext())
            {

                com = context.WebBuidingCaseComment.FirstOrDefault(c => c.Guid == guid);
                if (com != null)
                {
                    return com;
                }
                else
                {
                    return new WebBuidingCaseComment();
                }
            }
        }
        public int AddWebBuidingCaseComment(WebBuidingCaseComment comment)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebBuidingCaseComment.Add(comment);
                WebBuiding buiding = context.WebBuiding.FirstOrDefault(c => c.Guid == comment.Guid);
                buiding.IsComment = 1;
                context.SaveChanges();
                return 1;
            }
        }
        public int updateWebBuidingCaseComment(WebBuidingCaseComment comment)
        {
            WebBuidingCaseComment old = new WebBuidingCaseComment();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                old = context.WebBuidingCaseComment.Find(comment.id);
                old.Score = comment.Score;
                old.Comment = comment.Comment;
                old.EditOn = DateTime.Now.ToString();
                old.IsEdit = 1;
                WebBuiding buiding = context.WebBuiding.FirstOrDefault(c => c.Guid == comment.Guid);
                buiding.IsComment = 2;
                context.SaveChanges();
                return 1;
            }
        }
        public WebBuidingCaseComment GetCommentByTypeAndID(string type,int id)
        {
            WebBuidingCaseComment comm = new WebBuidingCaseComment();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                comm = context.WebBuidingCaseComment.FirstOrDefault(c=>c.CaseID==id && c.CaseType== type);
                if (comm == null)
                {
                    comm = new WebBuidingCaseComment();
                }
                return comm;
            }
        }
        //获取评价123差中好，0为所有评价
        public List<WebBuidingCaseComment> GetCommentListByGetUserID(int id,string type,int score)
        {
            List<WebBuidingCaseComment> comm = new List<WebBuidingCaseComment>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (score == 0)
                {
                    comm = context.WebBuidingCaseComment.Where(c => c.GetUserID == id && c.CaseType == type).OrderByDescending(c => c.AddOn).ToList();
                }
                else
                {
                    comm = context.WebBuidingCaseComment.Where(c => c.GetUserID == id && c.CaseType == type && c.Score == score).OrderByDescending(c => c.AddOn).ToList();
                }
                if (comm == null)
                {
                    comm = new List<WebBuidingCaseComment>();

                }

                return comm;
            }
        }

        public List<BuidingAndComment> GetCommentlist(int id, string type, int score,int PageSize,int CurPage)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                List<BuidingAndComment> comm = new List<BuidingAndComment>();
                var com = from c in context.WebBuiding
                          from d in context.WebBuidingCaseComment
                          where c.Guid == d.Guid
                          && c.FlagDelete == 0 && d.IsDelete == false
                           && d.GetUserID == id && d.CaseType == type && d.Score == score
                          select new BuidingAndComment
                          {
                              guid = c.Guid,
                              BuidingTitle = c.BuidingTitle,
                              Comment = d.Comment,
                              EndTime = c.EndTime,
                              score = d.Score,
                              AddOn=d.AddOn
                          };

                comm = com.ToList().OrderByDescending(c => c.AddOn).Skip(PageSize * (CurPage - 1)).Take(PageSize * CurPage).ToList();
                return comm;
            }
        }
    }
}
