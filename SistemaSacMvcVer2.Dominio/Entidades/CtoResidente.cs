﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSacMvcVer2.Dominio.Entidades
{
    public class CtoResidente
    {
        public int Rut { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int TotalObrasEnEjecucion { get; set; }
    }
}
