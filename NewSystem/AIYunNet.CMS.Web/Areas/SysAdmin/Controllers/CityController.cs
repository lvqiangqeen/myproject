using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.Web.Areas.SysAdmin.Controllers
{
    public class CityController : Controller
    {
        t_AreaService areaService = new t_AreaService();
        // GET: SysAdmin/City
        public ActionResult HotCityList()
        {
            List<t_City> list = areaService.GetHotCityList();
            ViewBag.citylist = list;
            return View();
        }

        [HttpGet]
        public ActionResult UpdateAndAddHotCity(string cityid)
        {
            t_City city = areaService.GetCityByID(cityid);
            if (city == null)
            {
                city = new t_City();
            }

            //获取推送类别
            IEnumerable<SelectListItem> provinceList = null;
            List<t_Province> common = areaService.GetProvinceList();
            provinceList = common.Select(com => new SelectListItem { Value = com.provinceID.ToString(), Text = com.province });

            ViewBag.provinceList = provinceList;
            return View(city);
        }

        [HttpPost]
        public ActionResult UpdateAndAddHotCity(t_City city)
        {
            int result = 0;

            result = areaService.Updatehotcity(city);
            
            return Json(new { RetCode = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteHotCity(string cityid)
        {
            areaService.DeleteCity(cityid);
            return Json(new { RetCode = 1 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCityListByfather(string father)
        {
            List<t_City> citylist= areaService.GetCityListByfather(father);
            return Json(new { list = citylist }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAreasListByfather(string father)
        {
            List<t_Area> arealist = areaService.GetAreaListByfather(father);
            return Json(new { list = arealist }, JsonRequestBehavior.AllowGet);
        }
    }
}