using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.BLL.IService
{
    public interface IWebUser
    {
        int AddWebUser(WebUser WebUser);
        bool IsHaveuserAccount(string userAccount);
        bool ExistUser(string userAccount, string userPwd);
        int UpdateWebUserPassword(string userAccount, string userPwd);
        List<WebUser> GetWebUserList();
        int UpdateWebUser(WebUser WebUser);
        WebUser GetWebUserByAccount(string userAccount, string userPwd);
    }
}
