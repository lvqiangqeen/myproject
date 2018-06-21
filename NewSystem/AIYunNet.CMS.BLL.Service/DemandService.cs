using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Domain;
using AIYunNet.CMS.Domain.DataHelper;
using AIYunNet.CMS.Domain.OccaModel;
using System.Data;

namespace AIYunNet.CMS.BLL.Service
{
    public class DemandService
    {
        public int IsOutByGuID(string guid)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                DecDemand model = new DecDemand();
                if (guid != "")
                {
                    model = context.DecDemand.FirstOrDefault(c => c.Guid == guid);
                }
                model.IsOut = true;
                context.SaveChanges();
                return 1;
            }
        }
        public DecDemand GetDecDemandByID(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                DecDemand model = new DecDemand();
                if (id != 0)
                {
                    model = context.DecDemand.Find(id);
                }
                return model;
            }
        }
        public DecDemand GetDecDemandByGuID(string guid)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                DecDemand model = new DecDemand();
                if (guid != "")
                {
                    model = context.DecDemand.FirstOrDefault(c => c.Guid == guid);
                }
                return model;
            }
        }
        public List<DecDemand> GetDecDemandListByUserIDAndType(int UserID, string UserType)
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
        //获取用户发布的需求
        public List<Demand> GetPublishDemandList(int PublicUserID, int PageSize, int IsAccept, int IsPlan, int CurPage, out int count)
        {
            List<Demand> list = new List<Demand>();
            bool isplan = IsPlan == 1 ? true : false;
            using (AIYunNetContext context = new AIYunNetContext())
            {
                var query = from c in context.DecDemandAccept
                            from d in context.DecDemand
                            where c.DemandGuid == d.Guid
                            && c.PublicUserID == PublicUserID && d.IsDelete == false
                            && c.IsAccept== IsAccept && d.IsPlan == isplan
                            select new Demand
                            {
                                id = d.id,
                                buidingname = d.buidingname,
                                ownername = d.ownername,
                                ownertel = d.ownertel,
                                ProvinceID = d.ProvinceID,
                                ProvinceName = d.ProvinceName,
                                CityID = d.CityID,
                                CityName = d.CityName,
                                buidingSpace = d.buidingSpace,
                                OneSentence = d.OneSentence,
                                PublishuserID = d.PublishuserID,
                                GetUserID = d.GetUserID,
                                GetUserType = d.GetUserType,
                                AddOn = d.AddOn,
                                IsEnd = d.IsEnd,
                                IsVerrify = d.IsVerrify,
                                DemandType = d.DemandType,
                                DemandTypeName = d.DemandTypeName,
                                Guid = d.Guid,
                                HouseType = d.HouseType,
                                IsPlan = d.IsPlan,
                                AcceptUserID = c.GetUserID,
                                IsAccept = c.IsAccept,
                                AcceptUserName = context.WebWorker.FirstOrDefault(w => w.UserID == c.GetUserID).WorkerName,
                                GetUserName = context.WebWorker.FirstOrDefault(w => w.UserID == d.GetUserID).WorkerName
                            };
                count = query.ToList().Count();
                list = query.ToList().Skip(PageSize * (CurPage - 1)).Take(PageSize * CurPage).ToList();
            }

            return list;
        }
        public List<DecDemand> GetMyDecDemandList(int PublishUserID)
        {
            List<DecDemand> list = new List<DecDemand>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                try
                {
                    list = context.DecDemand.Where(c => c.PublishuserID == PublishUserID && c.IsDelete == false).OrderByDescending(c => c.AddOn).ToList();
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
        //添加需求时同时添加对谁的需求
        public int AddDecDemand(DecDemand DecDemand)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (DecDemand.GetUserID != 0)
                {
                    DecDemandAccept acc = new DecDemandAccept();
                    acc.DemandGuid = DecDemand.Guid;
                    acc.GetUserID = DecDemand.GetUserID;
                    acc.PublicUserID = DecDemand.PublishuserID;
                    acc.IsAccept = 0;
                    DecDemandAcceptService ser = new DecDemandAcceptService();
                    ser.AddDecDemandAccept(acc);
                }

                DecDemand.GetUserID = 0;
                DecDemand.GetUserType = "";
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
                DecDemandAcceptService ser = new DecDemandAcceptService();
                DecDemandAccept accold = ser.GetAcceptByGuid(DecDemand.Guid);
                if (old != null)
                { 

                    if (DecDemand.GetUserID != 0)
                    {
                        if (accold != null)
                        {
                            accold.GetUserID= DecDemand.GetUserID;
                            accold.PublicUserID= DecDemand.PublishuserID;
                            accold.IsAccept = 0;
                        }
                        else
                        {
                            DecDemandAccept acc = new DecDemandAccept();
                            acc.DemandGuid = DecDemand.Guid;
                            acc.GetUserID = DecDemand.GetUserID;
                            acc.PublicUserID = DecDemand.PublishuserID;
                            acc.IsAccept = 0;
                            ser.AddDecDemandAccept(acc);
                        }

                    }
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
                    old.HouseType = DecDemand.HouseType;
                    context.SaveChanges();
                }
                return 1;
            }
        }

        public int DeleteDecDemand(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                DecDemand original = context.DecDemand.Find(id);
                if (original != null)
                {
                    original.IsDelete = true;
                    original.DeleteOn = DateTime.Now;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        //只修改GetUserID
        public int UpdateDecDemandGetUser(DecDemand DecDemand)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                DecDemand old = context.DecDemand.Find(DecDemand.id);
                if (old != null)
                {
                    old.GetUserID = DecDemand.GetUserID;
                    old.GetUserType = DecDemand.GetUserType;
                    context.SaveChanges();
                }
                return 1;
            }
        }
    }
}
