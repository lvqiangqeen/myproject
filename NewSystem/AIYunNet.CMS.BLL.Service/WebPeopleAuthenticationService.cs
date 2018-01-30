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
    public class WebPeopleAuthenticationService
    {
        /// <summary>
        /// 用户申请审核列表
        /// </summary>
        public List<WebPeopleAuthentication> GetWebPeopleAuthenticationList()
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

                return context.WebPeopleAuthentication.Where(p => p.IsDelete == 0).OrderByDescending(p=>p.AddOn).ToList();

            }
        }
        /// <summary>
        /// 获取审核用户
        /// </summary>
        public List<WebPeopleAuthentication> GetWebPeopleAuthenticationList(int IsAuthentication)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

                return context.WebPeopleAuthentication.Where(p => p.IsDelete == 0 && p.IsAuthentication == IsAuthentication).ToList();

            }
        }


        public WebPeopleAuthentication GetWebPeopleAuthenticationByUserID(int UserID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebPeopleAuthentication.FirstOrDefault(c=>c.UserID==UserID && c.IsDelete==0);
            }
        }
        public WebPeopleAuthentication GetWebPeopleAuthenticationByID(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebPeopleAuthentication.Find(id);
            }
        }
        public int AddWebPeopleAuthentication(WebPeopleAuthentication WebPeopleAuthentication)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebPeopleAuthentication.Add(WebPeopleAuthentication);
                context.SaveChanges();
                return 1;
            }
        }

        public int UpdateWebPeopleAuthentication(WebPeopleAuthentication WebPeopleAuthentication)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (WebPeopleAuthentication != null)
                {
                    WebPeopleAuthentication origWebPeopleAuthentication = context.WebPeopleAuthentication.FirstOrDefault(c => c.UserID == WebPeopleAuthentication.UserID);
                    if (origWebPeopleAuthentication != null)
                    {
                        origWebPeopleAuthentication.TrueName = WebPeopleAuthentication.TrueName;
                        //origWebPeopleAuthentication.UserID = WebPeopleAuthentication.UserID;
                        origWebPeopleAuthentication.UserIdentity = WebPeopleAuthentication.UserTrueName;
                        origWebPeopleAuthentication.UserType = WebPeopleAuthentication.UserType;
                        origWebPeopleAuthentication.IsAuthentication = 0;
                        origWebPeopleAuthentication.ShengfenF = WebPeopleAuthentication.ShengfenF;
                        origWebPeopleAuthentication.ShengfenZ = WebPeopleAuthentication.ShengfenZ;
                        origWebPeopleAuthentication.UserTrueName = WebPeopleAuthentication.UserTrueName;
                        origWebPeopleAuthentication.EditOn = DateTime.Now;
                        context.SaveChanges();
                    }
                }


                return 1;
            }
        }

        public int IsAuthentication(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (id != 0)
                {
                    WebPeopleAuthentication origWebPeopleAuthentication = context.WebPeopleAuthentication.Find(id);
                    WebPeople orwebpeople=context.WebPeople.FirstOrDefault(c => c.UserID == origWebPeopleAuthentication.UserID);
                    if (origWebPeopleAuthentication != null)
                    {
                        origWebPeopleAuthentication.IsAuthentication = 1;
                        orwebpeople.IsAuthentication = true;
                        origWebPeopleAuthentication.EditOn = DateTime.Now;
                        context.SaveChanges();
                    }
                }


                return 1;
            }
        }
        public int IsNotAuthentication(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (id != 0)
                {
                    WebPeopleAuthentication origWebPeopleAuthentication = context.WebPeopleAuthentication.Find(id);
                    WebPeople orwebpeople = context.WebPeople.FirstOrDefault(c => c.UserID == origWebPeopleAuthentication.UserID);
                    if (origWebPeopleAuthentication != null)
                    {
                        origWebPeopleAuthentication.IsAuthentication = 2;
                        orwebpeople.IsAuthentication = false;
                        origWebPeopleAuthentication.EditOn = DateTime.Now;
                        context.SaveChanges();
                    }
                }


                return 1;
            }
        }
        public int DeleteWebPeopleAuthentication(int WebPeopleAuthenticationID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebPeopleAuthentication WebPeopleAuthentication = context.WebPeopleAuthentication.Find(WebPeopleAuthenticationID);
                if (WebPeopleAuthentication != null)
                {
                    WebPeopleAuthentication.IsDelete = 1;
                    WebPeopleAuthentication.DeleteOn = DateTime.Now;
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
