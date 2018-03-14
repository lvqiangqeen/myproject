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
    public class WebBuidingStagesService
    {
        //业主审核阶段信息
        public int IsUserEnd(int BuidingID, int StageID,int IsUserend)
        {         
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebBuidingStages old = context.WebBuidingStages.Where(wc => wc.WebBuidingID == BuidingID && wc.StageID == StageID).ToList()[0];
                old.IsUserEnd = IsUserend;
                context.SaveChanges();
                return 1;
            }
        }
        public List<WebBuidingStages> GetWebBuidingStagesListByBuiding(int BuidingID)
        {
            List<WebBuidingStages> list = new List<WebBuidingStages>();
            using (AIYunNetContext context = new AIYunNetContext())
            {

                list = context.WebBuidingStages.Where(c => c.WebBuidingID == BuidingID).OrderBy(c => c.sortID).ToList();
                if (list == null)
                {
                    list = new List<WebBuidingStages>();
                }
                return list;
            }

        }
        public WebBuidingStages GetWebBuidingStagesByID(int BuidingID, int StageID)
        {
            WebBuidingStages stage = new WebBuidingStages();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                try
                {
                    stage = context.WebBuidingStages.Where(wc => wc.WebBuidingID == BuidingID && wc.StageID == StageID).ToList()[0];
                }
                catch (Exception e)
                {
                }
                return stage;


            }
        }

        //通过BuidingIDAndStageID获取装修阶段信息
        public WebBuidingStages GetBuidingStageByBuidingIDAndStageID(int buidingID, int stageID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebBuidingStages buidingStage = context.WebBuidingStages.Where(bs => bs.WebBuidingID == buidingID && bs.StageID == stageID).FirstOrDefault();
                if (buidingStage != null)
                {
                    return buidingStage;
                }
                else
                {
                    return null;
                }

            }
        }

        public int UpdateBuidingStagesInfo(WebBuidingStages buidingStage)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebBuidingStages old = context.WebBuidingStages.Find(buidingStage.ID);
                WebBuiding buiding = context.WebBuiding.Find(buidingStage.WebBuidingID);
                if (old != null)
                {
                    old.StageContent = buidingStage.StageContent;
                    old.CompleteTime = DateTime.Now.ToString();
                    old.IsComplete = buidingStage.IsComplete;
                    context.SaveChanges();
                    List<WebBuidingStages> list = new List<WebBuidingStages>();
                    try
                    {
                        list = context.WebBuidingStages.Where(c => c.WebBuidingID == buidingStage.WebBuidingID && c.IsComplete == true).OrderByDescending(c => c.sortID).ToList();
                    }
                    catch (Exception e)
                    {
                        list = new List<WebBuidingStages>();
                    }
                    if (list.Count > 0)
                    {
                        int stageNow = list[0].sortID;
                        buiding.StageNow = stageNow;
                        context.SaveChanges();
                    }                  

                    return 1;
                }
                else
                {
                    return 0;
                }

            }
        }

        //判断是否可以修改阶段
        public int IsCanUpdateStage(int buidingID, int stageID)
        {
            int ret = 0;
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebBuidingStages old = new WebBuidingStages();
                WebBuidingStages current = context.WebBuidingStages.Where(bs => bs.WebBuidingID == buidingID && bs.StageID == stageID).FirstOrDefault();
                if (current.sortID != 0)
                {
                    old = context.WebBuidingStages.Where(bs => bs.WebBuidingID == buidingID && bs.sortID == current.sortID - 1).FirstOrDefault();
                    if (old.IsComplete)
                    {
                        ret = 1;
                    }
                }
                else
                {
                    ret = 1;
                }
            }
            return ret;
        }

        //获取装修阶段和工人信息
        public List<WebBuidingStagesAndWorker> GetStagesWorkerListByID(int BuidingID)
        {
            WebWorkerService Ser = new WebWorkerService();
            List<WebBuidingStagesAndWorker> list = new List<WebBuidingStagesAndWorker>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                List<WebBuidingStages> stagelist= context.WebBuidingStages.Where(c => c.WebBuidingID == BuidingID).OrderBy(c => c.sortID).ToList();
                if (stagelist.Count > 0)
                {
                    foreach (var item in stagelist)
                    {
                        WebBuidingStagesAndWorker link = new WebBuidingStagesAndWorker
                        {
                            stage = item,
                            worker = Ser.GetWebWorkerByID(item.Workerid)
                        };
                        list.Add(link);
                    }
                }
                if (list == null)
                {
                    list = new List<WebBuidingStagesAndWorker>();
                }
                return list;
            }

        }
        //获取合作装修阶段
        public WebBuidingStages GetStageByBuidIDandWorkerid(int buidingID, int workerid)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebBuidingStages buidingStage = context.WebBuidingStages.Where(bs => bs.WebBuidingID == buidingID && bs.Workerid == workerid).FirstOrDefault();
                if (buidingStage != null)
                {
                    return buidingStage;
                }
                else
                {
                    return null;
                }

            }
        }
    }
}
