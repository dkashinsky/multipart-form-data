using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApi.Utils;

namespace WebApi
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Web API configuration and services
      config.EnableCors();
      config.Formatters.Add(new MultipartFormDataMediaTypeFormatter());

      // Web API routes
      config.MapHttpAttributeRoutes();

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );
    }
  }
}
