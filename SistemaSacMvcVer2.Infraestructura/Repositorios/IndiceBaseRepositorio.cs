using Oracle.ManagedDataAccess.Client;
using SistemaSacMvcVer2.Dominio.Entidades;
using SistemaSacMvcVer2.Dominio.Interfaces.IIndiceBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSacMvcVer2.Infraestructura.Repositorios
{
    public class IndiceBaseRepositorio : IIndiceBaseRepositorio
    {
        private readonly OracleConnection conexionDb;

        public IndiceBaseRepositorio(OracleConnection pDbConexion)
        {
            conexionDb = pDbConexion;
        }

        public List<IndiceBase> ListarItemsIndiceBase()
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<IndiceBase> ItemsIndiceBase = new List<IndiceBase>();

            try
            {
                var query = @"select CTO_indicebase.id_indicebase as id_indicebase,CTO_indicebase.agno as agno,CTO_polinomico.valor as valor from CTO_indicebase,CTO_polinomico where CTO_polinomico.agno=CTO_indicebase.agno and CTO_polinomico.mes=CTO_indicebase.mes and CTO_polinomico.item=1 and CTO_indicebase.agno>2018 order by CTO_indicebase.AGNO desc,CTO_indicebase.mes desc";
                cmd = new OracleCommand(query, conexionDb);

                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        IndiceBase objIndiceBase = new IndiceBase
                        {
                            IdIndiceBase = dr["id_indicebase"].ToString(),
                            Agno = dr["agno"].ToString(),
                            Valor = dr["valor"].ToString()
                        };

                        ItemsIndiceBase.Add(objIndiceBase);
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

            return ItemsIndiceBase;
        }
    }
}
