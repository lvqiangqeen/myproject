using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Domain;
using AIYunNet.CMS.Domain.OccaModel;
using AIYunNet.CMS.Domain.DataHelper;
using System.Data;

namespace AIYunNet.CMS.BLL.Service
{
    public class DecTenderService
    {
        public List<DecTender> GetDecTenderList(string guid)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                List<DecTender> list = new List<DecTender>();

                list = context.DecTender.Where(c=>c.Guid== guid && c.IsDelete==0).ToList();
                if (list == null)
                {
                    list = new List<DecTender>();
                }
                
                return list;
            }
        }
        public DecTender GetDecTenderByID(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                DecTender model = new DecTender();
                if (id != 0)
                {
                    model = context.DecTender.Find(id);
                }
                return model;
            }
        }

        public int AddDecTender(DecTender DecTender)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                try
                {
                    context.DecTender.Add(DecTender);
                    context.SaveChanges();
                }
                catch (Exception e)
                {

                }

                return 1;
            }
        }

        public int UpdateDecTender(DecTender DecTender)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                DecTender old = context.DecTender.Find(DecTender.id);

                if (old != null)
                {
                    old.IsAccept = 0;
                    old.Guid = DecTender.Guid;
                    old.perInfo = DecTender.perInfo;
                    old.perName = DecTender.perName;
                    old.perPhone = DecTender.perPhone;
                    old.EditOn = DateTime.Now;
                    //old.UserID = DecTender.UserID;
                    context.SaveChanges();
                }
                return 1;
            }
        }

        public int DeleteDecTender(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                DecTender old = context.DecTender.Find(id);

                if (old != null)
                {
                    old.IsDelete = 1;
                    old.DelOn = DateTime.Now;
                    //old.UserID = DecTender.UserID;
                    context.SaveChanges();
                }
                return 1;
            }
        }
    }
}
