using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.BLL.IService
{
    public interface IWebPeople
    {
        List<WebPeople> GetWebPeopleList(string PeopleCategory);

        //List<WebPeople> GetWebDesignerList();
        List<WebPeople> GetWebPeopleListByCompanyIDAndCount(int companyID, int count);
        List<WebPeople> IndexGetWebPeopleList(string type, int topcount);
        List<WebPeople> IndexGetWebDesignerList(string cityid);
        List<WebPeople> IndexGetWebWorkerList();
        List<WebPeople> IndexGetWebWorkLeaderList();
        List<WebPeople> GetAllWebPeopleListByCompanyAndPeopleCategory(string PeopleCategory, int companyID);
        //List<WebPeople> GetWebPeopleListByCompany(int companyID);
        //List<WebPeople> GetWebDesignerListByCompany(int companyID);
        List<WebPeople> IndexGetWebPeopleListByCompanyID(int companyID, int modelID);
        WebPeople GetWebPeopleByID(int peopleID);
        int AddWebPeople(WebPeople webPeople);
        int UpdateWebPeople(WebPeople webPeople);
        int DeleteWebPeople(int peopleID);
    }
}
