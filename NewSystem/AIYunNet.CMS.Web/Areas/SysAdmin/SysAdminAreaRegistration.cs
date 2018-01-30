﻿using System.Web.Mvc;

namespace AIYunNet.CMS.Web.Areas.SysAdmin
{
	public class SysAdminAreaRegistration : AreaRegistration
	{
		public override string AreaName
		{
			get
			{
				return "SysAdmin";
			}
		}

		public override void RegisterArea(AreaRegistrationContext context)
		{
			context.MapRoute(
				"SysAdmin_default",
				"SysAdmin/{controller}/{action}/{id}",
				new { action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
