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
    public class WebPeopleGuarantMoneyService
    {
        /// <summary>
        /// 用户申请审核列表
        /// </summary>
        public List<WebPeopleGuarantMoney> GetWebPeopleGuarantMoneyList()
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

                return context.WebPeopleGuarantMoney.Where(p => p.IsDelete == 0).ToList();

            }
        }
        /// <summary>
        /// 获取审核用户
        /// </summary>
        public List<WebPeopleGuarantMoney> GetWebPeopleGuarantMoneyList(int IsGuarantMoney)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

                return context.WebPeopleGuarantMoney.Where(p => p.IsDelete == 0 && p.IsGuarantMoney == IsGuarantMoney).ToList();

            }
        }


        public WebPeopleGuarantMoney GetWebPeopleGuarantMoneyByUserID(int UserID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebPeopleGuarantMoney.FirstOrDefault(c => c.UserID == UserID);
            }
        }
        public WebPeopleGuarantMoney GetWebPeopleGuarantMoneyByID(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebPeopleGuarantMoney.Find(id);
            }
        }
        public int AddWebPeopleGuarantMoney(WebPeopleGuarantMoney WebPeopleGuarantMoney)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebPeopleGuarantMoney.Add(WebPeopleGuarantMoney);
                context.SaveChanges();
                return 1;
            }
        }

        public int UpdateWebPeopleGuarantMoney(WebPeopleGuarantMoney WebPeopleGuarantMoney)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (WebPeopleGuarantMoney != null)
                {
                    WebPeopleGuarantMoney origWebPeopleGuarantMoney = context.WebPeopleGuarantMoney.FirstOrDefault(c => c.UserID == WebPeopleGuarantMoney.UserID);
                    if (origWebPeopleGuarantMoney != null)
                    {
                        //origWebPeopleGuarantMoney.UserID = WebPeopleGuarantMoney.UserID;
                        origWebPeopleGuarantMoney.UserName = WebPeopleGuarantMoney.UserName;
                        origWebPeopleGuarantMoney.UserPhone = WebPeopleGuarantMoney.UserPhone;
                        origWebPeopleGuarantMoney.UserType = WebPeopleGuarantMoney.UserType;
                        origWebPeopleGuarantMoney.IsGuarantMoney = 0;
                        origWebPeopleGuarantMoney.EditOn = DateTime.Now;
                        context.SaveChanges();
                    }
                }


                return 1;
            }
        }

        public int IsGuarantMoney(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (id != 0)
                {
                    WebPeopleGuarantMoney origWebPeopleGuarantMoney = context.WebPeopleGuarantMoney.Find(id);
                    WebPeople orwebpeople = context.WebPeople.FirstOrDefault(c => c.UserID == origWebPeopleGuarantMoney.UserID);
                    if (origWebPeopleGuarantMoney != null)
                    {
                        origWebPeopleGuarantMoney.IsGuarantMoney = 1;
                        orwebpeople.IsBond = true;
                        origWebPeopleGuarantMoney.EditOn = DateTime.Now;
                        context.SaveChanges();
                    }
                }


                return 1;
            }
        }
        public int IsNotGuarantMoney(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (id != 0)
                {
                    WebPeopleGuarantMoney origWebPeopleGuarantMoney = context.WebPeopleGuarantMoney.Find(id);
                    WebPeople orwebpeople = context.WebPeople.FirstOrDefault(c => c.UserID == origWebPeopleGuarantMoney.UserID);
                    if (origWebPeopleGuarantMoney != null)
                    {
                        origWebPeopleGuarantMoney.IsGuarantMoney = 2;
                        orwebpeople.IsBond = false;
                        origWebPeopleGuarantMoney.EditOn = DateTime.Now;
                        context.SaveChanges();
                    }
                }


                return 1;
            }
        }
        public int DeleteWebPeopleGuarantMoney(int WebPeopleGuarantMoneyID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebPeopleGuarantMoney WebPeopleGuarantMoney = context.WebPeopleGuarantMoney.Find(WebPeopleGuarantMoneyID);
                if (WebPeopleGuarantMoney != null)
                {
                    WebPeopleGuarantMoney.IsDelete = 1;
                    WebPeopleGuarantMoney.DeleteOn = DateTime.Now;
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
