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
    public class PeopleJianService
    {
        public List<PeopleJian> GetPeopleJianList()
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.PeopleJian.Where(link => link.FlagDelete == 0).ToList();
            }
        }

        public PeopleJian GetPeopleJianByID(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.PeopleJian.Find(id);
            }
        }

        public int AddPeopleJian(PeopleJian PeopleJian)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.PeopleJian.Add(PeopleJian);
                context.SaveChanges();
                return 1;
            }
        }

        public int UpdatePeopleJian(PeopleJian PeopleJian)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                PeopleJian originalPeopleJian = context.PeopleJian.Find(PeopleJian.peopleid);
                if (originalPeopleJian != null)
                {
                    originalPeopleJian.EditOn = DateTime.Now;
                    originalPeopleJian.peoplename = PeopleJian.peoplename;
                    originalPeopleJian.Sex = PeopleJian.Sex;
                    originalPeopleJian.age = PeopleJian.age;
                    originalPeopleJian.weight = PeopleJian.weight;
                    originalPeopleJian.height = PeopleJian.height;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int DeletePeopleJian(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                PeopleJian PeopleJian = context.PeopleJian.Find(id);
                if (PeopleJian != null)
                {
                    PeopleJian.FlagDelete = 1;
                    PeopleJian.DeleteOn = DateTime.Now;
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
