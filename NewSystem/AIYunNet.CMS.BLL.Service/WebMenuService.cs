using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Domain;

namespace AIYunNet.CMS.BLL.Service
{
    public class WebMenuService:IWebMenu
    {
        public int AddWebMenu(WebMenu webMenu)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (webMenu != null)
                {
                    context.WebMenu.Add(webMenu);
                    context.SaveChanges();
                    return 1;
                }
                else {
                    return 0;
                }
            }
        }

        public int DeleteWebMenu(int menuID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebMenu webMenu = context.WebMenu.Find(menuID);
                if (webMenu != null)
                {
                    webMenu.FlagDelete = 1;
                    webMenu.DeleteOn = DateTime.Now;
                    context.SaveChanges();
                    return 1;
                }
                else {
                    return 0;
                }
            }
        }

        public List<WebMenu> GetChildrenMenuList(int parentMenuID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebMenu.Where(wm => wm.FlagDelete == 0 && wm.ParentID == parentMenuID).ToList();
            }
        }

        public WebMenu GetMenuByID(int menuID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebMenu.Find(menuID);
            }
        }

        public List<WebMenu> GetWebMenuList()
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebMenu.Where(wm => wm.FlagDelete == 0).ToList();
            }
        }

        public int UpdateWebMenu(WebMenu webMenu)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (webMenu != null)
                {
                    WebMenu originalMenu = context.WebMenu.Find(webMenu.WebMenuID);
                    if (originalMenu != null)
                    {
                        originalMenu.EditOn = DateTime.Now;
                        originalMenu.EnglishName = webMenu.EnglishName;
                        originalMenu.ImageUrl = webMenu.ImageUrl;
                        originalMenu.IsDisplay = webMenu.IsDisplay;
                        originalMenu.ParentID = webMenu.ParentID;
                        originalMenu.ParentName = webMenu.ParentName;
                        originalMenu.ShowOrder = webMenu.ShowOrder;
                        originalMenu.ShowUrl = webMenu.ShowUrl;
                        originalMenu.Style = webMenu.Style;
                        originalMenu.WebMenuName = webMenu.WebMenuName;
                        context.SaveChanges();
                        return 1;
                    }
                    else {
                        return 0;
                    }
                }
                else {
                    return 0;
                }

            }
        }


        public List<WebMenu> GetWebMenuListByStyle(string style)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebMenu.Where(wn => wn.FlagDelete == 0&&wn.Style== style).ToList();
            }
        }
        public List<WebMenu> GetWebMenuListByParentName(string parentname)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebMenu.Where(wn => wn.FlagDelete == 0 && wn.ParentName == parentname).ToList();
            }
        }

        public List<WebMenu> IndexGetWebMenuNewsList()
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebMenu.Where(wn => wn.FlagDelete == 0 && wn.ParentName=="装修百科" && wn.WebMenuID!=2).Take(3).ToList();
            }
        }
    }
}
