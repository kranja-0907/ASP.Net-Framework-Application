using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RWA_Aplikacija
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Camel Casing za promjenu propertija u postmanu malo slovo pocetno
            var postavke = config.Formatters.JsonFormatter.SerializerSettings;
            postavke.ContractResolver = new CamelCasePropertyNamesContractResolver();
            postavke.Formatting = Formatting.Indented;
            config.MapHttpAttributeRoutes();            

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
