using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Domain;
using AIYunNet.CMS.Domain.DataHelper;
using System.Data;

namespace AIYunNet.CMS.BLL.Service
{
    public class OtherService
    {
        WebUserService webuserService = new WebUserService();
        WebCompanyUserService webCompanyUserService = new WebCompanyUserService();
        WebPeopleService webpeopleService = new WebPeopleService();
        WebCompanyService webCompanyService = new WebCompanyService();
        /// <summary>
        /// 获取头像根据账户和类型
        /// </summary>
        public string getPhotoUrlthum(string useraccount,string usertype)
        {
            string result = "";
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (usertype == "WebUser")
                {
                    WebUser user = webuserService.GetWebUserByAccount(useraccount);
                    if (user == null)
                    {
                        result = "2";
                    }
                    else
                    {
                        WebPeople webpeople = webpeopleService.GetWebPeopleByUserID(user.UserID);
                        if (webpeople != null)
                            result = webpeople.thumbnailImage;
                    }
                }
                else
                {
                    WebCompanyUser companyuser = webCompanyUserService.GetWebCompanyUserByAccount(useraccount);
                    if (companyuser == null)
                    {
                        result = "2";
                    }
                    else {
                        WebCompany webcompany = webCompanyService.GetWebCompanyByUserID(companyuser.CompanyUserID);
                        if (webcompany != null)
                            result = webcompany.thumbnailImage;
                    }
                    
                }
            }
            return result;
        }


        public int getCaseGroupByCompanyID(int companyID,int typeID,string typeString)
        {
            int ret= 0;
            MsSqlDataSource sql = new MsSqlDataSource();
            string sqlselect = string.Format("select count(*) as cou from WebCase where CompanyID='{0}' and {1}='{2}'", companyID, typeString, typeID);
            DataTable table=sql.ExecuteDataTable(sqlselect);
            if (table.Rows.Count > 0)
            {
                ret = Convert.ToInt32(table.Rows[0]["cou"]);
            }
            return ret;
        }
    }
}
