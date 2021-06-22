using SistemaSacMvcVer2.Aplicación.Interfaces;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaSacMvcVer2.Front.Controllers
{
    public class AccesoController : Controller
    {
        private readonly ICtoUsuarioServicio _ctoUsuarioServicio;

        public AccesoController(ICtoUsuarioServicio ctoUsuarioServicio)
        {
            _ctoUsuarioServicio = ctoUsuarioServicio;
        }

        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string User, string Pass)
        {
            try
            {
                var objUsuario = _ctoUsuarioServicio.ObtenerUsuario(User, Pass);

                if (objUsuario.Usuario == null)
                {
                    ViewBag.MensajeError = "Usuario no existe o contraseña no válida";
                    return View();
                }

                Session["UserSession"] = objUsuario;

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}