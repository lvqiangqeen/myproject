using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Linq.Expressions;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Domain;
using AIYunNet.CMS.Domain.DataHelper;
using System.ComponentModel;
using AIYunNet.CMS.Common.Utility.Model;



namespace AIYunNet.CMS.BLL.Service
{
    public class PageList
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        public static List<T> GetPageList<T, TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, int>> orderLambda1, Expression<Func<T, string>> orderLambda2, int pageSize, int pageIndex, out int recordCount, out int pageCount)
  where T : class
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

                var result = context.Set<T>()
                            .Where(whereLambda)
                            .OrderBy(orderLambda1).OrderByDescending(orderLambda2)
                            .Skip((pageIndex - 1) * pageSize)
                            .Take(pageSize).AsQueryable();
                recordCount = context.Set<T>().Where(whereLambda).Count();
                pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
                return result.ToList();
            } 
        }

        /// <summary>
        /// SQL分页查询
        /// </summary>
        public static List<T> GetPageListBySQL<T>(Pagination paginfo,out int recordcount, out int pageCount) where T : class , new()
        {
            int recordCount = 0;
            StringBuilder sql = new StringBuilder("");
            sql.AppendFormat(@"SELECT {0} FROM {1} WHERE {2}", string.IsNullOrEmpty(paginfo.SelectParameters)?"*": paginfo.SelectParameters, paginfo.EntityName, paginfo.SortParameters);
            MsSqlDataSource mssql = new MsSqlDataSource();
            DataTable dataTable = mssql.ListPager(sql.ToString(), paginfo.PageSize, paginfo.PageIndex, paginfo.SortOrder, out recordCount);

            List<T> list = null;
            if (dataTable.Rows.Count > 0)
            {
                list= EntityHelper.MapEntity<T>(dataTable);
            }
            recordcount = recordCount;
            pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / paginfo.PageSize));
            return list;
        }

    }
}
