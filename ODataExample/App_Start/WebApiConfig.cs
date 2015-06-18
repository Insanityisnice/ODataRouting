using Microsoft.OData.Edm;
using Newtonsoft.Json.Serialization;
using ODataExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace ODataExample.App_Start
{
	public static class WebApiConfig
	{
		public static HttpConfiguration Configure()
		{
			HttpConfiguration configuration = new HttpConfiguration();

			//Set json formatter as the default
			var xmlFormatter = configuration.Formatters.XmlFormatter;
			configuration.Formatters.Remove(configuration.Formatters.XmlFormatter);
			//configuration.Formatters.Add(xmlFormatter);

			//Configure Serializer
			var jsonFormatter = configuration.Formatters.OfType<JsonMediaTypeFormatter>().First();
			jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			jsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
			jsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
			jsonFormatter.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());

			configuration.MapHttpAttributeRoutes();

			configuration.Routes.MapHttpRoute(
			   name: "DefaultApi",
			   routeTemplate: "api/{controller}");

			configuration.EnableCaseInsensitive(true);
			configuration.MapODataServiceRoute(
				routeName:"ODataRoute", 
				routePrefix: "odata", 
				model: GetEdmModel());

			return configuration;
		}

		private static IEdmModel GetEdmModel()
		{
			ODataModelBuilder builder = new ODataModelBuilder();


			var value = builder.EntityType<Value>();

			//Key
			value.HasKey(c => c.Id);

			//Properties
			value.Property(c => c.Name);
			value.Property(c => c.Description).IsOptional();

			builder.EntitySet<Value>("values");

			return builder.GetEdmModel();
		}
	}
}