using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.IO;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.BLL.Service;
using AIYunNet.CMS.Common.Utility;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.Web.Areas.SysAdmin.Controllers
{
    public class AppWorkerController : BaseController
    {
        // GET: SysAdmin/AppWorker
        public ActionResult WebBuidingConstractList()
        {
            return View();
        }
    }
}