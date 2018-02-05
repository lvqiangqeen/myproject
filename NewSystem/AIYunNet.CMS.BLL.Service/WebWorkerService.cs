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
    public class WebWorkerService
    {
        public WebWorker GetWebWorkerByID(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebWorker.Find(id);
            }
        }
        public bool IsHaveWorker(int UserID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebWorker WebWorker = context.WebWorker.FirstOrDefault(us => us.UserID == UserID);
                return WebWorker != null ? true : false;
            }
        }

        /// <summary>
        /// 通过UserID获取单个人员
        /// </summary>
        public WebWorker GetWebWorkerByUserID(int userID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebWorker.FirstOrDefault(c => c.UserID == userID);
            }
        }

    }
}
