using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AIYunNet.CMS.Domain.Model
{
    [Table("WebPicture")]
    public class WebPicture
    {
        [Key]
        [Column("PictureID")]
        public int PictureID { get; set; }
        /// <summary>
        /// PictureName
        /// </summary>
        [Column("PictureName")]
        public string PictureName { get; set; }
        /// <summary>
        /// PictureImg
        /// </summary>
        [Column("PictureImg")]
        public string PictureImg { get; set; }
        /// <summary>
        /// thumbnailImage
        /// </summary>
        [Column("thumbnailImage")]
        public string thumbnailImage { get; set; }
        /// <summary>
        /// AddOn
        /// </summary>
        [Column("AddOn")]
        public DateTime AddOn { get; set; }
        /// <summary>
        /// EditOn
        /// </summary>
        [Column("EditOn")]
        public DateTime? EditOn { get; set; }
        /// <summary>
        /// DeleteOn
        /// </summary>
        [Column("DeleteOn")]
        public DateTime? DeleteOn { get; set; }
        /// <summary>
        /// FlagDelete
        /// </summary>
        [Column("FlagDelete")]
        public int FlagDelete { get; set; }
        /// <summary>
        /// WebImgID
        /// </summary>
        [Column("WebImgID")]
        public int WebImgID { get; set; }

        public WebPicture()
        {
            AddOn = DateTime.Now;
            FlagDelete = 0;
        }
    }


    public class WebPicturesPage
    {
        public int PictureID { get; set; }
        /// <summary>
        /// PictureName
        /// </summary>
        public string PictureName { get; set; }
        /// <summary>
        /// PictureImg
        /// </summary>
        public string PictureImg { get; set; }
        /// <summary>
        /// thumbnailImage
        /// </summary>
        public string thumbnailImage { get; set; }
        public int ImgJzspce { get; set; }

        public int ImgGzspace { get; set; }

        public int ImgJzstyle { get; set; }

        public int DecType { get; set; }
    }
}
