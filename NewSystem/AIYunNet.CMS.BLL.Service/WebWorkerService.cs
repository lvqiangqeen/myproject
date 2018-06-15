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
    public class WebWorkerService
    {
        /// <summary>
        /// 通过审核
        /// </summary>
        public int PassCheckByWorker(int userid,bool IsApproved)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebWorker work = context.WebWorker.FirstOrDefault(c => c.UserID == userid);
                work.IsApproved = IsApproved;
                context.SaveChanges();
                return 1;
            }
        }
        /// <summary>
        /// 手机端选取工人
        /// </summary>
        public List<WebWorker> mGetWorker(string WorkerName, int PageIndex, int PageSize, string WorkerCategory, string WorkerPositionID)
        {
            List<WebWorker> list = new List<WebWorker>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (WorkerName != "")
                {
                    list = context.WebWorker.Where(c => c.FlagDelete == 0 && c.WorkerName.Contains(WorkerName)).OrderByDescending(wb => wb.Stars).Skip(PageSize * (PageIndex - 1)).Take(PageSize * PageIndex).ToList();
                    return list;
                }
                if (WorkerCategory == "装修工长")
                {
                    list = context.WebWorker.Where(c =>c.FlagDelete == 0 && c.WorkerCategory == WorkerCategory).OrderByDescending(wb => wb.Stars).Skip(PageSize * (PageIndex - 1)).Take(PageSize * PageIndex).ToList();
                    return list;
                }
                else
                {
                    if (WorkerPositionID == "0")
                    {
                        list = context.WebWorker.Where(c =>c.FlagDelete == 0 && c.WorkerCategory == WorkerCategory).OrderByDescending(wb => wb.Stars).Skip(PageSize * (PageIndex - 1)).Take(PageSize * PageIndex).ToList();
                    }
                    else
                    {
                        list = context.WebWorker.Where(c =>c.FlagDelete == 0 && c.WorkerCategory == WorkerCategory && c.WorkerPositionID == WorkerPositionID).OrderByDescending(wb => wb.Stars).Skip(PageSize * (PageIndex - 1)).Take(PageSize * PageIndex).ToList();
                    }

                    return list;
                }
            }
        }
        /// <summary>
        /// 手机端选取合作工人
        /// </summary>
        public List<WebWorker> mGetWorkerExceptSelf(int workerid, string WorkerName,int PageIndex,int PageSize,string WorkerCategory,string WorkerPositionID)
        {
            List<WebWorker> list = new List<WebWorker>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (WorkerName != "")
                {
                    list = context.WebWorker.Where(c => c.WorkerID != workerid && c.FlagDelete == 0 && c.WorkerName.Contains(WorkerName)).OrderByDescending(wb => wb.Stars).Skip(PageSize * (PageIndex - 1)).Take(PageSize * PageIndex).ToList();
                    return list;
                }
                if (WorkerCategory == "装修工长")
                {
                    list = context.WebWorker.Where(c => c.WorkerID != workerid && c.FlagDelete == 0 && c.WorkerCategory == WorkerCategory).OrderByDescending(wb => wb.Stars).Skip(PageSize * (PageIndex - 1)).Take(PageSize * PageIndex).ToList();
                    return list;
                }
                else
                {
                    if (WorkerPositionID == "0")
                    {
                        list = context.WebWorker.Where(c => c.WorkerID != workerid && c.FlagDelete == 0 && c.WorkerCategory == WorkerCategory).OrderByDescending(wb => wb.Stars).Skip(PageSize * (PageIndex - 1)).Take(PageSize * PageIndex).ToList();
                    }
                    else
                    {
                        list = context.WebWorker.Where(c => c.WorkerID != workerid && c.FlagDelete == 0 && c.WorkerCategory == WorkerCategory && c.WorkerPositionID == WorkerPositionID).OrderByDescending(wb => wb.Stars).Skip(PageSize * (PageIndex - 1)).Take(PageSize * PageIndex).ToList();
                    }

                    return list;
                }
            }
        }
        /// <summary>
        /// 选取合作工人
        /// </summary>
        public List<WebWorker> GetWorkerExceptSelf(int workerid,string WorkerName)
        {
            List<WebWorker> list = new List<WebWorker>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (WorkerName == "")
                {
                    list = context.WebWorker.Where(c => c.WorkerID != workerid && c.FlagDelete == 0).ToList();
                } else
                {
                    list = context.WebWorker.Where(c => c.WorkerID != workerid && c.FlagDelete == 0 && c.WorkerName.Contains(WorkerName)).ToList();
                }
                
                return list;
            }
        }
        public List<WebWorker> GetWebWorkerList()
        {
            List<WebWorker> list = new List<WebWorker>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                list = context.WebWorker.Where(c => c.WorkerCategory == "装修工长" && c.FlagDelete == 0).ToList();
                return list;
            }
        }
        public WebWorker GetWebWorkerByID(int id)
        {
            WebWorker worker = new WebWorker();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                worker = context.WebWorker.Find(id);
                if (worker == null)
                {
                    worker = new WebWorker();
                }
                return worker;
            }
        }
        public bool IsHaveWorker(int UserID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebWorker WebWorker = context.WebWorker.FirstOrDefault(us => us.UserID == UserID);
                return WebWorker != null ? true : false;
            }
        }

        /// <summary>
        /// 通过UserID获取单个人员
        /// </summary>
        public WebWorker GetWebWorkerByUserID(int userID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebWorker.FirstOrDefault(c => c.UserID == userID);
            }
        }
        /// <summary>
        /// 从个人中心修改
        /// </summary>
        public int UpdateWebWorkerFromCenter(WebWorker webworker)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (webworker != null)
                {
                    WebWorker originalPeople = context.WebWorker.Find(webworker.WorkerID);
                    if (originalPeople != null)
                    {
                        originalPeople.EditOn = DateTime.Now;
                        originalPeople.WorkerCategory = webworker.WorkerCategory;
                        originalPeople.WorkerMail = webworker.WorkerMail;
                        originalPeople.WorkerName = webworker.WorkerName;
                        originalPeople.WorkerPhone = webworker.WorkerPhone;
                        originalPeople.WorkerImage = webworker.WorkerImage;
                        originalPeople.thumbnailImage = webworker.thumbnailImage == null ? "" : webworker.thumbnailImage;
                        originalPeople.ProvinceID = webworker.ProvinceID;
                        originalPeople.ProvinceName = webworker.ProvinceName;
                        originalPeople.CityID = webworker.CityID;
                        originalPeople.CityName = webworker.CityName;
                        originalPeople.AreasID = webworker.AreasID;
                        originalPeople.AreasName = webworker.AreasName;
                        context.SaveChanges();
                    }
                }
                return 1;
            }
        }

        /// <summary>
        /// 从个人中心详情页面修改
        /// </summary>
        public int UpdateWebWorkerFromCenterDetail(WebWorker WebWorker)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (WebWorker != null)
                {
                    WebWorker originalPeople = context.WebWorker.Find(WebWorker.WorkerID);
                    if (originalPeople != null)
                    {
                        originalPeople.WorkerPositionID = WebWorker.WorkerPositionID;
                        originalPeople.WorkerPosition = WebWorker.WorkerPosition;
                        originalPeople.WorkYearsID = WebWorker.WorkYearsID;
                        originalPeople.WorkYears = WebWorker.WorkYears;
                        originalPeople.PriceName = WebWorker.PriceName;
                        //originalPeople.BelongArea = webPeople.BelongArea;
                        //originalPeople.CaseCount = webPeople.CaseCount;
                        originalPeople.EditOn = DateTime.Now;
                        originalPeople.GoodAtStyle = WebWorker.GoodAtStyle;
                        //originalPeople.IsApproved = webPeople.IsApproved;
                        //originalPeople.IsAuthentication = webPeople.IsAuthentication;
                        //originalPeople.IsBond = webPeople.IsBond;
                        //originalPeople.IsBuildingCount = webPeople.IsBuildingCount;
                        //originalPeople.IsTop = webPeople.IsTop;
                        originalPeople.WorkerInfo = WebWorker.WorkerInfo;
                        //originalPeople.PeopleLevel = webPeople.PeopleLevel;
                        originalPeople.WorkerMotto = WebWorker.WorkerMotto;

                        //originalPeople.ShowOrder = webPeople.ShowOrder;
                        context.SaveChanges();
                    }
                }


                return 1;
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        public int AddWebWorker(WebWorker WebWorker)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebWorker.Add(WebWorker);
                context.SaveChanges();
                return 1;
            }
        }

        WebCommonService cSer = new WebCommonService();
        //在手机端修改worker
        public int UpdateWebWorkerFromMobile(int id, string data, string type)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebWorker originalWorker = context.WebWorker.Find(id);
                if (originalWorker != null)
                {

                    switch (type)
                    {
                        case "WorkYearsID":
                            originalWorker.WorkYearsID = Convert.ToInt32(data);
                            originalWorker.WorkYears= cSer.GetLookupDesc("people_workyear", data);
                            break;
                        case "WorkerPositionID":
                            originalWorker.WorkerPositionID = data;
                            originalWorker.WorkerPosition = cSer.GetLookupDesc("workers_position", data);
                            break;
                        case "PriceName":
                            originalWorker.PriceName = data;
                            break;
                        case "GoodAtStyle":
                            originalWorker.GoodAtStyle = data;
                            break;

                        case "WorkerMotto":
                            originalWorker.WorkerMotto = data;
                            break;
                        case "WorkerInfo":
                            originalWorker.WorkerInfo = data;
                            break;
                        default:

                            break;
                    }
                    originalWorker.EditOn = DateTime.Now;
                    context.SaveChanges();
                }
                return 1;
            }
        }

       
    }
}
