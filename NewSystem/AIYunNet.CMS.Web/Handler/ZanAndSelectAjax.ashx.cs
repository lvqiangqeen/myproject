using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AIYunNet.CMS.Common.Utility.Model;
using AIYunNet.CMS.Common.Utility.Tools;
using AIYunNet.CMS.Domain.DataHelper;
using System.Data;

namespace AIYunNet.CMS.Web.Handler
{
    /// <summary>
    /// ZanAndSelectAjax 的摘要说明
    /// </summary>
    public class ZanAndSelectAjax : IHttpHandler
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
        /// 点赞
        /// </summary>
        public void ZanClick()
        {
            var obj = new object();
            string DBCode = context.Request["DBCode"];
            string DBId = context.Request["DBId"];
            string IdName= context.Request["IdName"];
            Security sec = new Security();
            string key = sec.GetRequestKey();
            MsSqlDataSource mysqlD = new MsSqlDataSource();
            string selectStr = string.Format("select id from Zan where RequestKey='{0}' and AddTime='{1}' and DBCode='{2}' and DBId='{3}'", key, DateTime.Now.ToString("yyyy-MM-dd"), DBCode, DBId);
            DataTable table = mysqlD.ExecuteDataTable(selectStr);
            if (table.Rows.Count > 0)
            {
                obj = new
                {
                    ZanCount = "",
                    statu = 0
                };
            }
            else
            {
                string insertStr = string.Format("insert into Zan(RequestKey,DBCode,DBId,AddTime) values ('{0}','{1}','{2}','{3}')", key, DBCode, DBId, DateTime.Now.ToString("yyyy-MM-dd"));
                int statu = mysqlD.ExecuteNonQuery(insertStr);
                //获取点赞数量
                string select = string.Format("select ZanCount from {0} where {1}='{2}'", DBCode, IdName, DBId);               
                DataTable ZanTable = mysqlD.ExecuteDataTable(select);
                int ZanCount = 0;
                if (ZanTable.Rows.Count > 0)
                {
                    ZanCount = Convert.ToInt32(ZanTable.Rows[0]["ZanCount"]) + 1;
                }
                string updateStr = string.Format("update {0} set ZanCount={3} where {1}='{2}'", DBCode, IdName, DBId, ZanCount);
                mysqlD.ExecuteNonQuery(updateStr);
                
                obj = new
                {
                    ZanCount = ZanCount,
                    statu = statu
                };
                
            }
            string msg = JsonConvert.SerializeObject(obj);
            context.Response.Write(msg);
        }

        /// <summary>
        /// 收藏
        /// </summary>
        public void CollectionClick()
        {
            var obj = new object();
            string DBCode = context.Request["DBCode"];
            string DBId = context.Request["DBId"];
            string IdName = context.Request["IdName"];
            string DBUrl= context.Request["DBUrl"];
            string DBTitle= context.Request["DBTitle"];
            string UserName= context.Request["UserName"];
            string UserType = context.Request["UserType"];
            if (UserName == "")
            {
                //没检测到用户
                obj = new
                {
                    CollectCount = "",
                    statu = -1
                };
            }
            else
            {
                MsSqlDataSource mysqlD = new MsSqlDataSource();
                string SelectStr = string.Format("select id from Z_Collection where UserName='{0}' and UserType='{1}' and DBCode='{2}' and DBId='{3}' and IsDelete=0", UserName, UserType, DBCode, DBId);
                DataTable IsTable = mysqlD.ExecuteDataTable(SelectStr);
                if (IsTable.Rows.Count > 0)
                {
                    obj = new
                    {
                        CollectCount = "",
                        statu = 0
                    };
                }
                else
                {
                    string insertStr = string.Format("insert into Z_Collection(UserName,UserType,DBCode,DBId,DBUrl,DBTitle,AddTime) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", UserName, UserType, DBCode, DBId, DBUrl, DBTitle, DateTime.Now.ToString("yyyy-MM-dd"));
                    int statu = mysqlD.ExecuteNonQuery(insertStr);
                    //获取收藏数量
                    string select = string.Format("select CollectCount from {0} where {1}='{2}'", DBCode, IdName, DBId);
                    DataTable CollectTable = mysqlD.ExecuteDataTable(select);
                    int CollectCount = 0;
                    if (CollectTable.Rows.Count > 0)
                    {
                        CollectCount = Convert.ToInt32(CollectTable.Rows[0]["CollectCount"]) + 1;
                    }
                    string updateStr = string.Format("update {0} set CollectCount={3} where {1}='{2}'", DBCode, IdName, DBId, CollectCount);
                    mysqlD.ExecuteNonQuery(updateStr);

                    obj = new
                    {
                        CollectCount = CollectCount,
                        statu = statu
                    };
                }
            }
            
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