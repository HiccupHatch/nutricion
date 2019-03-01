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
        private UsuariosManager usuariosManager;

        public UsuariosController()
        {
            usuariosManager = new UsuariosManager();
        }

        //
        // GET: /Api/Usuarios/
        [HttpGet]
        public JsonResult Usuarios()
        {
            return Json(usuariosManager.ObtenerUsuarios(),
                        JsonRequestBehavior.AllowGet);
        }

        // POST    /Api/Usuarios/Usuario    { Nombre:"nombre", Telefono:123456789 }
        // PUT     /Api/Clientes/Cliente/3  { Id:3, Nombre:"nombre", Telefono:123456789 }
        // GET     /Api/Clientes/Cliente/3
        // DELETE  /Api/Clientes/Cliente/3
        public JsonResult Usuario(string email, string password, Usuario item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    //return Json(usuariosManager.InsertarUsuario(item));
                case "PUT":
                    //return Json(usuariosManager.ActualizarUsuario(item));
                case "GET":
                    return Json(usuariosManager.Login(email, password),
                        JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return null;
                    //return Json(usuariosManager.EliminarUsuario(id.GetValueOrDefault()),
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
