using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.IO;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.Web.Areas.SysAdmin.Controllers
{
    public class OtherContentController : BaseController
    {
        //
        // GET: /SysAdmin/Content/

        public ActionResult Index()
        {
            return View();
        }

        #region 友情链接
        IWebContent contentService = new WebContentService();
        public ActionResult FriendLinkList()
        {
            List<WebFriendLink> friendLinks = contentService.GetFriendLinkList().ToList();
            ViewBag.FirendLinkList = friendLinks;
            return View();
        }

        [HttpGet]
        public ActionResult AddOrEditFriendLink(int linkID)
        {
            WebFriendLink friendLink = contentService.GetFriendLinkByID(linkID);
            if (friendLink == null)
            {
                friendLink = new WebFriendLink();
            }
            return View(friendLink);
        }

        [HttpPost]
        public ActionResult AddOrEditFriendLink(WebFriendLink friendLink)
        {
            int result = 0;
            if (friendLink.ID > 0)
            {
                result = contentService.UpdateWebFriendLink(friendLink);
            }
            else
            {
                result = contentService.AddWebFriendLink(friendLink);
            }
            return Json(new { RetCode = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteWebFriendLink(int linkID)
        {
            int result = contentService.DeleteWebFriendLink(linkID);
            return Json(new { RetCode = result }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 栏目管理
        IWebMenu webMenuService = new WebMenuService();
        public ActionResult WebMenuList()
        {
            List<WebMenu> webMenus = webMenuService.GetWebMenuList();
            //初始化一个全部栏目作为跟栏目，其他栏目需要在它下级
            if (webMenus.Count == 0)
            {
                WebMenu rootMenu = new WebMenu()
                {
                    EnglishName = "All",
                    IsDisplay = false,
                    ParentID = 0,
                    ParentName = "根栏目",
                    WebMenuName = "全部栏目",
                    AddOn = DateTime.Now,
                    FlagDelete = 0
                };
                webMenuService.AddWebMenu(rootMenu);
                webMenus = webMenuService.GetWebMenuList();
            }
            ViewBag.WebMenuList = webMenus;
            return View();
        }

        public ActionResult AddOrEditWebMenu(int menuID)
        {
            List<WebMenu> menuList = webMenuService.GetWebMenuList();
            IEnumerable<SelectListItem> parentMenus = menuList.Select(m => new SelectListItem { Value = m.WebMenuID.ToString(), Text = m.WebMenuName });
            ViewBag.ParentMenus = parentMenus;
            WebMenu menu = webMenuService.GetMenuByID(menuID);
            if (menu == null)
            {
                menu = new WebMenu();
            }
            return View(menu);
        }

        [HttpPost]
        public JsonResult AddOrEditWebMenu(WebMenu menu)
        {
            int result = 0;
            WebMenu parentMenu = webMenuService.GetMenuByID(menu.ParentID);
            menu.ParentName = parentMenu != null ? parentMenu.WebMenuName : string.Empty;
            if (menu.WebMenuID > 0)
            {
                result = webMenuService.UpdateWebMenu(menu);
            }
            else
            {
                result = webMenuService.AddWebMenu(menu);
            }
            return Json(new { RetCode = 1 });
        }

        public JsonResult DeleteWebMenu(int menuID)
        {
            int result = webMenuService.DeleteWebMenu(menuID);
            return Json(new { RetCode = result });
        }

        #endregion

        #region 站点内容管理
        public ActionResult WebNewsList()
        {
            IWebNews newsService = new WebNewsService();
            List<WebNews> newsList = newsService.GetWebNewsList();
            ViewBag.NewsList = newsList;
            return View();
        }

        [HttpGet]
        public ActionResult AddOrEditWebNews(int newsID)
        {
            IWebNews newsService = new WebNewsService();
            WebNews news = newsService.GetWebNewsByID(newsID);
            if (news == null)
            {
                news = new WebNews();
            }
            List<WebMenu> menuList = webMenuService.GetWebMenuList();
            IEnumerable<SelectListItem> parentMenus = menuList.Select(m => new SelectListItem { Value = m.WebMenuID.ToString(), Text = m.WebMenuName });
            ViewBag.ParentMenus = parentMenus;
            return View(news);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AddOrEditWebNews1(WebNews news)
        {
            IWebNews newsService = new WebNewsService();
            int result = 0;
            WebMenu parentMenu = webMenuService.GetMenuByID(news.ClassID);
            news.ClassName = parentMenu != null ? parentMenu.WebMenuName : string.Empty;
            if (news.ContentID > 0)
            {
                result = newsService.updateWebNews(news);
            }
            else
            {
                result = newsService.AddWebNews(news);
            }
            return Json(new { RetCode = result });
        }

        public JsonResult DeleteWebNews(int newsID)
        {
            IWebNews newsService = new WebNewsService();
            int result=newsService.deleteWebNews(newsID);
            return Json(new { RetCode = result });
        }
        #endregion

        #region 文件管理
        public ActionResult WebFileList()
        {
            IWebFile webFileService = new WebFileService();
            List<WebFile> fileList = webFileService.GetWebFileList();
            ViewBag.FileList = fileList;
            return View();
        }

        public ActionResult AddOrEditWebFile(int fileID)
        {
            List<WebMenu> menuList = webMenuService.GetWebMenuList();
            IEnumerable<SelectListItem> parentMenus = menuList.Select(m => new SelectListItem { Value = m.WebMenuID.ToString(), Text = m.WebMenuName });
            ViewBag.ParentMenus = parentMenus;

            IWebFile webFileService = new WebFileService();
            WebFile webFile = webFileService.GetWebFileByID(fileID);
            if (webFile == null)
            {
                webFile = new WebFile();
            }
            return View(webFile);
        }

        [HttpPost]
        public JsonResult AddOrEditWebFile(WebFile file)
        {
            int result = 0;
            IWebFile webFileService = new WebFileService();
            WebMenu parentMenu = webMenuService.GetMenuByID(file.ClassID);
            file.ClassName = parentMenu != null ? parentMenu.WebMenuName : string.Empty;
            file.Tags = FileHelper.GetFileTag(file.FileName);
            if (file.FileID > 0)
            {
                result = webFileService.UpdateWebFile(file);
            }
            else
            {
                result = webFileService.AddWebFile(file);
            }
            return Json(new { RetCode = result });
        }


        #endregion
    }
}
