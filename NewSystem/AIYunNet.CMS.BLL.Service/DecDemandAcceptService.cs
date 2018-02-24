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
        public DecDemandAccept GetAcceptByGuid(string guid)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                DecDemandAccept old = context.DecDemandAccept.FirstOrDefault(c => c.DemandGuid == guid);
                return old;
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

        //只修改GetUserID
        public int UpdateIsAccept(DecDemandAccept acc)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                DecDemandAccept old = context.DecDemandAccept.FirstOrDefault(c=>c.DemandGuid== acc.DemandGuid);
                if (old != null)
                {
                    old.IsAccept = acc.IsAccept;

                    if (acc.IsAccept == 1)
                    {
                        DecDemand dec = context.DecDemand.FirstOrDefault(c => c.Guid == acc.DemandGuid);
                        dec.GetUserType = "WebUser";
                        dec.GetUserID = old.GetUserID;                       
                    }
                    context.SaveChanges();
                }
                return 1;
            }
        }
    }
}
