using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("Z_replyComment")]
    public class Z_replyComment
    {
        public Z_replyComment()
        {
            reply_id = 0;
            from_uid = 0;
            to_uid = 0;
            addtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 评论id
        /// </summary>
        [Column("comment_Guid")]
        public string comment_Guid { get; set; }
        /// <summary>
        /// 回复目标id
        /// </summary>
        [Column("reply_id")]
        public int reply_id { get; set; }
        /// <summary>
        /// 回复类型
        /// </summary>
        [Column("reply_type")]
        public string reply_type { get; set; }
        /// <summary>
        /// 回复内容
        /// </summary>
        [Column("content")]
        public string content { get; set; }
        /// <summary>
        /// 回复用户id
        /// </summary>
        [Column("from_uid")]
        public int? from_uid { get; set; }
        /// <summary>
        /// 回复用户昵称
        /// </summary>
        [Column("from_uname")]
        public string from_uname { get; set; }
        /// <summary>
        /// 回复用户账号
        /// </summary>
        [Column("from_account")]
        public string from_account { get; set; }
        /// <summary>
        /// 回复用户类别
        /// </summary>
        [Column("from_uid_type")]
        public string from_uid_type { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        [Column("addtime")]
        public string addtime { get; set; }
        /// <summary>
        /// 目标用户id
        /// </summary>
        [Column("to_uid")]
        public int to_uid { get; set; }
        /// <summary>
        /// 目标用户昵称
        /// </summary>
        [Column("to_uname")]
        public string to_uname { get; set; }
        /// <summary>
        /// 目标用户账号
        /// </summary>
        [Column("to_account")]
        public string to_account { get; set; }
        /// <summary>
        /// 目标用户类别
        /// </summary>
        [Column("to_uid_type")]
        public string to_uid_type { get; set; }
        /// <summary>
        /// 点赞量
        /// </summary>
        [Column("ZanCount")]
        public int ZanCount { get; set; }
        /// <summary>
        /// 获取缩略图
        /// </summary>
        [Column("thum")]
        public string thum { get; set; }
    }

    [Table("Z_Comment")]
    public class Z_Comment
    {
        public Z_Comment()
        {
            addtime= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ZanCount = 0;
            IsAnswer = 0;
        }
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 主题id
        /// </summary>
        [Column("topic_id")]
        public int topic_id { get; set; }
        /// <summary>
        /// 主题类型
        /// </summary>
        [Column("topic_type")]
        public string topic_type { get; set; }
        /// <summary>
        /// content
        /// </summary>
        [Column("content")]
        public string content { get; set; }
        /// <summary>
        /// 评论用户id
        /// </summary>
        [Column("from_uid")]
        public int? from_uid { get; set; }
        /// <summary>
        /// 评论用户昵称
        /// </summary>
        [Column("from_uname")]
        public string from_uname { get; set; }
        /// <summary>
        /// 评论用户账号
        /// </summary>
        [Column("from_account")]
        public string from_account { get; set; }
        /// <summary>
        /// 评论用户类别
        /// </summary>
        [Column("from_uid_type")]
        public string from_uid_type { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        [Column("addtime")]
        public string addtime { get; set; }
        /// <summary>
        /// 唯一标识
        /// </summary>
        [Column("comment_guid")]
        public string comment_guid { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        [Column("ZanCount")]
        public int ZanCount { get; set; }
        /// <summary>
        /// 获取缩略图
        /// </summary>
        [Column("thum")]
        public  string thum { get; set; }

        /// <summary>
        /// 是否回答
        /// </summary>
        [Column("IsAnswer")]
        public int IsAnswer { get; set; }
    }


    public class PeopleComments
    {
        public Z_Comment comment { get; set; }
        public List<Z_replyComment> reCommentList { get; set; }

        public PeopleComments()
        {
            comment = new Z_Comment();
            reCommentList = new List<Z_replyComment>();
        }
    }
}
