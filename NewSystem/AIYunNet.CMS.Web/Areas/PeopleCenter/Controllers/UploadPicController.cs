using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.Common.Utility.Model;
using AIYunNet.CMS.Common.Utility;

namespace AIYunNet.CMS.Web.Areas.PeopleCenter.Controllers
{
    public class UploadPicController : Controller
    {
        // GET: PeopleCenter/UploadPic
        [HttpPost]
        public ActionResult CenterPictrueUpload()
        {
            HttpPostedFileBase myFile = Request.Files["ImageUpload"];
            //获取图片的种类对应图片文件夹名称（公司，工人，设计师,或案例）
            string ImageType = "PeopleCenter";
            //缩略图宽高
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
            return Json(new { isUploaded = isUploaded, message = message, thumbnailmessage = thumbnailmessage }, "text/html");
        }

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
    }
}