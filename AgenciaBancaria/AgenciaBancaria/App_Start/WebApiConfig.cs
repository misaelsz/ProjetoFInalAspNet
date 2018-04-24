using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AgenciaBancaria
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {


            //Formatar os dados da API em JSON
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.Indent = true;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
