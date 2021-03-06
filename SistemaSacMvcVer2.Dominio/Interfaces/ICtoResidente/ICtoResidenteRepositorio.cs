﻿using SistemaSacMvcVer2.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Dominio.Interfaces.ICtoResidente
{
    public interface ICtoResidenteRepositorio
    {
        List<CtoResidente> ObtenerListadoResidente();
        List<CtoResidente> BuscarResidentePorPalabraClave(string pPalabraClave);
    }
}
