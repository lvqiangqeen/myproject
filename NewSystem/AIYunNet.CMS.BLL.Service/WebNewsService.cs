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
    public class WebNewsService : IWebNews
    {
        public List<WebNews> GetWebNewsList()
        {
            using (AIYunNetContext context = new AIYunNetContext()) 
            {
                return context.WebNews.Where(wn => wn.FlagDelete == 0).OrderByDescending(wn => wn.CreatedDate).ToList();
            }
        }
        /// <summary>
        /// 装修公司首页获取置首新闻列表
        /// </summary>
        /// <param name="companyID">公司ID</param>
        /// <param name="modelID">公司页面模板ID</param>
        /// <returns></returns>
        public List<WebNews> IndexGetWebNewsListByCompanyID(int companyID, int modelID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (modelID == 2)
                {
                    return context.WebNews.Where(wn => wn.CompanyID == companyID && wn.FlagDelete == 0 && wn.IsTop == true).Take(3).OrderByDescending(wn => wn.CreatedDate).ToList();
                }
                else
                {
                    return context.WebNews.Where(wn => wn.CompanyID == companyID && wn.FlagDelete == 0).Take(3).OrderByDescending(wn => wn.CreatedDate).ToList();
                }

            }
        }
        public List<WebNews> GetWebNewsListByMenuID(int menuID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebNews.Where(wn => wn.ClassID == menuID && wn.FlagDelete == 0).ToList();
            }
        }
        /// <summary>
        /// 首页获取置首装修新闻列表
        /// </summary>
        /// <param name="menuID">类型ID</param>
        /// <returns></returns>
        public List<WebNews> IndexGetWebNewsListByMenuID(int menuID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

               return context.WebNews.Where(wn => wn.ClassID == menuID && wn.FlagDelete == 0 && wn.IsTop==true).Take(5).ToList();
                
            }
        }
        public WebNews GetWebNewsByID(int newID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebNews.Find(newID);
            }
        }

        public int AddWebNews(WebNews webNews)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

                context.WebNews.Add(webNews);
                context.SaveChanges();
                return 1;
            }
        }

        public int updateWebNews(WebNews webNews)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebNews originalNews = context.WebNews.Find(webNews.ContentID);
                if (originalNews != null)
                {
                    originalNews.Attachment = webNews.Attachment;
                    originalNews.BeFrom = webNews.BeFrom;
                    originalNews.ClassID = webNews.ClassID;
                    originalNews.ClassName = webNews.ClassName;
                    originalNews.CompanyID = webNews.CompanyID;
                    originalNews.CreatedUserID = webNews.CreatedUserID;
                    originalNews.Description = webNews.Description;
                    originalNews.FileName = webNews.FileName;
                    originalNews.ImageUrl = webNews.ImageUrl;
                    originalNews.IsColor = webNews.IsColor;
                    originalNews.IsHot = webNews.IsHot;
                    originalNews.IsRecomend = webNews.IsRecomend;
                    originalNews.IsTop = webNews.IsTop;
                    originalNews.Keywords = webNews.Keywords;
                    originalNews.LastEditDate = DateTime.Now;
                    originalNews.LastEditUserID = webNews.LastEditUserID;
                    originalNews.LinkUrl = webNews.LinkUrl;
                    originalNews.Meta_Description = webNews.Meta_Description;
                    originalNews.Meta_Keywords = webNews.Meta_Keywords;
                    originalNews.Meta_Title = webNews.Meta_Title;
                    originalNews.NormalImageUrl = webNews.NormalImageUrl;
                    originalNews.PvCount = webNews.PvCount;
                    originalNews.Remary = webNews.Remary;
                    originalNews.SeoUrl = webNews.SeoUrl;
                    originalNews.Sequence = webNews.Sequence;
                    originalNews.State = webNews.State;
                    originalNews.StaticUrl = webNews.StaticUrl;
                    originalNews.SubTitle = webNews.SubTitle;
                    originalNews.Summary = webNews.Summary;
                    originalNews.thumbnailImage = webNews.thumbnailImage;
                    originalNews.Title = webNews.Title;
                    originalNews.TotalComment = webNews.TotalComment;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int deleteWebNews(int newID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebNews originalNews = context.WebNews.Find(newID);
                if (originalNews != null)
                {
                    originalNews.FlagDelete = 1;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }


        public void PageViewAdd(int NewsID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebNews originalWebNews = context.WebNews.Find(NewsID);
                if (originalWebNews != null)
                {
                    originalWebNews.PageViewCount = originalWebNews.PageViewCount + 1;
                    context.SaveChanges();
                }
            }
        }
    }
}
