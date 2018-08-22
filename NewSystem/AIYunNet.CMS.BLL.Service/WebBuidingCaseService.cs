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
    public class WebBuidingCaseService
    {
        public WebBuidingCase GetBuidingCaseByID(int id)
        {
            WebBuidingCase buidingcse = new WebBuidingCase();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                try
                {
                    buidingcse = context.WebBuidingCase.Find(id);
                    if (buidingcse == null)
                    {
                        buidingcse= new WebBuidingCase();
                    }
                }
                catch (Exception e)
                {
                }
                return buidingcse;
            }
        }
        public List<WebBuidingCase> GetBuidingCaseListByUserID(int userid,int count=0)
        {
            List<WebBuidingCase> list = new List<WebBuidingCase>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                try
                {
                    if (count > 0)
                    {
                        list = context.WebBuidingCase.Where(c => c.UserID == userid && c.IsDelete == 0).OrderByDescending(c => c.sorting).OrderByDescending(c => c.EditOn).Take(count).ToList();
                    }else
                    {
                        list = context.WebBuidingCase.Where(c => c.UserID == userid && c.IsDelete == 0).OrderByDescending(c => c.sorting).OrderByDescending(c => c.EditOn).ToList();
                    }
                    

                    if (list == null)
                    {
                        list = new List<WebBuidingCase>();
                    }
                }
                catch (Exception e)
                {
                }
                return list;
            }
        }
        public List<WebBuidingCase> GetBuidingCaseList()
        {
            List<WebBuidingCase> list = new List<WebBuidingCase>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                try
                {
                    list = context.WebBuidingCase.Where(c =>c.IsDelete == 0).OrderByDescending(c => c.EditOn).ToList();                   
                    if (list == null)
                    {
                        list = new List<WebBuidingCase>();
                    }
                }
                catch (Exception e)
                {
                }
                return list;
            }
        }
        public List<WebBuidingCase> GetBuidingCaseListByWorkerID(int workerid,int count=0)
        {
            List<WebBuidingCase> list = new List<WebBuidingCase>();
            using (AIYunNetContext context = new AIYunNetContext())
            {
                try
                {
                    if (count > 0)
                    {
                        list = context.WebBuidingCase.Where(c => c.WorkerID == workerid && c.IsDelete == 0).OrderByDescending(c => c.sorting).OrderByDescending(c => c.EditOn).Take(count).ToList();
                    }
                    else
                    {
                        list = context.WebBuidingCase.Where(c => c.WorkerID == workerid && c.IsDelete == 0).OrderByDescending(c => c.sorting).OrderByDescending(c => c.EditOn).ToList();
                    }
                    if (list == null)
                    {
                        list = new List<WebBuidingCase>();
                    }
                }
                catch (Exception e)
                {
                }
                return list;
            }
        }

        public int updateBuidingCase(WebBuidingCase buidingcase)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebBuidingCase oldcase = context.WebBuidingCase.Find(buidingcase.id);
                oldcase.title = buidingcase.title;
                oldcase.info = buidingcase.info;
                oldcase.headimg = buidingcase.headimg;
                oldcase.headthum = buidingcase.headthum;
                oldcase.textimg = buidingcase.textimg;
                oldcase.textthumbnailImage = buidingcase.textthumbnailImage;
                oldcase.sorting = buidingcase.sorting;
                oldcase.EditOn = DateTime.Now;
                context.SaveChanges();
                return 1;
            }
        }

        public int addBuidingCase(WebBuidingCase buidingcase)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebBuidingCase.Add(buidingcase);
                context.SaveChanges();
                return 1;
            }
        }

    }
}
