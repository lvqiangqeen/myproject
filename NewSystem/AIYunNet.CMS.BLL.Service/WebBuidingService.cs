using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Domain;
using AIYunNet.CMS.BLL.IService;

namespace AIYunNet.CMS.BLL.Service
{
    public class WebBuidingService
    {
        /// <summary>
        ///  获取工人列表推荐工地
        /// </summary>
        /// <returns></returns>
        public List<WebBuiding> GetWebBuidingListByCount(int WorkerID,int count)
        {
            List<WebBuiding> list = new List<WebBuiding>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                try
                {
                    list= context.WebBuiding.Where(wc => wc.FlagDelete == 0 && wc.WorkerID == WorkerID && wc.IsTop==true).OrderByDescending(wc => wc.AddOn).Take(3).ToList();
                }
                catch(Exception e)
                {
                    list= new List<WebBuiding>();
                }
                return list;


            }
        }
        /// <summary>
        ///  根据ID获取在建工地
        /// </summary>
        /// <returns></returns>
        public WebBuiding GetWebBuidingByID(int BuidingID)
        {
            WebBuiding buiding = new WebBuiding();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                try
                {
                    buiding = context.WebBuiding.Find(BuidingID);
                }
                catch (Exception e)
                {
                }
                return buiding;
            }
        }
    }
}
