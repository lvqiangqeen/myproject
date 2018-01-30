using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.BLL.IService
{
    public interface IWebCase
    {
        List<WebCase> GetHotWebCaseList(int count, int DecType);
        List<WebCase> GetWebCaseList();
        List<WebCase> GetWebCaseListByCompanyID(int companyID);
        List<WebCase> GetWebCaseListByCompanyIDAndCount(int companyID, int count);
        List<WebCase> IndexGetWebCaseListByCompanyID(int companyID, int modelID);
        List<WebCase> GetWebCaseListByPeopleIDAndCount(int peopleID, int count);
        List<WebCase> GetWebCaseListByPeopleIDAndskip(int peopleID, int skip);
        List<WebCase> GetWebCaseListByPeopleID(int peopleID);
        WebCase GetWebCaseByID(int caseID);
        int AddWebCase(WebCase webCase);
        int UpdateWebCase(WebCase webCase);
        int DeleteWebCase(int caseID);
        int AddWebCaseRelationship(WebCaseRelationship webCaseRelationship);

    }
}
