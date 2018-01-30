using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Domain;
using AIYunNet.CMS.Domain.DataHelper;
using System.Data;

namespace AIYunNet.CMS.BLL.Service
{
    public class All_NavService
    {
        public List<All_Nav> GetAll_NavList(int lookupid, int firstid)
        {
            List<DownLoad> list = new List<DownLoad>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (firstid != 0)
                {
                    list = context.DownLoad.Where(c => c.LookupCode == lookupid && c.firstID == firstid && c.IsDelete == false).ToList();
                }
                else
                {
                    list = context.DownLoad.Where(c => c.LookupCode == lookupid && c.IsDelete == false).ToList();
                }

                return list;
            }
        }
    }
}
