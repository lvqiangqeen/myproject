﻿using System;
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
        public int IsOutByGuID(int GetUserID,string guid)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                DecDemand model = new DecDemand();
                if (guid != "")
                {
                    model = context.DecDemand.FirstOrDefault(c => c.Guid == guid);
                }
                model.IsOut = true;
                WebBuiding buiding = context.WebBuiding.FirstOrDefault(c => c.Guid== guid);

                if (buiding != null)
                {
                    context.WebBuiding.Remove(buiding);
                }
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
        public List<Demand> GetTingDemandList(int type,string cityid, int PageSize, int CurPage, out int count)
        {
            List<Demand> list = new List<Demand>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                var query = from d in context.DecDemand
                            where d.DemandType == type && d.IsDelete == false && d.GetUserID==0 
                            && d.IsAccept==0 
                            select new Demand
                            {
                                id = d.id,
                                IsOut = d.IsOut,
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
                                AddOn = d.EditOn,
                                IsEnd = d.IsEnd,
                                IsVerrify = d.IsVerrify,
                                DemandType = d.DemandType,
                                DemandTypeName = d.DemandTypeName,
                                Guid = d.Guid,
                                HouseType = d.HouseType,
                                IsPlan = d.IsPlan,
                                AcceptUserID = d.GetUserID,
                                IsAccept = d.IsAccept,
                                AcceptUserName = context.WebWorker.FirstOrDefault(w => w.UserID == d.GetUserID).WorkerName,
                                GetUserName = context.WebWorker.FirstOrDefault(w => w.UserID == d.GetUserID).WorkerName
                            };
                if (cityid != "" && cityid!=null)
                {
                    query = query.Where(c => c.CityID == cityid);
                }
                count = query.ToList().Count();

                list = query.OrderByDescending(c => c.AddOn).ToList().Skip(PageSize * (CurPage - 1)).Take(PageSize * CurPage).ToList();
            }

            return list;
        }
        //获取用户发布的需求
        public List<Demand> GetPublishDemandList(int PublicUserID, int PageSize, int IsAccept, int IsPlan,int IsOut, int CurPage, out int count)
        {
            List<Demand> list = new List<Demand>();
            bool isplan = IsPlan == 1 ? true : false;
            using (AIYunNetContext context = new AIYunNetContext())
            {
                var query = from d in context.DecDemand
                            where d.PublishuserID == PublicUserID && d.IsDelete == false
                            select new Demand
                            {
                                id = d.id,
                                IsOut=d.IsOut,
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
                                AddOn = d.EditOn,
                                IsEnd = d.IsEnd,
                                IsVerrify = d.IsVerrify,
                                DemandType = d.DemandType,
                                DemandTypeName = d.DemandTypeName,
                                Guid = d.Guid,
                                HouseType = d.HouseType,
                                IsPlan = d.IsPlan,
                                AcceptUserID = d.GetUserID,
                                IsAccept = d.IsAccept,
                                AcceptUserName = context.WebWorker.FirstOrDefault(w => w.UserID == d.GetUserID).WorkerName,
                                GetUserName = context.WebWorker.FirstOrDefault(w => w.UserID == d.GetUserID).WorkerName
                            };
                count = query.ToList().Count();
                bool isout = IsOut == 1 ? true : false;
                if (isout)
                {
                    query = query.Where(c => c.IsAccept == 2 || c.IsOut == isout);
                }
                else if (IsAccept == 1 && !isout)
                {
                    query = query.Where(c => c.IsAccept == IsAccept && c.IsOut == isout && c.IsPlan == isplan);
                }
                else
                {
                    query = query.Where(c => c.IsAccept == IsAccept && c.IsPlan == isplan);
                }
                
                list = query.OrderByDescending(c => c.AddOn).ToList().Skip(PageSize * (CurPage - 1)).Take(PageSize * CurPage).ToList();
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
                DecDemand.IsAccept = 0;
                DecDemand.GetUserID = DecDemand.GetUserID;
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
                WebBuidingService buidingSer = new WebBuidingService();

                if (old != null)
                { 

                    if (DecDemand.GetUserID != 0)
                    {
                        if (accold != null)
                        {
                            DecDemandAccept oldacc = context.DecDemandAccept.FirstOrDefault(c => c.DemandGuid == accold.DemandGuid);
                            oldacc.GetUserID= DecDemand.GetUserID;
                            oldacc.PublicUserID= DecDemand.PublishuserID;
                            oldacc.IsAccept = 0;
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
                    old.IsAccept = 0;
                    old.GetUserID= DecDemand.GetUserID;

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
                    old.IsPlan = false;
                    old.IsOut = false;
                    WebBuiding buiding = buidingSer.GetWebBuidingByGuID(DecDemand.Guid);
                    if (buiding != null)
                    {
                        buidingSer.DeleteWebBuiding(buiding.BuidingID);
                    }

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
