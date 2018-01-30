using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.BLL.IService
{
	public interface IWebFile
	{
		List<WebFile> GetWebFileList();
		WebFile GetWebFileByID(int fileID);
		int AddWebFile(WebFile webFile);
		int UpdateWebFile(WebFile webFile);
		int DeleteWebFile(int fileID);
	}
}
