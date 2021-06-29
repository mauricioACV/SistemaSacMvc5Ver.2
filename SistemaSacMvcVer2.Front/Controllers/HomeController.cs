﻿using SistemaSacMvcVer2.Dominio.Entidades;
using System.Web.Mvc;

namespace SistemaSacMvcVer2.Front.Controllers
{
    public class HomeController : Controller
    {
        private CtoUsuario objUsuario;

        public ActionResult Index()
        {
            objUsuario = (CtoUsuario)Session["UserSession"];
            Session["Nombres"] = objUsuario.Nombres;
            Session["Apellidos"] = objUsuario.Apellidos;
            Session["Grupo"] = objUsuario.Grupo;
            return View();
        }
    }
}