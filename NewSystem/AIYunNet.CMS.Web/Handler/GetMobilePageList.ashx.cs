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
    /// GetMobilePageList 的摘要说明
    /// </summary>
    public class GetMobilePageList : IHttpHandler
    {
        HttpContext context = null;
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
        /// 获取订单
        /// </summary>
        public void GetWebBuidingSingleList()
        {
            int pageIndex = string.IsNullOrEmpty(context.Request["pageIndex"]) ? 1 : Convert.ToInt32(context.Request["pageIndex"]);
            int PageSize = Convert.ToInt32(context.Request["PageSize"]);
            string SortOrder = context.Request["SortOrder"];
            string WorkerID = context.Request["WorkerID"];
            string SortParameters = "";
            int pageCount = 0;
            int recordcount = 0;
            string SelectParameters = string.Format("[ID],[WebBuidingStageID],[Title],[TimeStageInfo],[TimeStageContent],[AddTime]"
                 + ",[sortID],[endtime],[FlagDelete],[DeleteOn],[TimeStageThumContent],[WorkerID],[DemandID],[IsUserEnd]"
                 + ",[IsWorkerEnd],[UserID],[Guid],[Price],[Space],[BuidingSingleImage],[thumbnailImage],[EditOn],AddOn");

            SortParameters = string.Format(" FlagDelete=0 {0} ",
                 WorkerID == "0" || string.IsNullOrEmpty(WorkerID) ? "" : "and WorkerID=" + WorkerID);

            Pagination paginfo = new Pagination();
            paginfo.SelectParameters = SelectParameters;
            paginfo.PageIndex = pageIndex;
            paginfo.PageSize = PageSize;
            paginfo.EntityName = "WebBuidingSingle";
            paginfo.SortParameters = SortParameters;
            paginfo.SortOrder = SortOrder + " AddTime desc,ID desc";
            var result = PageList.GetPageListBySQL<WebBuidingSingle>(paginfo, out recordcount, out pageCount);

            var obj = new
            {
                list = result,
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