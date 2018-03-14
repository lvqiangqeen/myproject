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
    public class WebBuidingSingleService
    {
        public WebBuidingSingle GetWebBuidingSingleByID(int id)
        {
            WebBuidingSingle comm = new WebBuidingSingle();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                comm = context.WebBuidingSingle.Find(id);
                if (comm == null)
                {
                    comm = new WebBuidingSingle();
                }
                return comm;
            }
        }
    }
}
