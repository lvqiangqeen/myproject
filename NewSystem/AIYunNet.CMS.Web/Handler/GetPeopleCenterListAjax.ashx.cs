using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using AIYunNet.CMS.Common.Utility.Model;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.BLL.IService;

namespace AIYunNet.CMS.Web.Handler
{
    /// <summary>
    /// GetPeopleCenterListAjax 的摘要说明
    /// </summary>
    public class GetPeopleCenterListAjax : IHttpHandler
    {
        HttpContext context = null;
        WebBuidingStagesService SageSer = new WebBuidingStagesService();
        WebBuidingCaseCommentService commentSer = new WebBuidingCaseCommentService();
        DemandService demandSer = new DemandService();
        WebWorkerService worser = new WebWorkerService();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            this.context = context;
            string methodName = context.Request["methodname"];
            System.Reflection.MethodInfo method = this.GetType().GetMethod(methodName);
            method.Invoke(this, null);
        }

        /// <summary>
        /// 获取所有装修信息
        /// </summary>
        public void GetCenterBuidingDetailList()
        {
            int pageIndex = string.IsNullOrEmpty(context.Request["pageIndex"]) ? 1 : Convert.ToInt32(context.Request["pageIndex"]);
            int PageSize = Convert.ToInt32(context.Request["PageSize"]);
            string UserID= context.Request["UserID"];
            string SortOrder = context.Request["SortOrder"];
            string SortParameters = "";
            int pageCount = 0;
            int recordcount = 0;
            string SelectParameters = string.Format("[BuidingID],[BuidingTitle],[BuidingBrief],[BuidingInfo],"
                +"[CompanyID],[WorkerID],[thumbnailImage],[BuidingImage],[ShowOrder],[AddOn],[EditOn],[DeleteOn],"
                +"[FlagDelete],[PageViewCount],[CollectCount],[ZanCount],[CommentCount],[IsHot],[IsTop],[Price],[Space],"
                +"[constructionstageID],[constructionstage],[ResultID],[StartTime],[StageNow],[EndTime],"
                +"[superviseName],[UserID],[DemandID],[IsWorkerEnd],[IsUserEnd],[Guid]");

            SortParameters = string.Format(" FlagDelete=0 {0} ",
                 UserID == "0" || string.IsNullOrEmpty(UserID) ? "" : "and UserID=" + UserID);

            Pagination paginfo = new Pagination();
            paginfo.SelectParameters = SelectParameters;
            paginfo.PageIndex = pageIndex;
            paginfo.PageSize = PageSize;
            paginfo.EntityName = "WebBuiding";
            paginfo.SortParameters = SortParameters;
            paginfo.SortOrder = SortOrder + " AddOn desc,BuidingID desc";
            var result = PageList.GetPageListBySQL<WebBuiding>(paginfo, out recordcount, out pageCount);
            List<BuidingDetail> list = new List<BuidingDetail>();
            foreach (var item in result)
            {
                BuidingDetail detail = new BuidingDetail
                {
                    woker = worser.GetWebWorkerByID(item.WorkerID),
                    buiding = item,
                    stagelist = SageSer.GetStagesWorkerListByID(item.BuidingID),
                    demand = demandSer.GetDecDemandByGuID(item.Guid),
                    comment= commentSer.GetCommentByTypeAndID("WebBuiding", item.BuidingID)
                };
                list.Add(detail);
            }
            var obj = new
            {
                list = list,
                recordcount = recordcount,
                pageCount = pageCount
            };
            string msg = JsonConvert.SerializeObject(obj);
            context.Response.Write(msg);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}