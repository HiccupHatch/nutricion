using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServicioRest5.Areas.Api.Models;

namespace ServicioRest5.Areas.Api.Controllers
{
    public class CaloriasController : Controller
    {
        private CaloriasManager caloriasManager;

        public CaloriasController()
        {
            caloriasManager = new CaloriasManager();
        }

        // GET /Api/Calorias
        [HttpGet]
        public JsonResult Calorias()
        {
            return Json(caloriasManager.ObtenerCalorias(),
                        JsonRequestBehavior.AllowGet);
        }

        // POST    /Api/Calorias/Caloria    { Nombre:"nombre", Telefono:123456789 }
        // PUT     /Api/Calorias/Caloria/3  { Id:3, Nombre:"nombre", Telefono:123456789 }
        // GET     /Api/Calorias/Caloria/3
        // DELETE  /Api/Calorias/Caloria/3
        public JsonResult Caloria(int? id, Calorias item)
        {
            switch (Request.HttpMethod)
            {
               case "POST":
                   return Json(caloriasManager.InsertarCalorias(item));
              //  case "PUT":
                //    return Json(caloriasManager.ActualizarCliente(item));
               //case "GET":
                 //   return Json(caloriasManager.ObtenerCaloriasUno(id.GetValueOrDefault()),
                        //JsonRequestBehavior.AllowGet);
                //case "DELETE":
                  //  return Json(clientesManager.EliminarCliente(id.GetValueOrDefault()),
                        //JsonRequestBehavior.AllowGet);
            }

            return Json(new { Error = true, Message = "Operación HTTP desconocida" });
        }


        //
        // GET: /Api/Calorias/

        public ActionResult Index()
        {
            return View();
        }

    }
}
