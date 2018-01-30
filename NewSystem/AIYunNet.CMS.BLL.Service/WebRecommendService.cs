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
    public class WebRecommendService: IWebRecommend
    {
        //获取公司推荐列表
        public List<WebRecommend> GetAllWebRecommendByCompany(int RecommendType, int CompanyID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

                return context.WebRecommend.Where(p => p.FlagDelete == 0 && p.RecommendType == RecommendType && p.CompanyID== CompanyID.ToString()).OrderByDescending(p => p.ShowOrder).ToList();

            }
        }

        public List<WebRecommend> GetWebRecommendByCompany(int RecommendType, int num, int CompanyID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

                return context.WebRecommend.Where(p => p.FlagDelete == 0 && p.RecommendType == RecommendType && p.PcOn == true && p.CompanyID == CompanyID.ToString()).OrderByDescending(p => p.ShowOrder).Take(num).ToList();

            }
        }
        /// <summary>
        /// 获取推送列表全部byRecommendType
        /// </summary>
        public List<WebRecommend> GetWebRecommendListAllByRecommendType(int RecommendType)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

                return context.WebRecommend.Where(p => p.FlagDelete == 0 && p.RecommendType == RecommendType && (p.CompanyID=="0" || p.CompanyID==null) ).OrderByDescending(p => p.ShowOrder).ToList();

            }
        }
        /// <summary>
        /// PC推送列表全部
        /// </summary>
        public List<WebRecommend> GetWebRecommendListPc(int RecommendType)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

                return context.WebRecommend.Where(p => p.FlagDelete == 0 && p.RecommendType == RecommendType && p.PcOn == true && (p.CompanyID == "0" || p.CompanyID == null)).OrderByDescending(p => p.ShowOrder).ToList();

            }
        }
        /// <summary>
        /// PC推送列表
        /// </summary>
        public List<WebRecommend> GetWebRecommendListPc(int RecommendType, int num,bool bigOrsmall)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

                return context.WebRecommend.Where(p => p.FlagDelete == 0 && p.RecommendType == RecommendType && p.PcOn==true && p.BigOrSmall== bigOrsmall && (p.CompanyID == "0" || p.CompanyID == null)).OrderByDescending(p => p.ShowOrder).Take(num).ToList();

            }
        }

        /// <summary>
        /// 推送列表全部(微信)
        /// </summary>
        public List<WebRecommend> GetWebRecommendList(int RecommendType)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

                return context.WebRecommend.Where(p => p.FlagDelete == 0 && p.RecommendType == RecommendType && p.WechatOn== true && (p.CompanyID == "0" || p.CompanyID == null)).OrderByDescending(p => p.ShowOrder).ToList();

            }
        }
        /// <summary>
        /// 推送列表
        /// </summary>
        public List<WebRecommend> GetWebRecommendList(int RecommendType,int num)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

               return context.WebRecommend.Where(p => p.FlagDelete == 0 && p.RecommendType == RecommendType && p.WechatOn == true && (p.CompanyID == "0" || p.CompanyID == null)).OrderByDescending(p => p.ShowOrder).Take(num).ToList();

            }
        }
        public WebRecommend GetWebRecommendByID(int WebRecommendID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebRecommend.Find(WebRecommendID);
            }
        }
        public int AddWebRecommend(WebRecommend WebRecommend)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebRecommend.Add(WebRecommend);
                context.SaveChanges();
                return 1;
            }
        }

        public int UpdateWebRecommend(WebRecommend WebRecommend)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (WebRecommend != null)
                {
                    WebRecommend origWebRecommend = context.WebRecommend.Find(WebRecommend.RecommendId);
                    if (origWebRecommend != null)
                    {
                        origWebRecommend.RecommendImg = WebRecommend.RecommendImg;
                        origWebRecommend.RecommendInfo = WebRecommend.RecommendInfo;
                        origWebRecommend.RecommendName = WebRecommend.RecommendName;
                        origWebRecommend.RecommendType = WebRecommend.RecommendType;
                        origWebRecommend.RecommendUrl = WebRecommend.RecommendUrl;
                        origWebRecommend.RecWechartUrl = WebRecommend.RecWechartUrl;
                        origWebRecommend.thumbnailImage = WebRecommend.thumbnailImage;
                        origWebRecommend.EditOn = DateTime.Now;
                        origWebRecommend.WechatOn = WebRecommend.WechatOn;
                        origWebRecommend.RecommendContent = WebRecommend.RecommendContent;
                        origWebRecommend.BigOrSmall = WebRecommend.BigOrSmall;
                        origWebRecommend.PcOn = WebRecommend.PcOn;
                        origWebRecommend.ShowOrder = WebRecommend.ShowOrder;
                        origWebRecommend.IsRed = WebRecommend.IsRed;
                        if (!string.IsNullOrEmpty(WebRecommend.CompanyID) || WebRecommend.CompanyID!="0")
                        {
                            origWebRecommend.CompanyID = WebRecommend.CompanyID;
                            
                        }
                        else
                        {
                            origWebRecommend.CompanyID = "0";
                        }
                        context.SaveChanges();
                    }
                }


                return 1;
            }
        }

        public int DeleteWebRecommend(int WebRecommendID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebRecommend WebRecommend = context.WebRecommend.Find(WebRecommendID);
                if (WebRecommend != null)
                {
                    WebRecommend.FlagDelete = 1;
                    WebRecommend.DeleteOn = DateTime.Now;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// 获取首页list
        /// </summary>
        public indexList GetIndexListPc(int RecommendType, int num, bool bigOrsmall)
        {
            indexList indexlist = new indexList();
            WebCommonService webCommenService = new WebCommonService();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (num == 0)
                {
                    indexlist.list = GetWebRecommendListPc(RecommendType);
                }
                else
                {
                    indexlist.list = GetWebRecommendListPc(RecommendType, num, bigOrsmall);
                }
                indexlist.name = webCommenService.GetLookupDesc("Recommend_Wechart", RecommendType.ToString());
            }
            return indexlist;
        }
    }
}
