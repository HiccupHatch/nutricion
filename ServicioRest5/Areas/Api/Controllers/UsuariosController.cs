using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServicioRest5.Areas.Api.Models;

namespace ServicioRest5.Areas.Api.Controllers
{
    public class UsuariosController : Controller
    {
        private UsuarioManager usuarioManager;

        public UsuariosController()
        {
            usuarioManager = new UsuarioManager();
        }

        //
        // GET: /Api/Usuarios/
        [HttpGet]
        public JsonResult Usuarios()
        {
            return Json(usuarioManager.ObtenerUsuarios(),
                        JsonRequestBehavior.AllowGet);
        }

        // POST    /Api/Usuarios/Usuario    { Nombre:"nombre", Telefono:123456789 }
        // PUT     /Api/Usuarios/Usuario/3  { Id:3, Nombre:"nombre", Telefono:123456789 }
        // GET     /Api/Usuarios/Usuario/email/password
        // DELETE  /Api/Usuarios/Usuario/3
        public JsonResult Usuario(string email, string password, Usuario item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    //return Json(usuarioManager.InsertarUsuario(item));
                case "PUT":
                    //return Json(usuarioManager.ActualizarUsuario(item));
                case "GET":
                    return Json(usuarioManager.Login(email, password),
                        JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return null;
                    //return Json(usuarioManager.EliminarUsuario(id.GetValueOrDefault()),
                        //JsonRequestBehavior.AllowGet);
            }

            return Json(new { Error = true, Message = "Operación HTTP desconocida" });
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
