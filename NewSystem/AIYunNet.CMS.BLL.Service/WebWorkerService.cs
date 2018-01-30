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
    }
}
