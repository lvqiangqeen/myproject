using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Domain;

namespace AIYunNet.CMS.BLL.Service
{
    public class Z_CommentService
    {
        /// <summary>
        /// 标记是否回答
        /// </summary>
        public int MarkIsAnswer(string gid)
        {
            Z_Comment com = new Z_Comment();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                com = context.Z_Comment.Where(c=>c.comment_guid== gid).ToList()[0];
                com.IsAnswer = 1;
                context.SaveChanges();

            }
            return 1;
        }
        /// <summary>
        /// 获取没有回答的问题
        /// </summary>
        public List<Z_Comment> GetCommentNoAnswerList(string topic_type, int topic_id)
        {
            List<Z_Comment> list = new List<Z_Comment>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                list = context.Z_Comment.Where(wc => wc.topic_id == topic_id && wc.topic_type == topic_type && wc.IsAnswer==0).OrderByDescending(wc => wc.addtime).ToList();
            }
            return list;
        }
        /// <summary>
        /// 获取所有评论
        /// </summary>
        public List<Z_Comment> GetCommentList(string topic_type,int topic_id)
        {
            List<Z_Comment> list = new List<Z_Comment>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                list = context.Z_Comment.Where(wc => wc.topic_id == topic_id && wc.topic_type== topic_type).OrderByDescending(wc => wc.addtime).ToList();
            }
            return list;
        }
        /// <summary>
        /// 获取评论的回复
        /// </summary>
        public List<Z_replyComment> GetReplyCommentListByID(string comment_guid)
        {
            List<Z_replyComment> list = new List<Z_replyComment>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                list= context.Z_replyComment.Where(wc => wc.comment_Guid == comment_guid).OrderBy(wc => wc.addtime).ToList();
            }
            return list;
        }
        /// <summary>
        /// 获取单个问题
        /// </summary>
        public Z_Comment GetCommentByID(int id)
        {
            Z_Comment com = new Z_Comment();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                com = context.Z_Comment.Find(id);
            }
            return com;
        }
        /// <summary>
        /// 取前10条点赞的评论和评论的回复
        /// </summary>
        public List<PeopleComments> GetCommentListByID(int topic_id, string topic_type, int count)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                List<PeopleComments> listComment = new List<PeopleComments>();

                List<Z_Comment> list = new List<Z_Comment>();
                list = context.Z_Comment.Where(wc => wc.topic_id == topic_id && wc.topic_type == topic_type).OrderByDescending(wc => wc.ZanCount).OrderBy(wc => wc.addtime).Take(count).ToList();
                foreach (var arr in list)
                {
                    PeopleComments Comment = new PeopleComments();
                    Comment.comment = arr;
                    Comment.reCommentList = GetReplyCommentListByID(arr.comment_guid);
                    listComment.Add(Comment);
                }
                return listComment;
            }
        }
        /// <summary>
        /// 插入评论的回复
        /// </summary>
        public int AddZ_replyComment(Z_replyComment Z_replyComment)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.Z_replyComment.Add(Z_replyComment);
                context.SaveChanges();
                return 1;
            }
        }
        /// <summary>
        /// 删除评论的回复
        /// </summary>
        public int deleteZ_replyComment(int Z_replyCommentid)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                Z_replyComment originalZ_replyComment = context.Z_replyComment.Find(Z_replyCommentid);
                context.Z_replyComment.Remove(originalZ_replyComment);
                context.SaveChanges();
                return 1;
            }
        }
        /// <summary>
        /// 修改问题的回复
        /// </summary>
        public int updateZ_replyComment(Z_replyComment Z_replyComment)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                Z_replyComment original = context.Z_replyComment.Find(Z_replyComment.id);
                original.comment_Guid = Z_replyComment.comment_Guid;
                original.content = Z_replyComment.content;
                original.from_account = Z_replyComment.from_account;
                original.from_uname = Z_replyComment.from_uname;
                original.from_uid_type = Z_replyComment.from_uid_type;
                original.thum = Z_replyComment.thum;
                context.SaveChanges();
                return 1;
            }
        }

        /// <summary>
        /// 获取单个回复
        /// </summary>
        public Z_replyComment GetreplyCommentByGUID(string gid)
        {
            Z_replyComment com = new Z_replyComment();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                List<Z_replyComment> comlist = context.Z_replyComment.Where(c=>c.comment_Guid== gid).ToList();
                if (comlist.Count() > 0)
                {
                    com = comlist[0];
                }
            }
            return com;
        }
    }
}
