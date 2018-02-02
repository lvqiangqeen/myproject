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
    public class WebCaseImgService
    {
        public int updateWebCaseImgType(WebCaseImg WebCaseImg)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCaseImg originalImg = context.WebCaseImg.Find(WebCaseImg.imgID);
                if (originalImg != null)
                {
                    originalImg.DecType = WebCaseImg.DecType;
                    originalImg.GzStyle = WebCaseImg.GzStyle;
                    originalImg.JzSpace = WebCaseImg.JzSpace;
                    originalImg.JzStyle = WebCaseImg.JzStyle;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        public int AddWebCaseImg(WebCaseImg WebCaseImg)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebCaseImg.Add(WebCaseImg);
                context.SaveChanges();
                return 1;
            }
        }
        public WebCaseImg GetWebCaseImgbyID(int imgid)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCaseImg img=context.WebCaseImg.Find(imgid);
                return img;
            }
        }
        public List<WebCaseImg> GetWebCaseImgList(int DecType)
        {
            List<WebCaseImg> list = new List<WebCaseImg>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                list=context.WebCaseImg.Where(c=>c.DecType== DecType && c.FlagDelete==0).OrderByDescending(c=>c.AddOn).ToList();
                return list;
            }
        }

        public int DeleteWebCseImg(int ImgID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCaseImg originalImg = context.WebCaseImg.Find(ImgID);
                if (originalImg != null)
                {
                    originalImg.FlagDelete = 1;
                    originalImg.DeleteOn = DateTime.Now;
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
