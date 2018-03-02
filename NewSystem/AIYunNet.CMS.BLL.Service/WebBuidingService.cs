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
        public List<WebBuiding> GetWebBuidingListByWorkerID(int WorkerID, bool isdemand)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (isdemand)
                {
                    return context.WebBuiding.Where(wb =>wb.FlagDelete == 0 && wb.WorkerID== WorkerID && wb.DemandID!=0).OrderByDescending(wb => wb.AddOn).ToList();
                }
                else
                {
                    return context.WebBuiding.Where(wb => wb.WorkerID == WorkerID && wb.FlagDelete == 0 && wb.DemandID == 0).OrderByDescending(wb => wb.AddOn).ToList();
                }

            }
        }

        public WebBuiding GetWebBuidingByDemandID(int DemandID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebBuiding.FirstOrDefault(c => c.DemandID == DemandID && c.FlagDelete==0);
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
                    if (old.constructionstageID != webBuiding.constructionstageID)
                    {
                        old.constructionstageID = webBuiding.constructionstageID;
                        old.constructionstage = webBuiding.constructionstage;
                        old.StageNow = 0;
                        //删除
                        List<WebBuidingStages> liststage = context.WebBuidingStages.Where(c => c.WebBuidingID == webBuiding.BuidingID).ToList();
                        if (liststage != null)
                        {
                            foreach (WebBuidingStages item in liststage)
                            {
                                context.WebBuidingStages.Remove(item);
                            }
                        }
                        //添加
                        if (webBuiding.constructionstageID != null)
                        {
                            WebBuiding org = GetWebBuidingByDemandID(webBuiding.DemandID);
                            List<string> listid = webBuiding.constructionstageID.Split(',').Where(c => c != "").ToList();
                            List<string> listStage = webBuiding.constructionstage.Split(',').Where(c => c != "").ToList();
                            int i = 0;
                            foreach (string id in listid)
                            {
                                WebBuidingStages stage = new WebBuidingStages
                                {
                                    WebBuidingID = org.BuidingID,
                                    StageID = Convert.ToInt32(id),
                                    StageName = listStage[i],
                                    sortID = i
                                };
                                context.WebBuidingStages.Add(stage);
                                i++;
                            }
                            context.SaveChanges();
                        }
                    }
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
        //工长加入装修案例
        public int AddWebBuiding(WebBuiding webBuiding)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebBuiding.Add(webBuiding);
                DecDemand dec = context.DecDemand.Find(webBuiding.DemandID);
                if (dec != null)
                {
                    dec.IsPlan = true;
                }
                context.SaveChanges();
                if (webBuiding.constructionstageID!=null)
                {
                    WebBuiding org = GetWebBuidingByDemandID(webBuiding.DemandID);
                    List<string> listid = webBuiding.constructionstageID.Split(',').Where(c => c != "").ToList();
                    List<string> listStage = webBuiding.constructionstage.Split(',').Where(c => c != "").ToList();
                    int i = 0;
                    foreach (string id in listid)
                    {
                        WebBuidingStages stage = new WebBuidingStages
                        {
                            WebBuidingID = org.BuidingID,
                            StageID = Convert.ToInt32(id),
                            StageName = listStage[i],
                            sortID = i
                        };
                        context.WebBuidingStages.Add(stage);
                        i++;
                    }
                    context.SaveChanges();
                }

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
        //根据UserID获取装修
        public List<WebBuiding> GetWebBuidingListByUserID(int UserID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

                 return context.WebBuiding.Where(wb => wb.FlagDelete == 0 && wb.UserID == UserID).OrderByDescending(wb => wb.AddOn).ToList();


            }
        }

        //业主确定是否完工（0没有确定，1确认完工，2延时）
        public int IsUserEnd(int buidingID,int IsUserend)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

                WebBuiding old = context.WebBuiding.Find(buidingID);
                if (old != null)
                {               
                    old.IsUserEnd = IsUserend;
                    if (IsUserend == 2)
                    {
                        old.IsWorkerEnd = 0;
                    }
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }


            }

        }

        public int IsWorkerEnd(int buidingID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebBuiding old = context.WebBuiding.Find(buidingID);
                if (old != null)
                {
                    old.IsWorkerEnd = 1;
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
