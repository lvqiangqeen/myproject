using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.Model;
using Newtonsoft.Json;

namespace AIYunNet.CMS.Web.Areas.SysAdmin.Controllers
{
    public class ImageListController : BaseController
    {
        // GET: SysAdmin/ImageList
        IWebImg webImgService = new WebImgService();
        IWebCommon webCommonService = new WebCommonService();
        IWebPicture webPictureService = new WebPictureService();
        [HttpGet]
        public ActionResult WebImageList(int DecType)
        {
            List<WebImg> imglist = webImgService.GetWebImgList(DecType);
            ViewBag.imglist = imglist;
            return View();
        }
        [HttpGet]
        public ActionResult AddOrEditWebImg(int ImgID)
        {
            WebImg webimg = webImgService.GetWebImgByID(ImgID);
            if (webimg == null)
            {
                webimg = new WebImg();
            }

            List<WebLookup> Case_DecTypelist = webCommonService.GetLookupList("Case_DecType");
            List<WebLookup> Case_stylelist = webCommonService.GetLookupList("Case_style");
            List<WebLookup> Case_gz_stylelist = webCommonService.GetLookupList("Case_gz_style");
            List<WebLookup> Case_Img_Jzspacelist = webCommonService.GetLookupList("Case_Img_Jzspace");
            //List<WebLookup> housestylelist = webCommonService.GetLookupList("Img_housestyle");

            IEnumerable<SelectListItem> Case_DecType = Case_DecTypelist.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });
            IEnumerable<SelectListItem> Case_style = Case_stylelist.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });
            IEnumerable<SelectListItem> Case_gz_style = Case_gz_stylelist.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });
            IEnumerable<SelectListItem> Case_Img_Jzspace = Case_Img_Jzspacelist.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });
            //IEnumerable<SelectListItem> housestyle = housestylelist.Select(com => new SelectListItem { Value = com.Code.ToString(), Text = com.Description });

            ViewBag.Case_DecType = Case_DecType;
            ViewBag.Case_style = Case_style;
            ViewBag.Case_gz_style = Case_gz_style;
            ViewBag.Case_Img_Jzspace = Case_Img_Jzspace;
            //ViewBag.housestylelist = housestyle;
            return View(webimg);
        }

        [HttpPost]
        public ActionResult AddOrEditWebImg(WebImg WebImg)
        {
            int result = 0;
            if (WebImg != null && WebImg.ImgId > 0)
            {
                result = webImgService.UpdateWebImg(WebImg);
            }
            else
            {
                result = webImgService.AddWebImg(WebImg);
            }
            return Json(new { RetCode = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteWebImg(int ImgID)
        {
            webImgService.DeleteWebImg(ImgID);
            return Json(new { RetCode = 1 }, JsonRequestBehavior.AllowGet);
        }

        //图片列表
        [HttpGet]
        public ActionResult PictureList(int ImgID)
        {
            //webImgService.DeleteWebImg(ImgID);
            List<WebPicture> piclist = webPictureService.GetWebPictureList(ImgID);
            ViewBag.piclist = piclist;
            return View();
        }

        [HttpPost]
        public ActionResult PictureAddOrEdit()
        {
            string WebImgID = Request["WebImgID"];
            string oldPics = Request["oldPics"];
            string newPics = Request["newPics"];
            List<WebPicture> oldPicsList = JsonConvert.DeserializeObject<List<WebPicture>>(oldPics);
            List<WebPicture> newPicsList = JsonConvert.DeserializeObject<List<WebPicture>>(newPics);
            int result = 0;
            if (oldPicsList.Count()>0)
            {
                foreach (WebPicture pic  in oldPicsList)
                {
                    webPictureService.UpdateWebPicture(pic);
                    result += 1;
                }
            }
            if (newPicsList.Count()>0)
            {
                foreach (WebPicture pic in newPicsList)
                {
                    webPictureService.AddWebPicture(pic);
                    result += 1;
                }
            }
            return Json(new { RetCode = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PictureDelete()
        {
            int pictureID = Convert.ToInt32(Request["pictureID"].ToString());
            webPictureService.DeleteWebPicture(pictureID);
            return Json(new { RetCode = 1 }, JsonRequestBehavior.AllowGet);
        }

    }
}