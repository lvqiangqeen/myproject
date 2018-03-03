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
        public List<WebWorker> GetWebWorkerList()
        {
            List<WebWorker> list = new List<WebWorker>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                list = context.WebWorker.Where(c => c.WorkerCategory == "装修工长").ToList();
                return list;
            }
        }
        public WebWorker GetWebWorkerByID(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebWorker.Find(id);
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
    }
}
