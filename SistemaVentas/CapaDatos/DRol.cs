using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Entidad;


namespace CapaDatos
{
  public  class DRol
    {
        public List<Rol> Listar() //retornamos los Roles del usuario respectivo
        {
            List<Rol> lista = new List<Rol>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.Cn))
            {
                try
                {
                    StringBuilder query = new StringBuilder();  //Nos permite hacer saltos de linea, para completar nuestra sentencia SQL
                    query.AppendLine("select IdRol, Descripcion from Rol");                    

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Rol()
                            {
                                IdRol = Convert.ToInt32(dr["IdRol"]) ,
                               Descripcion = dr["Descripcion"].ToString(),
                            });
                        }
                    }
                }

                catch (Exception ex)
                {
                    lista = new List<Rol>();

                }


            }

            return lista;
        }
    }
}
