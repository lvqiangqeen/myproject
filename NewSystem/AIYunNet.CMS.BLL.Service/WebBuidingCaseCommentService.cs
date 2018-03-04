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

namespace AIYunNet.CMS.BLL.Service
{
    public class WebBuidingCaseCommentService
    {
        public int AddWebBuidingCaseComment(WebBuidingCaseComment comment)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebBuidingCaseComment.Add(comment);
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
                return comm;
            }
        }
        public List<WebBuidingCaseComment> GetCommentListByGetUserID(int id)
        {
            List<WebBuidingCaseComment> comm = new List<WebBuidingCaseComment>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                comm = context.WebBuidingCaseComment.Where(c=>c.GetUserID==id).ToList();
                return comm;
            }
        }
    }
}
