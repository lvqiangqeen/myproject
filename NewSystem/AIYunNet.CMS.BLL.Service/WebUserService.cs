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
    public class WebUserService : IWebUser
    {
        public int AddWebUser(WebUser WebUser)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebUser.Add(WebUser);
                context.SaveChanges();
                return 1;
            }
        }
        public bool IsHaveuserAccount(string userAccount)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebUser user = context.WebUser.FirstOrDefault(us => us.UserName == userAccount);
                return user != null ? true : false;
            }
        }
        public bool ExistUser(string userAccount, string userPwd)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                try
                {
                    WebUser user = context.WebUser.FirstOrDefault(us => us.UserName == userAccount && us.Password == userPwd);
                    return user != null ? true : false;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public int UpdateWebUserPassword(string userAccount, string newUserPwd)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebUser user = context.WebUser.FirstOrDefault(us => us.UserName == userAccount);
                if (user != null)
                {
                    user.Password = newUserPwd;
                    user.EditOn = DateTime.Now;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

        }

        public List<WebUser> GetWebUserList()
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebUser.Where(su => su.IsDelete == false).OrderByDescending(su => su.AddOn).ToList();
            }
        }

        public int UpdateWebUser(WebUser newWebUser)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebUser originalUser = context.WebUser.Find(newWebUser.UserID);
                if (originalUser != null)
                {
                    originalUser.TrueName = newWebUser.TrueName;
                    originalUser.UserType = newWebUser.UserType;
                    originalUser.NickName = newWebUser.NickName;
                    originalUser.Telephone = newWebUser.Telephone;
                    originalUser.Sex = newWebUser.Sex;
                    originalUser.Cellphone = newWebUser.Cellphone;
                    originalUser.Email = newWebUser.Email;
                    originalUser.Address = newWebUser.Address;
                    originalUser.Fax = newWebUser.Fax;
                    originalUser.IsLock = newWebUser.IsLock;
                    originalUser.InIp = newWebUser.InIp;
                    originalUser.Position = newWebUser.Position;
                    originalUser.InTime = newWebUser.InTime;
                    originalUser.Score = newWebUser.Score;
                    originalUser.InUser = newWebUser.InUser;
                    originalUser.IsActivity = newWebUser.IsActivity;
                    originalUser.EditOn = DateTime.Now;
                    context.SaveChanges();
                }
                return 1;
            }
        }
        public int UpdateWebUserFromCenter(WebUser newWebUser)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebUser originalUser = context.WebUser.Find(newWebUser.UserID);
                if (originalUser != null)
                {
                    originalUser.TrueName = newWebUser.TrueName;
                    //originalUser.UserType = newWebUser.UserType;
                    originalUser.NickName = newWebUser.NickName;
                    //originalUser.Telephone = newWebUser.Telephone;
                    originalUser.Sex = newWebUser.Sex;
                    //originalUser.Cellphone = newWebUser.Cellphone;
                    originalUser.Email = newWebUser.Email;
                    //originalUser.Address = newWebUser.Address;
                    originalUser.ProvinceID = newWebUser.ProvinceID;
                    originalUser.ProvinceName = newWebUser.ProvinceName;
                    originalUser.CityID = newWebUser.CityID;
                    originalUser.CityName = newWebUser.CityName;
                    originalUser.AreasID = newWebUser.AreasID;
                    originalUser.AreasName = newWebUser.AreasName;
                    originalUser.Img = newWebUser.Img;
                    originalUser.thumbnailImage = newWebUser.thumbnailImage;
                    //originalUser.Fax = newWebUser.Fax;
                    //originalUser.IsLock = newWebUser.IsLock;
                    //originalUser.InIp = newWebUser.InIp;
                    //originalUser.Position = newWebUser.Position;
                    //originalUser.InTime = newWebUser.InTime;
                    //originalUser.Score = newWebUser.Score;
                    //originalUser.InUser = newWebUser.InUser;
                    //originalUser.IsActivity = newWebUser.IsActivity;
                    originalUser.EditOn = DateTime.Now;
                    context.SaveChanges();
                }
                return 1;
            }
        }
        public WebUser GetWebUserByID(int userID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebUser.Find(userID);
            }
        }

        public WebUser GetWebUserByAccount(string userAccount, string userPwd)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebUser user = context.WebUser.FirstOrDefault(us => us.UserName == userAccount && us.Password == userPwd);
                return user;
            }
        }

        public WebUser GetWebUserByAccount(string userAccount)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebUser user = context.WebUser.FirstOrDefault(us => us.UserName == userAccount);
                return user;
            }
        }

        public int deleteWebUser(int UserID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebUser originalNews = context.WebUser.Find(UserID);
                if (originalNews != null)
                {
                    originalNews.IsDelete = true;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }


        t_AreaService areaSer = new t_AreaService();
        //在手机端修改user
        public int UpdateWebUserFromMobileBywoker(int id, string data, string type)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebUser originalUser = context.WebUser.Find(id);
                WebWorker originWorker = context.WebWorker.FirstOrDefault(c => c.UserID == id);
                if (originalUser != null)
                {

                    switch (type)
                    {
                        case "Img":
                            List<string> ili = data.Split(';').ToList();
                            originalUser.Img = ili[0];
                            originalUser.thumbnailImage = ili[1];
                            originWorker.WorkerImage= ili[0];
                            originWorker.thumbnailImage= ili[1];
                            break;
                        case "TrueName":
                            originalUser.TrueName = data;
                            originWorker.WorkerName = data;
                            break;
                        case "NickName":
                            originalUser.NickName = data;
                            break;

                        case "Sex":
                            originalUser.Sex = data;
                            break;
                        case "Email":
                            originalUser.Email = data;
                            originWorker.WorkerMail = data;
                            break;
                        case "CityID":
                            t_City city = areaSer.GetCityByID(data);
                            originalUser.ProvinceID = city.father;
                            originalUser.ProvinceName = areaSer.GetProvince(city.father).province;
                            originalUser.CityID = data;
                            originalUser.CityName = city.city;
                            originalUser.AreasID = "0";
                            originalUser.AreasName = "全城";

                            originWorker.ProvinceID= city.father;
                            originWorker.ProvinceName= areaSer.GetProvince(city.father).province;
                            originWorker.CityID = data;
                            originWorker.CityName = city.city;
                            originWorker.AreasID = "0";
                            originWorker.AreasName = "全城";
                            break;
                        case "AreasID":
                            List<string> area = data.Split(';').ToList(); 
                            originalUser.AreasID = area[0];
                            originalUser.AreasName = area[1];
                            originWorker.AreasID = area[0];
                            originWorker.AreasName = area[1];
                            break;
                        default:

                            break;
                    }
                    originalUser.EditOn = DateTime.Now;
                    context.SaveChanges();
                }
                return 1;
            }
        }
        public int UpdateWebUserFromMobile(int id, string data, string type)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebUser originalUser = context.WebUser.Find(id);
                if (originalUser != null)
                {

                    switch (type)
                    {
                        case "Img":
                            List<string> ili = data.Split(';').ToList();
                            originalUser.Img = ili[0];
                            originalUser.thumbnailImage = ili[1];
                            break;
                        case "TrueName":
                            originalUser.TrueName = data;
                            break;
                        case "NickName":
                            originalUser.NickName = data;
                            break;

                        case "Sex":
                            originalUser.Sex = data;
                            break;
                        case "Email":
                            originalUser.Email = data;
                            break;
                        case "CityID":
                            t_City city = areaSer.GetCityByID(data);
                            originalUser.ProvinceID = city.father;
                            originalUser.ProvinceName = areaSer.GetProvince(city.father).province;
                            originalUser.CityID = data;
                            originalUser.CityName = city.city;
                            originalUser.AreasID = "0";
                            originalUser.AreasName = "全城";
                            break;
                        default:

                            break;
                    }
                    originalUser.EditOn = DateTime.Now;
                    context.SaveChanges();
                }
                return 1;
            }
        }
    }
}
