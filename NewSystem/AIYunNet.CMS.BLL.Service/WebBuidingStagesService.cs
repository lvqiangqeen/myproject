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
    }
}
