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
    public class DecDemandAcceptService
    {
        public int AddDecDemandAccept(DecDemandAccept DecDemand)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.DecDemandAccept.Add(DecDemand);
                context.SaveChanges();
                return 1;
            }
        }

        public List<DecDemandAccept> GetListByGetUserID(int UserID)
        {
            List<DecDemandAccept> list = new List<DecDemandAccept>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                try
                {
                    list = context.DecDemandAccept.Where(c => c.GetUserID == UserID).ToList();
                    if (list == null)
                    {
                        list = new List<DecDemandAccept>();
                    }
                    return list;
                }
                catch (Exception e)
                {
                    return list;
                }
            }
        }

        public List<DecDemandAccept> GetListByPublicUserID(int UserID)
        {
            List<DecDemandAccept> list = new List<DecDemandAccept>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                try
                {
                    list = context.DecDemandAccept.Where(c => c.PublicUserID == UserID).ToList();
                    if (list == null)
                    {
                        list = new List<DecDemandAccept>();
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
