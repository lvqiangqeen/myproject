using AIYunNet.CMS.Common.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.Common.Utility.Model;

namespace AIYunNet.CMS.Web.Areas.SysAdmin.Controllers
{
    public class FileUploadController : Controller
    {
        [HttpPost]
        public ActionResult UploadFileDownload()
        {
            HttpPostedFileBase myFile = Request.Files["DownloadUpload"];
            bool isUploaded = false;
            string message = "上传失败!";
            //缩略图图片路径
            string fileType = "";
            string ImgRootUrl = string.Empty;
            string sizestr = "";
            if (myFile != null && myFile.ContentLength != 0)
            {
                string pathForSaving = string.Empty;
                fileType = FileHelper.GetDownLoadTag(myFile.FileName);
                double size = Math.Round(myFile.ContentLength * 1.0 / 1024 * 1.0,2);
                if (size > 1024)
                {
                    size = Math.Round(size * 1.0 / 1024 * 1.0,2);
                    sizestr = size + "MB";
                } else
                {
                    sizestr = size + "KB";
                }
                pathForSaving = ImagePathInfo.ProcessBeginOfThePath("/DownLoad/Files");
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
                    }
                    catch (Exception ex)
                    {
                        message = string.Format("File upload failed: {0}", ex.Message);
                    }
                }


            }
            return Json(new { isUploaded = isUploaded, message = message, form = fileType,size= sizestr }, "text/html");
        }
        [HttpPost]
        public ActionResult UploadFile()
        {
            HttpPostedFileBase myFile = Request.Files["ImageUpload"];
            //获取图片的种类对应图片文件夹名称（公司，工人，设计师,或案例）
            string ImageType = Request["ImageType"];

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
                            if (ImageType == "CaseImageBig")
                            {

                                width = 258;
                                height = 100;
                                quality = 20;
                            }
                            else
                            {
                                width = 100;
                                height = 100;
                                quality = 10;
                            }

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

        public ActionResult UploadFileForEditor()
        {
            var files = Request.Files;
            if (files.Count <= 0)
            {
                return Content("error|file is null");
            }
            HttpPostedFileBase file = files[0];

            if (file == null)
            {
                return Content("error|file is null");
            }
            else
            {
                string path = Server.MapPath("~/UploadFiles/EditorFiles/");  //存储图片的文件夹
                string originalFileName = file.FileName;
                string fileExtension = originalFileName.Substring(originalFileName.LastIndexOf('.'), originalFileName.Length - originalFileName.LastIndexOf('.'));
                string currentFileName = (new Random()).Next() + fileExtension;  //文件名中不要带中文，否则会出错
                string imagePath = path + currentFileName;
                file.SaveAs(imagePath);
                string imgUrl = "http://" + Request.Url.Authority + "/UploadFiles/EditorFiles/" + currentFileName;
                return Content(imgUrl);
            }
        }

        //首页推送上传
        [HttpPost]
        public ActionResult IndexPictrueUpload()
        {
            HttpPostedFileBase myFile = Request.Files["ImageUpload"];
            //获取图片的种类对应图片文件夹名称（公司，工人，设计师,或案例）
            string ImageType = Request["ImageType"];
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


        //图库上传
        [HttpPost]
        public ActionResult TkuPictrueUpload()
        {
            HttpPostedFileBase myFile = Request.Files["ImageUpload"];
            //获取图片的种类对应图片文件夹名称（公司，工人，设计师,或案例）
            string ImageType = "PictureImg";
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
