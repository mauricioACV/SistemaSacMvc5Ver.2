﻿using SistemaSacMvcVer2.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Dominio.Interfaces.IReportesSac
{
    public interface IReportesSacServicio
    {
        List<ReportesSac> ObtenerListadoBasicoObras();
    }
}