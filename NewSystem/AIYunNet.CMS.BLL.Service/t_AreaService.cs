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
    public class t_AreaService:It_Area
    {
        public List<t_Province> GetProvinceList()
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.t_Province.ToList();
            }
        }
        public List<t_City> GetCityListByfather(string father)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.t_City.Where(wc => wc.father == father).ToList();
            }
        }
        public List<t_Area> GetAreaListByfather(string father)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.Areas.Where(wc => wc.flagdelete==0 && wc.father == father).ToList();
            }
        }

        public t_City GetCityByID(string cityid)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.t_City.Find(cityid);
            }
        }

        public List<t_City> GetHotCityList()
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.t_City.Where(wc => wc.hotcity == 1).OrderByDescending(wc=>wc.orderid).ToList();
            }
        }

        public int DeleteCity(string cityid)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                t_City city = context.t_City.Find(cityid);
                if (city != null)
                {
                    city.hotcity = 0;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }


        public int Updatehotcity(t_City city)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (city != null)
                {
                    t_City origcity = context.t_City.Find(city.cityID);
                    if (origcity != null)
                    {
                        origcity.hotcity = 1;
                        origcity.orderid = city.orderid;
                        context.SaveChanges();
                    }
                }


                return 1;
            }
        }



        public t_Province GetProvince(string provinceid)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                t_Province province = context.t_Province.Find(provinceid);
                return province;
            }
        }

        public List<city> GetJson()
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                List<city> list = new List<city>();
                List<t_Province> provincelist = context.t_Province.ToList();
                foreach (var item in provincelist)
                {
                    city ci = new city();
                    ci.value = item.provinceID;
                    ci.text = item.province;
                    List<area> li = new List<area>();
                    List<t_City> citylist= context.t_City.Where(c=>c.father==item.provinceID).ToList();
                    foreach (t_City ite in citylist)
                    {
                        area ar = new area();
                        ar.value = ite.cityID;
                        ar.text = ite.city;
                        li.Add(ar);
                    }
                    ci.children = li;
                    list.Add(ci);
                }
                return list;
            }
        }
    }
    public class area
    {
        public string value { get; set; }
        public string text { get; set; }
    }
    public class city
    {
        public string value { get; set; }
        public string text { get; set; }
        public List<area> children { get; set; }

    }
}
