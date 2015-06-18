using ODataExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ODataExample.Controllers.api
{
	[RoutePrefix("api")]
	public class ValuesController : ApiController
	{
		[HttpGet]
		public IHttpActionResult GetValue()
		{
			return Ok(new List<Value>());
		}
	}
}
