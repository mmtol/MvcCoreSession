using Microsoft.AspNetCore.Mvc;
using MvcCoreSession.Extensions;
using MvcCoreSession.Helpers;
using MvcCoreSession.Models;

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

        public IActionResult SessionMascotaBytes(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    //guardamos datos en session
                    Mascota mascota = new Mascota();
                    mascota.Nombre = "Goofy";
                    mascota.Raza = "Perro";
                    mascota.Edad = 10;

                    byte[] data = HelperBinarySession.ObjetcToByte(mascota);
                    //almacenamos el obj en session
                    HttpContext.Session.Set("Mascota", data);
                    ViewData["Mensaje"] = "Mascota almacenada en Session";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    //recuperamos los datos de session
                    byte[] data = HttpContext.Session.Get("Mascota");
                    Mascota mascota = (Mascota)HelperBinarySession.ByteToObject(data);
                    //para representarlo de forma visuañ, lo enviamos a viewdata
                    ViewData["Mascota"] = mascota;
                }
            }
            return View();
        }

        public IActionResult SessionMascotaColectionBytes(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    //guardamos datos en session
                    Mascota mascota1 = new Mascota
                    {
                        Nombre = "Goofy",
                        Raza = "Perro",
                        Edad = 10
                    };
                    Mascota mascota2 = new Mascota
                    {
                        Nombre = "Pluto",
                        Raza = "Perro",
                        Edad = 9
                    };
                    Mascota mascota3 = new Mascota
                    {
                        Nombre = "Groot",
                        Raza = "Perro",
                        Edad = 7
                    };

                    List<Mascota> mascotas = new List<Mascota>
                    {
                        mascota1, mascota2, mascota3
                    };

                    byte[] data = HelperBinarySession.ObjetcToByte(mascotas);
                    HttpContext.Session.Set("Mascotas", data);
                    ViewData["Mensaje"] = "Coleccion almacenada correctamente";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    //recuperamos los datos de session
                    byte[] data = HttpContext.Session.Get("Mascotas");
                    List<Mascota> mascotas = (List<Mascota>)HelperBinarySession.ByteToObject(data);
                    return View(mascotas);
                }
            }

            return View();
        }

        public IActionResult SessionMascotaJson(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    //guardamos datos en session
                    Mascota mascota = new Mascota();
                    mascota.Nombre = "Pluto";
                    mascota.Raza = "Perro";
                    mascota.Edad = 9;

                    //queremos guardar el obj mascota como string en session
                    string json = HelperJsonSession.SerializarObject<Mascota>(mascota);
                    HttpContext.Session.SetString("json", json);

                    ViewData["Mensaje"] = "Mascota almacenada en Session";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    string json = HttpContext.Session.GetString("json");
                    Mascota mascota = HelperJsonSession.DeserializeObject<Mascota>(json);
                    ViewData["MascotaJson"] = mascota;
                }
            }
            return View();
        }

        public IActionResult SessionMascotaGeneric(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    //guardamos datos en session
                    Mascota mascota = new Mascota();
                    mascota.Nombre = "Groot";
                    mascota.Raza = "Perro";
                    mascota.Edad = 7;

                    HttpContext.Session.SetObject("MascotaGeneric", mascota);

                    ViewData["Mensaje"] = "Mascota almacenada en Session";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    Mascota mascota = HttpContext.Session.GetObject<Mascota>("MascotaGeneric");
                    ViewData["MascotaGeneric"] = mascota;
                }
            }
            return View();
        }

        public IActionResult SessionMascotaColectionGeneric(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    //guardamos datos en session
                    Mascota mascota1 = new Mascota
                    {
                        Nombre = "Goofy Generic",
                        Raza = "Perro",
                        Edad = 10
                    };
                    Mascota mascota2 = new Mascota
                    {
                        Nombre = "Pluto Generic",
                        Raza = "Perro",
                        Edad = 9
                    };
                    Mascota mascota3 = new Mascota
                    {
                        Nombre = "Groot Generic",
                        Raza = "Perro",
                        Edad = 7
                    };

                    List<Mascota> mascotas = new List<Mascota>
                    {
                        mascota1, mascota2, mascota3
                    };

                    HttpContext.Session.SetObject("MascotasGeneric", mascotas);
                }
                else if (accion.ToLower() == "mostrar")
                {
                    //recuperamos los datos de session
                    List<Mascota> mascotas = HttpContext.Session.GetObject<List<Mascota>>("MascotasGeneric");
                    return View(mascotas);
                }
            }

            return View();
        }
    }
}
