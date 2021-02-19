using Oracle.ManagedDataAccess.Client;
using SistemaSacMvcVer2.Dominio.Entidades;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoDominio;
using System;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Infraestructura.Repositorios
{
    public class CtoDominioRepositorio : ICtoDominioRepositorio
    {
        private readonly OracleConnection conexionDb;

        public CtoDominioRepositorio(OracleConnection pDbConexion)
        {
            conexionDb = pDbConexion;
        }

        public List<CtoDominio> ObtenerItemsPorDominio(string pDominio)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<CtoDominio> ListadoDominio = new List<CtoDominio>();

            try
            {
                var query = @"select ID_ITEM, DESCRIPCION from CTO_DOMINIO where DOMINIO= :pDominio order by DESCRIPCION";
                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter("pDominio", pDominio));

                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CtoDominio CtoDominio = new CtoDominio
                        {
                            Id_Item = Convert.ToInt32(dr["ID_ITEM"] is DBNull ? "0" : dr["ID_ITEM"]),
                            Descripcion = dr["DESCRIPCION"].ToString()
                        };

                        ListadoDominio.Add(CtoDominio);
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

            return ListadoDominio;
        }

        public List<CtoDominio> ObtenerItemsPorDominioUsuario(string pDominio, string pGrupoUsuario)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<CtoDominio> ListadoTipoDominioPorUsuario = new List<CtoDominio>();

            try
            {
                var query = @"select ID_ITEM, DESCRIPCION from CTO_DOMINIO where DOMINIO= :pDominio and (USUARIO_INGRESO = '*' or USUARIO_INGRESO = :pUsuario) order by DESCRIPCION";
                
                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter("pDominio", pDominio));
                cmd.Parameters.Add(new OracleParameter("pUsuario", pGrupoUsuario));

                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    
                    while (dr.Read())
                    {
                        CtoDominio CtoDominio = new CtoDominio
                        {
                            Id_Item = Convert.ToInt32(dr["ID_ITEM"].ToString()),
                            Descripcion = dr["DESCRIPCION"].ToString()
                        };

                        ListadoTipoDominioPorUsuario.Add(CtoDominio);
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

            return ListadoTipoDominioPorUsuario;
        }
    }
}
