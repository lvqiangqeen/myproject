using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIYunNet.CMS.Common.Utility
{
	public class FileHelper
	{
		public static string GetFileTag(string fileName)
		{
			if (!string.IsNullOrEmpty(fileName) && fileName.IndexOf(".") > -1)
			{
				string extension = fileName.Split('.')[1].TrimEnd();
				string[] imageExtension = new string[] { "jpg", "png", "gif" };
				string[] fileExtension = new string[] { "doc", "docx", "pdf", "xls", "xlsx" };
				if (imageExtension.Contains(extension.ToLower()))
				{
					return "Image";
				}
				if (fileExtension.Contains(extension.ToLower()))
				{
					return "File";
				}
				return string.Empty;
			}
			else {
				return string.Empty;
			}
		}
        public static string GetDownLoadTag(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName) && fileName.IndexOf(".") > -1)
            {
                string extension = fileName.Split('.')[1].TrimEnd();
                return extension;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
