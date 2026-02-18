using Microsoft.AspNetCore.Mvc;

namespace MvcCoreSession.Controllers
{
    public class EjemploSessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SessionSimple(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    //guardamos datos en session
                    HttpContext.Session.SetString("nombre", "Dev");
                    HttpContext.Session.SetString("hora", DateTime.Now.ToLongTimeString());
                    ViewData["Mensaje"] = "Datos almacenados en Session";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    //recuperamos los datos de session
                    ViewData["Nombre"] = HttpContext.Session.GetString("nombre");
                    ViewData["Hora"] = HttpContext.Session.GetString("hora");
                }
            }
            return View();
        }
    }
}
