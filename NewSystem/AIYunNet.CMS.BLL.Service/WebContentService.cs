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
    public class WebContentService : IWebContent
    {
        public List<WebFriendLink> GetFriendLinkList()
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebFriendLink.Where(link => link.FlagDelete == 0).ToList();
            }
        }

        public WebFriendLink GetFriendLinkByID(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebFriendLink.Find(id);
            }
        }

        public int AddWebFriendLink(WebFriendLink webFriendLink)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebFriendLink.Add(webFriendLink);
                context.SaveChanges();
                return 1;
            }
        }

        public int UpdateWebFriendLink(WebFriendLink webFriendLink)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebFriendLink originalFriendLink = context.WebFriendLink.Find(webFriendLink.ID);
                if (originalFriendLink != null)
                {
                    originalFriendLink.EditOn = DateTime.Now;
                    originalFriendLink.ImgUrl = webFriendLink.ImgUrl;
                    originalFriendLink.IsDisplay = webFriendLink.IsDisplay;
                    originalFriendLink.LinkDesc = webFriendLink.LinkDesc;
                    originalFriendLink.LinkUrl = webFriendLink.LinkUrl;
                    originalFriendLink.Name = webFriendLink.Name;
                    originalFriendLink.ShowOrder = webFriendLink.ShowOrder;
                    originalFriendLink.State = webFriendLink.State;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int DeleteWebFriendLink(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebFriendLink webFriendLink = context.WebFriendLink.Find(id);
                if (webFriendLink != null)
                {
                    webFriendLink.FlagDelete = 1;
                    webFriendLink.DeleteOn = DateTime.Now;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
