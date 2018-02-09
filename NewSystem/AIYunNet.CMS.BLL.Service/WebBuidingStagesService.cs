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
    }
}
