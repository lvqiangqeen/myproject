using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.BLL.IService
{
    public interface IWebCommon
    {
        List<WebLookup> GetLookupList(string lookupKey);
        List<WebLookup> GetLookupListbyRecommend();
        WebLookup GetLookup(int id);
        List<WebLookup> GetLookupListByCount(string lookupKey,int topcount);
        string GetLookupDesc(string lookupKey, string code);
        List<string> GetLookupGroupNameList();
        int AddLookup(WebLookup webLookup);
        int UpdateLookup(WebLookup webLookup);
        int DeleteLookup(int id);
    }
}
