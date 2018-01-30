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
    public class WebCompanyGuarantMoneyService
    {
        /// <summary>
        /// 用户申请审核列表
        /// </summary>
        public List<WebCompanyGuarantMoney> GetWebCompanyGuarantMoneyList()
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

                return context.WebCompanyGuarantMoney.Where(p => p.IsDelete == 0).ToList();

            }
        }
        /// <summary>
        /// 获取审核用户
        /// </summary>
        public List<WebCompanyGuarantMoney> GetWebCompanyGuarantMoneyList(int IsGuarantMoney)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

                return context.WebCompanyGuarantMoney.Where(p => p.IsDelete == 0 && p.IsGuarantMoney == IsGuarantMoney).ToList();

            }
        }


        public WebCompanyGuarantMoney GetWebCompanyGuarantMoneyByUserID(int UserID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebCompanyGuarantMoney.FirstOrDefault(c => c.CompanyUserID == UserID);
            }
        }
        public WebCompanyGuarantMoney GetWebCompanyGuarantMoneyByID(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebCompanyGuarantMoney.Find(id);
            }
        }
        public int AddWebCompanyGuarantMoney(WebCompanyGuarantMoney WebCompanyGuarantMoney)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebCompanyGuarantMoney.Add(WebCompanyGuarantMoney);
                context.SaveChanges();
                return 1;
            }
        }

        public int UpdateWebCompanyGuarantMoney(WebCompanyGuarantMoney WebCompanyGuarantMoney)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (WebCompanyGuarantMoney != null)
                {
                    WebCompanyGuarantMoney origWebCompanyGuarantMoney = context.WebCompanyGuarantMoney.FirstOrDefault(c => c.CompanyUserID == WebCompanyGuarantMoney.CompanyUserID);
                    if (origWebCompanyGuarantMoney != null)
                    {
                        //origWebCompanyGuarantMoney.UserID = WebCompanyGuarantMoney.UserID;
                        origWebCompanyGuarantMoney.CompanyID = WebCompanyGuarantMoney.CompanyID;
                        origWebCompanyGuarantMoney.CompanyName = WebCompanyGuarantMoney.CompanyName;
                        origWebCompanyGuarantMoney.CompanyPhone = WebCompanyGuarantMoney.CompanyPhone;
                        origWebCompanyGuarantMoney.IsGuarantMoney = 0;
                        origWebCompanyGuarantMoney.EditOn = DateTime.Now;
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
                    WebCompanyGuarantMoney origWebCompanyGuarantMoney = context.WebCompanyGuarantMoney.Find(id);
                    WebCompany orwebcom = context.WebCompany.FirstOrDefault(c => c.WebCompanyUserID == origWebCompanyGuarantMoney.CompanyUserID);
                    if (origWebCompanyGuarantMoney != null)
                    {
                        origWebCompanyGuarantMoney.IsGuarantMoney = 1;
                        orwebcom.IsBond = true;
                        origWebCompanyGuarantMoney.EditOn = DateTime.Now;
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
                    WebCompanyGuarantMoney origWebCompanyGuarantMoney = context.WebCompanyGuarantMoney.Find(id);
                    WebCompany orwebcom = context.WebCompany.FirstOrDefault(c => c.WebCompanyUserID == origWebCompanyGuarantMoney.CompanyUserID);
                    if (origWebCompanyGuarantMoney != null)
                    {
                        origWebCompanyGuarantMoney.IsGuarantMoney = 2;
                        orwebcom.IsBond = false;
                        origWebCompanyGuarantMoney.EditOn = DateTime.Now;
                        context.SaveChanges();
                    }
                }


                return 1;
            }
        }
        public int DeleteWebCompanyGuarantMoney(int WebCompanyGuarantMoneyID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebCompanyGuarantMoney WebCompanyGuarantMoney = context.WebCompanyGuarantMoney.Find(WebCompanyGuarantMoneyID);
                if (WebCompanyGuarantMoney != null)
                {
                    WebCompanyGuarantMoney.IsDelete = 1;
                    WebCompanyGuarantMoney.DeleteOn = DateTime.Now;
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
