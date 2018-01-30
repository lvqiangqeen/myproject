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
        public List<Nav> GetAll_NavList()
        {
            List<Nav> list = new List<Nav>();
            using (AIYunNetContext context = new AIYunNetContext())
            {

                 List<All_Nav> Navlist = context.All_Nav.Where(c => c.isdelete == false && c.fatherid == 0).OrderBy(c=>c.orderid).ToList();
                foreach (var item in Navlist)
                {
                    Nav nav = new Nav();
                    nav.firstNav = item;
                    List<All_Nav> Nlist = context.All_Nav.Where(c => c.isdelete == false && c.fatherid == item.id).OrderBy(c => c.orderid).ToList();
                    if (Nlist.Count > 0)
                    {
                        nav.list = Nlist;
                    }
                    else
                    {
                        nav.list = new List<All_Nav>();
                    }
                    list.Add(nav);
                }
                return list;
            }
        }
    }
}
