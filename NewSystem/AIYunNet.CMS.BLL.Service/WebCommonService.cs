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
    public class WebCommonService : IWebCommon
    {
        public List<WebLookup> GetLookupList(string lookupKey)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebLookUp.Where(lp => lp.LookupKey == lookupKey && lp.Display == 1).OrderBy(lp=>lp.Code).ToList();
            }
        }
        public List<WebLookup> GetLookupListbyRecommend()
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebLookUp.Where(lp => lp.LookupKey == "Recommend_Wechart" && lp.Display == 1).OrderBy(lp => lp.Col2).ToList();
            }
        }
        ///<summary>
        ///根据id获取
        ///</summary>
        public WebLookup GetLookup(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebLookUp.Find(id);
            }
        }
        ///<summary>
        ///带有count的属性列表
        ///</summary>
        public List<WebLookup> GetLookupListByCount(string lookupKey,int topcount)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebLookUp.Where(lp => lp.LookupKey == lookupKey && lp.Display == 1).Take(topcount).ToList();
            }
        }
        public string GetLookupDesc(string lookupKey, string code)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebLookup lookup = context.WebLookUp.FirstOrDefault(lp => lp.LookupKey == lookupKey && lp.Code == code);
                return lookup != null ? lookup.Description : string.Empty;
            }
        }

        ///<summary>
        ///获取属性分类
        ///</summary>
        public List<string> GetLookupGroupNameList()
        {
            List<string> list = new List<string>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                list = context.WebLookUp.GroupBy(c=>c.LookupKey).Select(c=>c.Key).ToList();
                return list;
            }
        }

        public int AddLookup(WebLookup webLookup)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebLookUp.Add(webLookup);
                context.SaveChanges();
                return 1;
            }
        }

        public int UpdateLookup(WebLookup webLookup)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebLookup originalWebLookup = context.WebLookUp.Find(webLookup.LookupID);
                if (originalWebLookup != null)
                {
                    originalWebLookup.LookupKey = webLookup.LookupKey;
                    originalWebLookup.Code = webLookup.Code;
                    originalWebLookup.Col2 = webLookup.Col2;
                    originalWebLookup.Description = webLookup.Description;
                    originalWebLookup.Display = webLookup.Display;
                    originalWebLookup.EnglishName = webLookup.EnglishName;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int DeleteLookup(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebLookup originalWebLookup = context.WebLookUp.Find(id);
                if (originalWebLookup != null)
                {
                    originalWebLookup.Display = 0;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
