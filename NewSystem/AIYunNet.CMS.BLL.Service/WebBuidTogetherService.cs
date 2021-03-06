﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Domain.OccaModel;
using AIYunNet.CMS.Domain;
using AIYunNet.CMS.Domain.DataHelper;

namespace AIYunNet.CMS.BLL.Service
{
    public class WebBuidTogetherService
    {
        public WebBuidTogether GetTogetherbyID(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebBuidTogether old = context.WebBuidTogether.Find(id);
                return old;
            }
        }
        //确认合作
        public int IsAccept(int id,int accept)
        {            
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebBuidTogether old = context.WebBuidTogether.Find(id);
                old.IsAccept = accept;
                context.SaveChanges();
                return 1;
            }
        }
        public int AddBuidTogether(WebBuidTogether together)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebBuidTogether.Add(together);
                context.SaveChanges();
                return 1;
            }
        }
        //是否已经选择了伙伴 1有 0没有
        public int IsHaveTogther(int buidingID,int StageID)
        {
            WebBuidTogether tog = new WebBuidTogether();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                tog=context.WebBuidTogether.FirstOrDefault(c=>c.buidingID== buidingID && c.StageID== StageID && c.IsAccept==0);
                if (tog != null)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
                
            }
        }
        //获取合作项目
        public List<BuidTogether> GetTogetherList(int GetWorkerid,int PageSize,int CurPage, out int count)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                //list = context.WebBuidTogether.Where(c => c.GetWorkerid == GetWorkerid && c.IsAccept == isAccept).ToList();              
                var query = from c in context.WebBuidTogether
                            from d in context.WebBuiding
                            from b in context.WebWorker
                            from e in context.WebBuidingStages
                            from y in context.DecDemand
                            where c.buidingID == d.BuidingID && (c.buidingID == e.WebBuidingID && c.StageID == e.StageID)
                            && c.PublishWorkerid == b.WorkerID && c.GetWorkerid == GetWorkerid && d.DemandID==y.id
                            select new BuidTogether
                            {
                                id=c.id,
                                buidingID= c.buidingID,
                                stageid=c.StageID,
                                buidingName=d.BuidingTitle,
                                stagename=e.StageName,
                                cityName=y.CityName,
                                PublishWorkerid= b.WorkerID,
                                PublishWorkerName =b.WorkerName,
                                PublishWorkerTel=b.WorkerPhone,
                                startTime=d.StartTime,
                                demandid=y.id,
                                ownername=y.ownername,
                                ownertel=y.ownertel,
                                IsAccept=c.IsAccept,                                
                                IsComplete = e.IsComplete,
                                IsUserEnd = e.IsUserEnd
                            };
                count = query.ToList().Count();
                List<BuidTogether> list = query.ToList().Skip(PageSize * (CurPage - 1)).Take(PageSize * CurPage).ToList();
                return list;
            }
        }


        //mobile获取合作项目
        public List<BuidTogether> GetmTogetherList(int IsAccept,int IsComplete, int GetWorkerid, int PageSize, int CurPage, out int count)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                //list = context.WebBuidTogether.Where(c => c.GetWorkerid == GetWorkerid && c.IsAccept == isAccept).ToList();              
                var query = from c in context.WebBuidTogether
                            from d in context.WebBuiding
                            from b in context.WebWorker
                            from e in context.WebBuidingStages
                            from y in context.DecDemand
                            where c.buidingID == d.BuidingID && (c.buidingID == e.WebBuidingID && c.StageID == e.StageID)
                            && c.PublishWorkerid == b.WorkerID && c.GetWorkerid == GetWorkerid && d.DemandID == y.id
                            select new BuidTogether
                            {
                                id = c.id,
                                buidingID = c.buidingID,
                                stageid = c.StageID,
                                buidingName = d.BuidingTitle,
                                stagename = e.StageName,
                                cityName = y.CityName,
                                PublishWorkerid = b.WorkerID,
                                PublishWorkerName = b.WorkerName,
                                PublishWorkerTel = b.WorkerPhone,
                                startTime = d.StartTime,
                                demandid = y.id,
                                ownername = y.ownername,
                                ownertel = y.ownertel,
                                IsAccept = c.IsAccept,
                                IsComplete=e.IsComplete,
                                IsUserEnd=e.IsUserEnd
                            };
                count = query.ToList().Count();

                List<BuidTogether> list = query.ToList();
                bool iscom = IsComplete == 0 ? false : true;
                if (IsAccept != 1)
                {
                    list = query.ToList().Where(c => c.IsAccept == IsAccept).Skip(PageSize * (CurPage - 1)).Take(PageSize * CurPage).ToList();
                } else
                {
                    list = query.ToList().Where(c => c.IsAccept == 1 && c.IsComplete == iscom).Skip(PageSize * (CurPage - 1)).Take(PageSize * CurPage).ToList();
                }
                return list;
            }
        }
        //为查看合作清单
        public int TogtherNoSee(int workerid)
        {
            int ret = 0;
            List<WebBuidTogether> list = new List<WebBuidTogether>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                list = context.WebBuidTogether.Where(c => c.GetWorkerid == workerid && c.IsAccept==0).ToList();
                if (list != null)
                {
                    ret = list.Count();
                }
                return ret;
            }
        }
    }
}
