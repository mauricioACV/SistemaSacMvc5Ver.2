using SistemaSacMvcVer2.Dominio.Entidades;
using SistemaSacMvcVer2.Infraestructura.Servicios.WebServices.Interfaces;
using System;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Infraestructura.Servicios.WebServices.Repositorios
{
    public class SafiWebServiceRepositorio : ISafiWebServiceRepositorio
    {
        public List<CtoContrato> ObtenerInfoContratoPorCodigoSafi(int pCodigoSafi)
        {
            List<CtoContrato> InfoContratoSafi = new List<CtoContrato>();

            using (WS_SAFI.ServicioInformacionFichaContratosSAFISoapClient wsSafi = new WS_SAFI.ServicioInformacionFichaContratosSAFISoapClient())
            {
                try
                {
                    var ListadoSafi = wsSafi.InfoContratosSAFI(pCodigoSafi);

                        CtoContrato objCtoContrato = new CtoContrato
                        {
                            CodigoCarpeta = ListadoSafi[0].CODIGOCONTRATO,
                            AperturaTecnica = ListadoSafi[0].FECHAAPERTURATECNICA,
                            AperturaEconomica = ListadoSafi[0].FECHAAPERTURAECONOMICA,
                            PresupuestoOficial = ListadoSafi[0].PRESUPUESTOOFICIAL,
                            PresupuestoInicial = ListadoSafi[0].MONTOINICIAL,
                            NombreContrato = ListadoSafi[0].NOMBRECONTRATO
                        };

                        InfoContratoSafi.Add(objCtoContrato);
                }
                catch (Exception)
                {
                    //throw ex;
                }
                finally
                {
                    wsSafi.Close();
                }
            }       

            return InfoContratoSafi;
        }
    }
}
