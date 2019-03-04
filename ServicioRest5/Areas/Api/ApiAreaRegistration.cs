using System.Web.Mvc;

namespace ServicioRest5.Areas.Api
{
    public class ApiAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Api";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            //Usuario
            context.MapRoute(
                "AccesoUsuario",
                "Api/Usuarios/Usuario/{email}/{password}",
                new
                {
                    controller = "Usuarios",
                    action = "Usuario",
                    email = UrlParameter.Optional,
                    password = UrlParameter.Optional
                }
            );

            context.MapRoute(
                "AccesoUsuarios",
                "Api/Usuarios",
                new
                {
                    controller = "Usuarios",
                    action = "Usuarios"
                }
            );

            //Alimento
            context.MapRoute(
                "AccesoAlimento",
                "Api/Alimentos/Alimento/{codigo}",
                new
                {
                    controller = "Alimentos",
                    action = "Alimento",
                    codigo = UrlParameter.Optional
                }
            );

            context.MapRoute(
                "AccesoAlimentos",
                "Api/Alimentos",
                new
                {
                    controller = "Alimentos",
                    action = "Alimentos"
                }
            );

            context.MapRoute(
                "Api_default",
                "Api/{controller}/{action}/{id}",
                new
                {
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}
