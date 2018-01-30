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
    public class WebBuidingTimeStagesService
    {
        //根据ID获取时间阶段
        public List<WebBuidingTimeStages> GetTimeStagesList(int BuidingStageID)
        {
            List<WebBuidingTimeStages> list = new List<WebBuidingTimeStages>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                try
                {
                    list= context.WebBuidingTimeStages.Where(wc => wc.FlagDelete == false && wc.WebBuidingStageID == BuidingStageID).OrderByDescending(c => c.ID).ToList();
                    return list;
                }
                catch (Exception e)
                {
                    return list;
                } 
                
            }
        }
    }
}
