using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Domain;

namespace AIYunNet.CMS.BLL.Service
{
    public class WebBuidingContractService
    {
        public WebBuidingContract GetContractByGuid(string guid)
        {
            WebBuidingContract constract = new WebBuidingContract();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                constract = context.WebBuidingContract.FirstOrDefault(c => c.Guid == guid);
                if (constract == null)
                {
                    constract = new WebBuidingContract();
                }
                return constract;
            }
        }
        public int AddContract(WebBuidingContract constract)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebBuidingContract.Add(constract);
                context.SaveChanges();
                return 1;
            }
        }
        public int updateContract(WebBuidingContract constract)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebBuidingContract old = context.WebBuidingContract.FirstOrDefault(c => c.Guid == constract.Guid);

                    return 1;
                
            }
        }
    }
}
