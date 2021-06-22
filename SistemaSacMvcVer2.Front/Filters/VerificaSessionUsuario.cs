using SistemaSacMvcVer2.Dominio.Entidades;
using SistemaSacMvcVer2.Front.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaSacMvcVer2.Front.Filters
{
    public class VerificaSessionUsuario : ActionFilterAttribute
    {
        private CtoUsuario objUsuario;

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            try
            {
                base.OnActionExecuted(filterContext);

                objUsuario = (CtoUsuario)HttpContext.Current.Session["UserSession"];

                if (objUsuario == null)
                {
                    if (filterContext.Controller is AccesoController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Acceso/Login");
                    }
                }

            }
            catch (Exception)
            {
                filterContext.HttpContext.Response.Redirect("/Acceso/Login");
            }
        }
    }
}