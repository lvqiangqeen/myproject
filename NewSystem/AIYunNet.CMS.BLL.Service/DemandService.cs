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
    public class DemandService
    {
        public DecDemand GetDecDemandByID(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                DecDemand model = context.DecDemand.Find(id);
                return model;
            }
        }

        public List<DecDemand> GetDecDemandListByUserIDAndType(int UserID,string UserType)
        {
            List<DecDemand> list = new List<DecDemand>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                try
                {
                    list = context.DecDemand.Where(c => c.GetUserID == UserID && c.GetUserType == UserType).OrderByDescending(c => c.AddOn).ToList();
                    if (list == null)
                    {
                        list = new List<DecDemand>();
                    }
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
