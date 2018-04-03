using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Domain;
using AIYunNet.CMS.Domain.OccaModel;
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
        //未查看的需求
        public int DemandToYou(int UserID)
        {
            int ret = 0;
            List<DecDemandAccept> list = new List<DecDemandAccept>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                try
                {
                    list = context.DecDemandAccept.Where(c => c.GetUserID == UserID && c.IsAccept==0).ToList();
                    if (list != null)
                    {
                        ret = list.Count();

                    }
                    return ret;
                }
                catch (Exception e)
                {
                    return 0;
                }
            }
        }
        //获取发给工人的需求清单
        public List<AcceptDemand> GetDemandListByUserID(int UserID,int PageSize,int CurPage,out int count)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                var query = from c in context.DecDemandAccept
                            from d in context.DecDemand
                            where c.DemandGuid == d.Guid
                            && c.GetUserID == UserID && d.IsDelete==false
                            select new AcceptDemand
                            {
                                id = d.id,
                                buidingname=d.buidingname,
                                ownername = d.ownername,
                                ownertel = d.ownertel,
                                ProvinceID = d.ProvinceID,
                                ProvinceName = d.ProvinceName,
                                CityID = d.CityID,
                                CityName=d.CityName,
                                buidingSpace = d.buidingSpace,
                                OneSentence = d.OneSentence,
                                PublishuserID = d.PublishuserID,
                                GetUserID = d.GetUserID,
                                GetUserType=d.GetUserType,
                                AddOn = d.AddOn,
                                IsEnd=d.IsEnd,
                                IsVerrify = d.IsVerrify,
                                DemandType=d.DemandType,
                                DemandTypeName =d.DemandTypeName,
                                Guid=d.Guid,
                                HouseType=d.HouseType,
                                IsPlan=d.IsPlan,
                                AcceptUserID=c.GetUserID,
                                IsAccept=c.IsAccept
                            };
                count = query.ToList().Count();
                List<AcceptDemand> list = query.ToList().Skip(PageSize * (CurPage - 1)).Take(PageSize * CurPage).ToList();
                return list;
            }
        }

        //获取发给工人的需求清单手机端
        public List<AcceptDemand> mGetDemandListByUserID(int isall, int IsAccept, int IsPlan,int UserID, int PageSize, int CurPage, out int count)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

                    var query = from c in context.DecDemandAccept
                                from d in context.DecDemand
                                where c.DemandGuid == d.Guid
                                && c.GetUserID == UserID && d.IsDelete == false

                                select new AcceptDemand
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
                                    IsAccept = c.IsAccept
                                };
                bool plan = IsPlan == 1 ? true : false;
                count = query.ToList().Count();
                if (isall == 0)
                {
                    query = query.Where(c => c.IsPlan == plan);
                }           
                List<AcceptDemand> list = query.ToList().Skip(PageSize * (CurPage - 1)).Take(PageSize * CurPage).ToList();
                return list;
            }
        }
    }
}
