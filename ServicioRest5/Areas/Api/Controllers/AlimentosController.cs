using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServicioRest5.Areas.Api.Models;

namespace ServicioRest5.Areas.Api.Controllers
{
    public class AlimentosController : Controller
    {
        private AlimentoManager alimentosManager;

        public AlimentosController()
        {
            alimentosManager = new AlimentoManager();
        }

        //GET /Api/Alimentos
        [HttpGet]
        public JsonResult Alimentos()
        {
            return Json(alimentosManager.ObtenerAlimentos(),
                        JsonRequestBehavior.AllowGet);
        }

        // POST    /Api/Clientes/Cliente    { Nombre:"nombre", Telefono:123456789 }
        // PUT     /Api/Clientes/Cliente/3  { Id:3, Nombre:"nombre", Telefono:123456789 }
        // GET     /Api/Clientes/Cliente/3
        // DELETE  /Api/Clientes/Cliente/3
        public JsonResult Alimento(int? id, Cliente item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    //return Json(alimentosManager.InsertarCliente(item));
                case "PUT":
                    //return Json(alimentosManager.ActualizarCliente(item));
                case "GET":
                    return Json(alimentosManager.ObtenerAlimento(id.GetValueOrDefault()),
                        JsonRequestBehavior.AllowGet);
                case "DELETE":
                    //return Json(alimentosManager.EliminarCliente(id.GetValueOrDefault()),
                    //    JsonRequestBehavior.AllowGet);
                    return null;
            }

            return Json(new { Error = true, Message = "Operación HTTP desconocida" });
        }


        //
        // GET: /Api/Alimentos/

        public ActionResult Index()
        {
            return View();
        }

    }
}
