using Microsoft.Owin;
using ODataExample.App_Start;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(ODataExample.Startup))]

namespace ODataExample
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.UseWebApi(WebApiConfig.Configure());
		}
	}
}