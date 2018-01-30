using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.BLL.IService
{
    public interface IWebCompany
    {
        List<WebCompany> GetWebCompanyList();
        List<WebCompany> IndexGetWebCompanyList();
        //List<WebCompany> GetWebCompanyListByID(int companyID);
        WebCompany GetWebCompanyByID(int companyID);
        int AddWebCompany(WebCompany webCompany);
        int UpdateWebCompany(WebCompany webCompany);
        int DeleteWebCompany(int companyID);

        int UpdateWebCompanyLicence(WebCompany webCompany);

        int UpdateWebCompanyRegist(WebCompany webCompany);

    }
}
