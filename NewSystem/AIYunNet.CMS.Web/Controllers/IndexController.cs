using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.Web.filter;

namespace AIYunNet.CMS.Web.Controllers
{
    [AllSessionFilter]
    public class IndexController : Controller
    {
        IWebCompany webCompanyService = new WebCompanyService();
        IWebPeople webPeopleService = new WebPeopleService();
        IWebCase webCaseService = new WebCaseService();
        IWebNews webNewsService = new WebNewsService();
        IWebCommon webCommonService = new WebCommonService();//获取参数接口（包括各项分类）
        IWebMenu webMenuService = new WebMenuService();
        //首页推送管理
        IWebRecommend webRecommend = new WebRecommendService();
        public ActionResult HomeIndex()
        {
            //List<WebLookup> Case_stylelist = webCommonService.GetLookupListByCount("Case_style", 5);
            //ViewBag.Case_stylelist = Case_stylelist;

            indexList lunbolist = webRecommend.GetIndexListPc(7, 5, false);
            indexList newslunbolist = webRecommend.GetIndexListPc(10, 5, false);
            //家装图库
            indexList jiazhuanglist = webRecommend.GetIndexListPc(17, 6, false);
            ViewBag.jiazhuanglist = jiazhuanglist;
            //工装图库
            indexList gongzhuanglist = webRecommend.GetIndexListPc(18, 6, false);
            ViewBag.gongzhuanglist = gongzhuanglist;
            //找机构
            indexList companylist = webRecommend.GetIndexListPc(6, 5, false);
            indexList companylistsmall = webRecommend.GetIndexListPc(6, 5, true);
            //装修公司
            indexList CompanyTJlist = webRecommend.GetIndexListPc(16, 5, false);
            ViewBag.CompanyTJlist = CompanyTJlist;
            //设计案例
            indexList caselist = webRecommend.GetIndexListPc(2, 5, false);
            //找设计师
            indexList designerlist = webRecommend.GetIndexListPc(3, 5, false);
            indexList designerlistsmall = webRecommend.GetIndexListPc(3, 10, false);
            //找工长
            indexList workheaderlist = webRecommend.GetIndexListPc(4,5,false);
            indexList workheaderlistsmall = webRecommend.GetIndexListPc(4, 10, false);
            indexList linchenglist = webRecommend.GetIndexListPc(8,0,false);
            //新闻资讯
            indexList newslist = webRecommend.GetIndexListPc(1, 4, false);
            //装修推荐
            indexList tuijianlist = webRecommend.GetIndexListPc(9, 5, false);
            indexList tuijianlistsmall = webRecommend.GetIndexListPc(9, 10, false);
            //装修流程
            indexList liuchenglist = webRecommend.GetIndexListPc(11, 0, false);
            ViewBag.liuchenglist = liuchenglist;
            //优秀工人
            indexList worklist = webRecommend.GetIndexListPc(5,4, false);
            ViewBag.lunbolist = lunbolist;
            ViewBag.newslunbolist = newslunbolist;
            ViewBag.companylist = companylist;
            ViewBag.companylistsmall = companylistsmall;
            ViewBag.caselist = caselist;
            ViewBag.designerlist = designerlist;
            ViewBag.designerlistsmall = designerlistsmall;
            ViewBag.workheaderlist = workheaderlist;
            ViewBag.workheaderlistsmall = workheaderlistsmall;
            ViewBag.linchenglist = linchenglist;
            ViewBag.newslist = newslist;
            ViewBag.tuijianlist = tuijianlist;
            ViewBag.tuijianlistsmall = tuijianlistsmall;
            
            ViewBag.worklist = worklist;
            //家装设计
            indexList jzDeclist = webRecommend.GetIndexListPc(19, 0, false);
            ViewBag.jzDeclist = jzDeclist;
            //工装设计
            indexList gzDeclist = webRecommend.GetIndexListPc(20, 0, false);
            ViewBag.gzDeclist = gzDeclist;
            //设计图库
            indexList tkDeclist = webRecommend.GetIndexListPc(21, 0, false);
            ViewBag.tkDeclist = tkDeclist;
            return View();

        }
    }
}
