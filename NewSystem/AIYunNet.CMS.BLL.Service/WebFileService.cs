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
	public class WebFileService : IWebFile
	{
		public List<WebFile> GetWebFileList()
		{
			using (AIYunNetContext context = new AIYunNetContext())
			{
				return context.WebFile.Where(file => file.FlagDelete == 0).ToList();
			}
		}

		public WebFile GetWebFileByID(int fileID)
		{
			using (AIYunNetContext context = new AIYunNetContext())
			{
				return context.WebFile.Find(fileID);
			}
		}

		public int AddWebFile(WebFile webFile)
		{
			using (AIYunNetContext context = new AIYunNetContext())
			{
				context.WebFile.Add(webFile);
				context.SaveChanges();
				return 1;
			}
		}

		public int UpdateWebFile(WebFile webFile)
		{
			using (AIYunNetContext context = new AIYunNetContext())
			{
				WebFile originalFile = context.WebFile.Find(webFile.FileID);
				if (originalFile != null)
				{
					originalFile.ClassID = webFile.ClassID;
					originalFile.ClassName = webFile.ClassName;
					originalFile.Click = webFile.Click;
					originalFile.CompanyId = webFile.CompanyId;
					originalFile.Description = webFile.Description;
					originalFile.FileName = webFile.FileName;
					originalFile.FileType = webFile.FileType;
					originalFile.InTime = webFile.InTime;
					originalFile.InUser = webFile.InUser;
					originalFile.Remark = webFile.Remark;
					originalFile.Sequence = webFile.Sequence;
					originalFile.Tags = webFile.Tags;
					originalFile.Title = webFile.Title;
					originalFile.Editon = DateTime.Now;
					context.SaveChanges();
					return 1;
				}
				else
				{
					return 0;
				}
			}
		}

		public int DeleteWebFile(int fileID)
		{
			using (AIYunNetContext context = new AIYunNetContext())
			{
				WebFile originalFile = context.WebFile.Find(fileID);
				if (originalFile != null)
				{
					originalFile.Deleteon = DateTime.Now;
					originalFile.FlagDelete = 0;
					context.SaveChanges();
					return 1;
				}
				else {
					return 0;
				}
			}
		}
	}
}
