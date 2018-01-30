using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.BLL.IService
{
    public interface IWebNews
    {
        List<WebNews> GetWebNewsList();
        List<WebNews> IndexGetWebNewsListByCompanyID(int companyID, int modelID);
        List<WebNews> GetWebNewsListByMenuID(int menuID);
        List<WebNews> IndexGetWebNewsListByMenuID(int menuID);
        WebNews GetWebNewsByID(int newID);
        int AddWebNews(WebNews webNews);
        int updateWebNews(WebNews webNews);
        int deleteWebNews(int newID);
    }
}
