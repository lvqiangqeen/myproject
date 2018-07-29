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
                    DecTender tender = context.DecTender.FirstOrDefault(c => c.Guid == DecTender.Guid && c.UserID == DecTender.UserID);
                    if (tender == null)
                    {
                        context.DecTender.Add(DecTender);
                        context.SaveChanges();
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }

                }
                catch (Exception e)
                {

                }

                return 0;
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
                    old.Price = DecTender.Price;
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

        public List<Tender> GetTenderList(int UserID,int IsAccept, int PageSize, int CurPage, out int count)
        {
            List<Tender> list = new List<Tender>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                var query = from d in context.DecDemand
                            from c in context.DecTender
                            where d.Guid == c.Guid && c.IsDelete == 0 && c.UserID== UserID && c.IsAccept== IsAccept
                            select new Tender
                            {
                                id = c.id,
                                Guid = c.Guid,
                                IsAccept = c.IsAccept,
                                UserID= UserID,
                                perName=c.perName,
                                perInfo=c.perInfo,
                                perPhone=c.perPhone,
                                Price=c.Price,
                                Buidingname=d.buidingname,
                                Buidingspace=d.buidingSpace,
                                Addon=c.EditOn
                            };
                count = query.ToList().Count();

                list = query.OrderByDescending(c => c.Addon).ToList().Skip(PageSize * (CurPage - 1)).Take(PageSize * CurPage).ToList();
            }

            return list;
        }
    }
}
