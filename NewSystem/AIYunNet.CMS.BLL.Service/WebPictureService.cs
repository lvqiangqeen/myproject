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
    public class WebPictureService:IWebPicture
    {
        /// <summary>
        /// 根据图库ID获取图片
        /// </summary>
        public List<WebPicture> GetWebPictureList(int WebImgID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

                return context.WebPicture.Where(p => p.FlagDelete == 0 && p.WebImgID== WebImgID).ToList();

            }
        }
        /// <summary>
        /// 推送列表
        /// </summary>
        public List<WebPicture> GetWebPictureList(int WebImgID, int num)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

                return context.WebPicture.Where(p => p.FlagDelete == 0&&p.WebImgID== WebImgID).Take(num).ToList();

            }
        }
        public WebPicture GetWebPictureByID(int WebPictureID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebPicture.Find(WebPictureID);
            }
        }
        public int AddWebPicture(WebPicture WebPicture)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebPicture.Add(WebPicture);
                context.SaveChanges();
                return 1;
            }
        }

        public int UpdateWebPicture(WebPicture WebPicture)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (WebPicture != null)
                {
                    WebPicture origWebPicture = context.WebPicture.Find(WebPicture.PictureID);
                    if (origWebPicture != null)
                    {
                        origWebPicture.PictureName = WebPicture.PictureName;
                        origWebPicture.PictureImg = WebPicture.PictureImg;
                        origWebPicture.thumbnailImage = WebPicture.thumbnailImage;
                        origWebPicture.WebImgID = WebPicture.WebImgID;
                        origWebPicture.EditOn = DateTime.Now;
                        context.SaveChanges();
                    }
                }


                return 1;
            }
        }

        public int DeleteWebPicture(int WebPictureID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebPicture WebPicture = context.WebPicture.Find(WebPictureID);
                if (WebPicture != null)
                {
                    WebPicture.FlagDelete = 1;
                    WebPicture.DeleteOn = DateTime.Now;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
