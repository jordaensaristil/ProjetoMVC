using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_GerenciadorDeConteudo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                "sobre_jordaens_parametro",
                "sobre/{id}/jordaens",
                new {Controller="Home",Action="about",id=0}
                );

            //routes.MapRoute(
            //    "sobre",
            //    "sobre",
            //    new { Controller = "Home", Action = "about" }
            // );

            routes.MapRoute(
                "paginas",
                "Paginas",
                new { Controller = "Paginas", Action = "Index" }
             );

            routes.MapRoute(
              "paginas_criar",
              "paginas/criar",
              new { Controller = "Paginas", Action = "criar" }
           );
            routes.MapRoute(
               "paginas_exluir",
               "paginas/{id}/excluir",
               new { Controller = "Paginas", Action = "Excluir", id = 0 }
            );

            routes.MapRoute(
               "paginas_alterar",
               "paginas/{id}/alterar",
               new { Controller = "Paginas", Action = "Alterar", id=0}
            );
            routes.MapRoute(
               "paginas_editar",
               "paginas/{id}/editar",
               new { Controller = "Paginas", Action = "Editar", id = 0 }
            );

            routes.MapRoute(
               "paginas_novo",
               "paginas/novo",
               new { Controller = "Paginas", Action = "Novo" }
            );

            //routes.MapRoute(
            //    "contato",
            //    "contato",
            //    new {Controller="Home", Action = "contact" }
            // );

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "paginas", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
