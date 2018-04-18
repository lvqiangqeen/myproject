using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Common.Utility.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIYunNet.CMS.Web.Areas.MobileApp.Controllers
{
    public class uploadController : Controller
    {
        private bool CreateFolderIfNeeded(string path)
        {
            bool result = true;
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {

                    result = false;
                }
            }
            return result;
        }
        // GET: MobileApp/upload
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult mPictrueUpload()
        {
            HttpPostedFileBase myFile = Request.Files[0];
            string ImageType = "mobileCenter";
            int thumwidth = Convert.ToInt32(Request["thumwidth"]) == 0 ? 100 : Convert.ToInt32(Request["thumwidth"]);
            int thumheight = Convert.ToInt32(Request["thumheight"]) == 0 ? 100 : Convert.ToInt32(Request["thumheight"]);
            int thumquality = Convert.ToInt32(Request["thumquality"]) == 0 ? 10 : Convert.ToInt32(Request["thumquality"]);

            bool isUploaded = false;
            string message = "上传失败!";
            //缩略图图片路径
            string thumbnailmessage = "";
            string ImgRootUrl = string.Empty;

            if (myFile != null && myFile.ContentLength != 0)
            {
                string pathForSaving = string.Empty;
                string fileType = FileHelper.GetFileTag(myFile.FileName);
                if (fileType == "Image")
                {
                    pathForSaving = ImagePathInfo.ProcessBeginOfThePath("/UploadFiles/Images/" + ImageType);
                    //pathForSaving = Server.MapPath("~/UploadFiles/Images/"+ ImageType);
                }
                else
                {
                    pathForSaving = ImagePathInfo.ProcessBeginOfThePath
                        ("/UploadFiles/Files");
                }

                if (this.CreateFolderIfNeeded(pathForSaving))
                {
                    try
                    {
                        //图片路径处理
                        var ImgUrl = new ImagePathInfo(myFile.FileName, pathForSaving);
                        //如果路径不存在则新建
                        ImgUrl.CreateDirectory();
                        //保存图片
                        myFile.SaveAs(ImgUrl.FileAbsolutePath);
                        isUploaded = true;
                        //保存后的图片路径
                        message = ImgUrl.FileRelativePath;


                        //缩略图处理
                        var thumbnailPathInfo = new ImagePathInfo(myFile.FileName, pathForSaving);
                        using (var imgStream = myFile.InputStream)
                        {
                            var width = 0;
                            var height = 0;
                            var quality = 0;

                            width = thumwidth;
                            height = thumheight;
                            quality = thumquality;


                            using (var thumbNail = ImageHelper.GetThumbnail(imgStream, width, height, quality))
                            {
                                thumbnailPathInfo.CreateDirectory();
                                thumbNail.Save(thumbnailPathInfo.FileAbsolutePath);
                            }
                        }
                        thumbnailmessage = thumbnailPathInfo.FileRelativePath;

                    }
                    catch (Exception ex)
                    {
                        message = string.Format("File upload failed: {0}", ex.Message);
                    }
                }
            }
            return Json(new { isUploaded = isUploaded, message = message, thumbnailmessage = thumbnailmessage });
        }
    }
}