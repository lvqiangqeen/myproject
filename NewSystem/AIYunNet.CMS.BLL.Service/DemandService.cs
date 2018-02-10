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

        public List<DecDemand> GetMyDecDemandList(int PublishUserID)
        {
            List<DecDemand> list = new List<DecDemand>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                try
                {
                    list = context.DecDemand.Where(c => c.PublishuserID == PublishUserID && c.IsDelete==false).OrderByDescending(c => c.AddOn).ToList();
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

        public int AddDecDemand(DecDemand DecDemand)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.DecDemand.Add(DecDemand);
                context.SaveChanges();
                return 1;
            }
        }

        public int UpdateDecDemand(DecDemand DecDemand)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                DecDemand old = context.DecDemand.Find(DecDemand.id);
                if (old != null)
                {
                    old.ownername = DecDemand.ownername;
                    old.ownertel = DecDemand.ownertel;
                    old.ProvinceID = DecDemand.ProvinceID;
                    old.ProvinceName = DecDemand.ProvinceName;
                    old.OneSentence = DecDemand.OneSentence;
                    old.IsPublish = DecDemand.IsPublish;
                    old.Info = DecDemand.Info;
                    old.EditOn = DateTime.Now;
                    old.DemandType = DecDemand.DemandType;
                    old.DemandTypeName = DecDemand.DemandTypeName;
                    old.CityID = DecDemand.CityID;
                    old.CityName = DecDemand.CityName;
                    old.buidingSpace = DecDemand.buidingSpace;
                    old.buidingname = DecDemand.buidingname;
                    context.SaveChanges();
                }
                return 1;
            }
        }
    }
}
