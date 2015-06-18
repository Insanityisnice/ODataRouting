using ODataExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace ODataExample.Controllers.odata
{
	public class FooBarController : ODataController
	{
		[HttpGet]
		[EnableQuery(PageSize = 25)]
		[ODataRoute("Values")]
		public IHttpActionResult GetValues()
		{
			return Ok(new List<Value>());
		}
	}
}
