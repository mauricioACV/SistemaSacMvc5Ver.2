using Oracle.ManagedDataAccess.Client;
using SistemaSacMvcVer2.Dominio.Entidades;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoGrupoClase;
using System;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Infraestructura.Repositorios
{
    public class CtoGrupoClaseRepositorio : ICtoGrupoClaseRepositorio
    {
        private readonly OracleConnection conexionDb;

        public CtoGrupoClaseRepositorio(OracleConnection pDbConexion)
        {
            conexionDb = pDbConexion;
        }

        public List<CtoGrupoClase> ListarAdministracionPorClaseUsuario(string pGrupoUsuario)
        {
            var pClase = pGrupoUsuario;
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<CtoGrupoClase> ListadoClase = new List<CtoGrupoClase>();

            try
            {
                var query = @"select CLASE from CTO_GRUPO_CLASE where GRUPO= :pClase and CLASE <> '*' order by CLASE, N_GRUPO";
                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter("pClase", pClase));

                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CtoGrupoClase GrupoClase = new CtoGrupoClase
                        {
                            Clase = dr["CLASE"].ToString()
                        };

                        ListadoClase.Add(GrupoClase);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexionDb.Close();
            }

            return ListadoClase;
        }

        public List<CtoGrupoClase> ListarGrupoClase()
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<CtoGrupoClase> ListadoGrupos = new List<CtoGrupoClase>();

            try
            {
                var query = @"select GRUPO,LINEA_2 from CTO_GRUPO_CLASE where CLASE = '*' ORDER BY CONTADOR";
                cmd = new OracleCommand(query, conexionDb);

                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CtoGrupoClase ctoGrupoClase = new CtoGrupoClase
                        {
                            Grupo = dr["GRUPO"].ToString(),
                            Linea2 = dr["LINEA_2"].ToString()
                        };

                        ListadoGrupos.Add(ctoGrupoClase);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexionDb.Close();
            }

            return ListadoGrupos;
        }
    }
}
