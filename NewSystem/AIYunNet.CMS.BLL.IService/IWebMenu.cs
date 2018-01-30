using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.BLL.IService
{
    public interface IWebMenu
    {
        List<WebMenu> GetWebMenuListByStyle(string style);
        List<WebMenu> GetWebMenuListByParentName(string parentname);
        List<WebMenu> IndexGetWebMenuNewsList();
        List<WebMenu> GetWebMenuList();

        List<WebMenu> GetChildrenMenuList(int parentMenuID);

        WebMenu GetMenuByID(int menuID);

        int AddWebMenu(WebMenu webMenu);

        int UpdateWebMenu(WebMenu webMenu);

        int DeleteWebMenu(int menuID);
    }
}
