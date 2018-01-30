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
    public class DownLoadService
    {

        public int AddDownLoad(DownLoad DownLoad)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.DownLoad.Add(DownLoad);
                context.SaveChanges();
                return 1;
            }
        }

        public int UpdateDownLoad(DownLoad DownLoad)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                DownLoad originalDownLoad = context.DownLoad.Find(DownLoad.ID);
                if (originalDownLoad != null)
                {
                    originalDownLoad.EditOn = DateTime.Now;
                    originalDownLoad.fileurl = DownLoad.fileurl;
                    originalDownLoad.firstID = DownLoad.firstID;
                    originalDownLoad.form = DownLoad.form;
                    originalDownLoad.DownLoadImage = DownLoad.DownLoadImage;
                    originalDownLoad.Info = DownLoad.Info;
                    originalDownLoad.LookupCode = DownLoad.LookupCode;
                    originalDownLoad.score = DownLoad.score;
                    originalDownLoad.secondID = DownLoad.secondID;
                    originalDownLoad.Size = DownLoad.Size;
                    originalDownLoad.thumbnailImage = DownLoad.thumbnailImage;
                    originalDownLoad.title = DownLoad.title;
                    //originalDownLoad.upbody = DownLoad.upbody;
                    //originalDownLoad.userid = DownLoad.userid;
                    //originalDownLoad.usertype = DownLoad.usertype;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int DeleteDownLoad(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                DownLoad originalDownLoad = context.DownLoad.Find(id);
                if (originalDownLoad != null)
                {
                    originalDownLoad.IsDelete = true;
                    originalDownLoad.DeleteOn = DateTime.Now;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        public List<DownLoad> GetDownLoadListByLookupAndfistid(int lookupid, int firstid)
        {
            List<DownLoad> list = new List<DownLoad>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (firstid != 0)
                {
                    list = context.DownLoad.Where(c => c.LookupCode == lookupid && c.firstID == firstid && c.IsDelete==false).ToList();
                }
                else
                {
                    list = context.DownLoad.Where(c => c.LookupCode == lookupid && c.IsDelete == false).ToList();
                }
                
                return list;
            }
        }

        public List<DownLoadType> GetDownLoadTypeOne(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                List<DownLoadType> list = context.DownLoadType.Where(c => c.LookupID == id && c.fatherID == 0 && c.Isdelete == 0).ToList();
                return list;
            }
        }
        public List<DownLoadType> GetDownLoadTypeTwo(int id)
        {
            List<DownLoadType> list = new List<DownLoadType>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (id != 0)
                {
                    list = context.DownLoadType.Where(c => c.fatherID == id && c.Isdelete==0).ToList();
                }
                return list;
            }
        }
        public DownLoad GetDownLoadDetail(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                DownLoad model = context.DownLoad.Find(id);
                return model;
            }
        }

        //推荐下载
        public List<DownLoad> GetDownLoadList(int firstid)
        {
            List<DownLoad> list = new List<DownLoad>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                try
                {
                    list = context.DownLoad.Where(c => c.firstID == firstid && c.IsDelete==false).OrderByDescending(c => c.DownloadCount).Take(6).ToList();
                }
                catch (Exception e)
                {
                }
                return list;
            }
        }
        //获取下载分类
        public List<DownloadTypeList> GetDownloadTypeListByLookupID(int LookupID)
        {
            List<DownloadTypeList> list = new List<DownloadTypeList>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                try
                {
                    List<DownLoadType> typelist = context.DownLoadType.Where(c => c.LookupID == LookupID && c.fatherID == 0 && c.Isdelete==0).ToList();
                    foreach (DownLoadType item in typelist)
                    {
                        DownloadTypeList model = new DownloadTypeList();
                        model.typeid = item.id;
                        model.typename = item.name;
                        List<DownLoadType> list1 = context.DownLoadType.Where(c => c.fatherID == item.id && c.Isdelete == 0).ToList();
                        model.list = list1;
                        list.Add(model);
                    }
                    return list;
                }
                catch (Exception e)
                {
                    return list;
                }             
            }
        }

        public string GetDownloadtitle(int lookupcode,int firstid,int secondid)
        {
            string name = "";
            string firstname = "";
            string secondname = "";
            using (AIYunNetContext context = new AIYunNetContext())
            {
                try
                {
                    WebCommonService comser = new WebCommonService();
                    string lookupname = comser.GetLookupDesc("DownLoad_type", lookupcode.ToString());
                    if (firstid != 0)
                    {
                        firstname ="--"+ context.DownLoadType.Find(firstid).name;
                    }
                    if (secondid != 0)
                    {
                        DownLoadType type = context.DownLoadType.Find(secondid);
                        secondname = "--" + type.name;
                        firstname = "--" + context.DownLoadType.Find(type.fatherID).name;
                    }
                    name = lookupname + firstname + secondname;
                    return name;
                }
                catch (Exception e)
                {
                    return name;
                }
            }
        }

        public int DeleteDownLoadtype(int id)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                DownLoadType originalDownLoad = context.DownLoadType.Find(id);
                if (originalDownLoad != null)
                {
                    originalDownLoad.Isdelete = 1;
                    List<DownLoadType> list = context.DownLoadType.Where(c => c.fatherID == id).ToList();
                    if (list.Count() > 0)
                    {
                        foreach (var item in list)
                        {
                            item.Isdelete = 1;
                        }
                    }
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int addDownLoadtype(DownLoadType downloadtype)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.DownLoadType.Add(downloadtype);
                context.SaveChanges();
                return 1;
            }
        }
    }
}
