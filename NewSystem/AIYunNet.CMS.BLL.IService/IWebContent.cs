using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.BLL.IService
{
    public interface IWebContent
    {
        List<WebFriendLink> GetFriendLinkList();
        WebFriendLink GetFriendLinkByID(int id);
        int AddWebFriendLink(WebFriendLink webFriendLink);
        int UpdateWebFriendLink(WebFriendLink webFriendLink);
        int DeleteWebFriendLink(int id);
    }
}
