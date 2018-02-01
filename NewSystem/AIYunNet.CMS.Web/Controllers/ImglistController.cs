using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.BLL.IService;

namespace AIYunNet.CMS.Web.Controllers
{
    public class ImglistController : Controller
    {
        //
        // GET: /Imglist/
        WebImgService webImgService = new WebImgService();
        IWebCommon webCommonService = new WebCommonService();
        IWebPicture webPictureService = new WebPictureService();
        public ActionResult Index()
        {
            return View();
        }
        [Description("图库列表")]
        public ActionResult Imagelist()
        {
            List<WebLookup> softcoverstylelist = webCommonService.GetLookupList("Img_softcoverstyle");
            List<WebLookup> hotalstylelist = webCommonService.GetLookupList("Img_hotalstyle");
            List<WebLookup> designerrstylelist = webCommonService.GetLookupList("Img_designerrstyle");
            List<WebLookup> commercialstylelist = webCommonService.GetLookupList("Img_commercialstyle");
            List<WebLookup> housestylelist = webCommonService.GetLookupList("Img_housestyle");
            ViewBag.softcoverstylelist = softcoverstylelist;
            ViewBag.hotalstylelist = hotalstylelist;
            ViewBag.designerrstylelist = designerrstylelist;
            ViewBag.commercialstylelist = commercialstylelist;
            ViewBag.housestylelist = housestylelist;
            return View();
        }
        [Description("图库详情")]
        public ActionResult ImgDetail(int webImgID)
        {
            WebImg webImg = webImgService.GetWebImgByID(webImgID);
            return View(webImg);
        }

        public ActionResult PictureList(int webImgID)
        {
            webImgService.PageViewAdd(webImgID);
            List<WebPicture> webImglist = webPictureService.GetWebPictureList(webImgID);
            ViewBag.webImglist = webImglist;
            return View();
        }
        [Description("设计图库列表")]
        public ActionResult DecImagelist()
        {
            return View();
        }
        public ActionResult DecPictureList()
        {
            return View();
        }
    }
}
