using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace AIYunNet.CMS.Common.Utility.Model
{
    /// <summary>
    /// 对上传图片路径信息的封装，主要包含图片在服务器上存储的地址等信息
    /// </summary>
    /// <remarks>@FrancisTan 2016-05-17</remarks>
    public class ImagePathInfo
    {
        #region Properties
        /// <summary>
        /// 原始图片名称
        /// </summary>
        public string OriginalFileName { get; set; }

        /// <summary>
        /// 新的图片名称
        /// </summary>
        public string NewFileName { get; set; }

        /// <summary>
        /// 图片类型（后缀名，*.jpg）
        /// </summary>
        public string ImgExtension { get { return Path.GetExtension(OriginalFileName); } }

        /// <summary>
        /// 图片存储在服务器上根目录
        /// </summary>
        public string RootRelativeDir { get; set; }

        /// <summary>
        /// 图片存储在服务器磁盘上的目录的绝对路径
        /// </summary>
        public string RootAbsolutePath { get; set; }

        /// <summary>
        /// 图片存储在服务器上的相对路径
        /// </summary>
        public string FileRelativePath { get { return Path.Combine(RootRelativeDir, NewFileName).Replace("\\", "/"); } }

        /// <summary>
        /// 图片存储在服务器磁盘上的绝对路径
        /// </summary>
        public string FileAbsolutePath { get { return Path.Combine(RootAbsolutePath, NewFileName).Replace("/", "\\"); } }
        #endregion

        /// <summary>
        /// 通过指定参数创建ImgPathInfo对象
        /// </summary>
        /// <param name="fileName">图片文件名称</param>
        /// <param name="relativeDirPath">图片存储于服务器的目录的相对路径</param>
        public ImagePathInfo(string fileName, string relativeDirPath)
        {
            OriginalFileName = fileName;

            var dir = relativeDirPath.Replace("~/", "/");
            var rootAbPath = HttpContext.Current.Server.MapPath(dir);
            var dateDirName = DateTime.Now.ToString("yyyy/MM/dd");
            RootAbsolutePath = Path.Combine(rootAbPath, dateDirName);
            RootRelativeDir = Path.Combine(dir, dateDirName);

            var guid = Guid.NewGuid();
            NewFileName = guid + ImgExtension;
        }

        /// <summary>
        /// 判断指定的目录是否存在，若不存在则创建
        /// </summary>
        public void CreateDirectory()
        {
            if (!Directory.Exists(RootAbsolutePath))
            {
                Directory.CreateDirectory(RootAbsolutePath);
            }
        }

        /// <summary>
        /// 此方法是为了兼容以前的配置文件中目录路径开头不带/的情况
        /// </summary>
        /// <param name="path">待处理的路径</param>
        /// <returns>确保目录路径自根目录开始的新路径</returns>
        public static string ProcessBeginOfThePath(string path)
        {
            if (!path.StartsWith("/") && !path.StartsWith("\\") &&
                !path.StartsWith("~/"))
            {
                return "/" + path;
            }

            return path;
        }
    }
}
