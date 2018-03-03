using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebBuidingCaseComment")]
    public class WebBuidingCaseComment
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// Guid
        /// </summary>
        [Column("Guid")]
        public string Guid { get; set; }
        /// <summary>
        /// Comment
        /// </summary>
        [Column("Comment")]
        public string Comment { get; set; }
        /// <summary>
        /// Score
        /// </summary>
        [Column("Score")]
        public int Score { get; set; }
        /// <summary>
        /// AddOn
        /// </summary>
        [Column("AddOn")]
        public string AddOn { get; set; }
        /// <summary>
        /// EditOn
        /// </summary>
        [Column("EditOn")]
        public string EditOn { get; set; }
        /// <summary>
        /// DeleteOn
        /// </summary>
        [Column("DeleteOn")]
        public string DeleteOn { get; set; }
        /// <summary>
        /// IsDelete
        /// </summary>
        [Column("IsDelete")]
        public bool IsDelete { get; set; }
        /// <summary>
        /// PablishUserID
        /// </summary>
        [Column("PablishUserID")]
        public int PablishUserID { get; set; }
        /// <summary>
        /// GetUserID
        /// </summary>
        [Column("GetUserID")]
        public int GetUserID { get; set; }
        /// <summary>
        /// CaseID
        /// </summary>
        [Column("CaseID")]
        public int CaseID { get; set; }
        /// <summary>
        /// CaseType
        /// </summary>
        [Column("CaseType")]
        public string CaseType { get; set; }

        public WebBuidingCaseComment()
        {
            Guid = System.Guid.NewGuid().ToString();
            Score = 0;
            AddOn = DateTime.Now.ToString();
            EditOn = DateTime.Now.ToString();
            IsDelete = false;
            PablishUserID = 0;
            GetUserID = 0;
            CaseID = 0;
            Comment = "";
        }
    }
}
