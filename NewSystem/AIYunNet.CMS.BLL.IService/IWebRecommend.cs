using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.BLL.IService
{
    public interface IWebRecommend
    {
        List<WebRecommend> GetWebRecommendListAllByRecommendType(int RecommendType);
        List<WebRecommend> GetWebRecommendListPc(int RecommendType);
        List<WebRecommend> GetWebRecommendListPc(int RecommendType, int num,  bool bigOrsmall);
        List<WebRecommend> GetWebRecommendList(int RecommendType);
        List<WebRecommend> GetWebRecommendList(int RecommendType, int num);

        List<WebRecommend> GetAllWebRecommendByCompany(int RecommendType, int CompanyID);

        List<WebRecommend> GetWebRecommendByCompany(int RecommendType,int num, int CompanyID);
        WebRecommend GetWebRecommendByID(int WebRecommendID);
        int AddWebRecommend(WebRecommend WebRecommend);
        int UpdateWebRecommend(WebRecommend WebRecommend);
        int DeleteWebRecommend(int WebRecommendID);
        indexList GetIndexListPc(int RecommendType, int num, bool bigOrsmall);
    }
}
