using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Domain;
using AIYunNet.CMS.BLL.IService;

namespace AIYunNet.CMS.BLL.Service
{
    public class WebBuidingService
    {
        /// <summary>
        ///  获取工人列表推荐工地
        /// </summary>
        /// <returns></returns>
        public List<WebBuiding> GetWebBuidingListByCount(int WorkerID,int count)
        {
            List<WebBuiding> list = new List<WebBuiding>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                try
                {
                    list= context.WebBuiding.Where(wc => wc.FlagDelete == 0 && wc.WorkerID == WorkerID && wc.IsTop==true).OrderByDescending(wc => wc.AddOn).Take(3).ToList();
                }
                catch(Exception e)
                {
                    list= new List<WebBuiding>();
                }
                return list;


            }
        }
        /// <summary>
        ///  根据ID获取在建工地
        /// </summary>
        /// <returns></returns>
        public WebBuiding GetWebBuidingByID(int BuidingID)
        {
            WebBuiding buiding = new WebBuiding();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                try
                {
                    buiding = context.WebBuiding.Find(BuidingID);
                }
                catch (Exception e)
                {
                }
                return buiding;
            }
        }

        public List<WebBuiding> GetWebBuidingList(int workerID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebBuiding.Where(wb => wb.WorkerID == workerID && wb.FlagDelete == 0).OrderByDescending(wb => wb.AddOn).ToList();
            }
        }

        public WebBuiding GetWebuidingByID(int buidingID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebBuiding.Find(buidingID);
            }
        }

        public int UpdateWebBuiding(WebBuiding webBuiding)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebBuiding old = context.WebBuiding.Find(webBuiding.BuidingID);
                if (old != null)
                {
                    old.BuidingTitle = webBuiding.BuidingTitle;
                    old.BuidingID = webBuiding.BuidingID;
                    old.BuidingTitle = webBuiding.BuidingTitle;
                    old.BuidingBrief = webBuiding.BuidingBrief;
                    old.BuidingInfo = webBuiding.BuidingInfo;
                    old.Price = webBuiding.Price;
                    old.Space = webBuiding.Space;
                    old.constructionstageID = webBuiding.constructionstageID;
                    old.constructionstage = webBuiding.constructionstage;
                    old.ShowOrder = webBuiding.ShowOrder;
                    old.IsHot = webBuiding.IsHot;
                    old.IsTop = webBuiding.IsTop;
                    old.thumbnailImage = webBuiding.thumbnailImage;
                    old.BuidingImage = webBuiding.BuidingImage;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int AddWebBuiding(WebBuiding webBuiding)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebBuiding.Add(webBuiding);
                context.SaveChanges();
                return 1;
            }
        }

        public int DeleteWebBuiding(int buidingID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebBuiding old = context.WebBuiding.Find(buidingID);
                if (old != null)
                {
                    old.FlagDelete = 1;
                    old.DeleteOn = DateTime.Now;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int AddUpdateBuidingStages(WebBuidingStages buidingStage)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebBuidingStages old = context.WebBuidingStages.FirstOrDefault(bs => bs.WebBuidingID == buidingStage.WebBuidingID && bs.StageID == buidingStage.StageID);
                if (old == null)
                {
                    context.WebBuidingStages.Add(buidingStage);
                }
                else
                {
                    old.StageContent = buidingStage.StageContent;
                }
                context.SaveChanges();
                return 1;
            }
        }

        public string GetBuidingStageInfo(int buidingID, int stageID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebBuidingStages buidingStage = context.WebBuidingStages.Where(bs => bs.WebBuidingID == buidingID && bs.StageID == stageID).FirstOrDefault();
                if (buidingStage != null)
                {
                    return buidingStage.StageContent;
                }
                else
                {
                    return string.Empty;
                }

            }
        }

        public int AddBuidingTimeStages(WebBuidingTimeStages timeStages)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebBuidingTimeStages.Add(timeStages);
                context.SaveChanges();
                return 1;
            }
        }

    }
}
