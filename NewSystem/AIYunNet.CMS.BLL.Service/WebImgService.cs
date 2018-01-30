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
    public class WebImgService:IWebImg
    {
        public List<WebImg> GetWebImgList(int DecType)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebImg.Where(wc => wc.FlagDelete == 0 && wc.DecType== DecType).OrderByDescending(wc => wc.addon).ToList();
            }
        }
        public List<WebImg> GetWebImgListByParameter(string sql)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebImg.Where(wc => wc.FlagDelete == 0).OrderByDescending(wc => wc.addon).ToList();
            }
        }
        public WebImg GetWebImgByID(int webImgID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebImg.FirstOrDefault(wc => wc.ImgId == webImgID && wc.FlagDelete == 0);
            }
        }

        public int AddWebImg(WebImg WebImg)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebImg.Add(WebImg);
                context.SaveChanges();
                return 1;
            }
        }

        public int UpdateWebImg(WebImg WebImg)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebImg originalImg = context.WebImg.Find(WebImg.ImgId);
                if (originalImg != null)
                {
                    originalImg.ImgTitle = WebImg.ImgTitle;
                    originalImg.ImgInfo = WebImg.ImgInfo;
                    originalImg.ImgContent = WebImg.ImgContent;
                    originalImg.thumbnailImage = WebImg.thumbnailImage;
                    originalImg.ImgUrl = WebImg.ImgUrl;
                    originalImg.softcoverstyle = WebImg.softcoverstyle;
                    originalImg.hotalstyle = WebImg.hotalstyle;
                    originalImg.designerrstyle = WebImg.designerrstyle;
                    originalImg.commercialstyle = WebImg.commercialstyle;
                    originalImg.IsPublish = WebImg.IsPublish;
                    originalImg.IsTop = WebImg.IsTop;
                    originalImg.editon = DateTime.Now;
                    originalImg.ImgJzspce = WebImg.ImgJzspce;
                    originalImg.ImgGzspace = WebImg.ImgGzspace;
                    originalImg.ImgJzstyle = WebImg.ImgJzstyle;
                    originalImg.DecType = WebImg.DecType;
                    originalImg.CompanyID = 0;
                    originalImg.PeopleID = 0;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int DeleteWebImg(int WebImgID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebImg originalImg = context.WebImg.Find(WebImgID);
                if (originalImg != null)
                {
                    originalImg.FlagDelete = 1;
                    originalImg.deleteon = DateTime.Now;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public void PageViewAdd(int WebImgID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebImg originalWebImg = context.WebImg.Find(WebImgID);
                if (originalWebImg != null)
                {
                    originalWebImg.browsecount = originalWebImg.browsecount + 1;
                    context.SaveChanges();
                }
            }
        }
    }
}
