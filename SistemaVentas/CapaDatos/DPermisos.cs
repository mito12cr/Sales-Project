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
  public  class DPermisos
    {
        public List<Permiso> Listar(int idusuario) //retornamos los permisos del usuario respectivo
        {
            List<Permiso> lista = new List<Permiso>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.Cn))
            {
                try
                {
                    StringBuilder query = new StringBuilder();  //Nos permite hacer saltos de linea, para completar nuestra sentencia SQL
                    query.AppendLine("select p.idrol, p.NombreMenu from Permiso p");
                    query.AppendLine("inner join Rol r on p.IdRol = r.IdRol");
                    query.AppendLine("inner join Usuario u on u.IdRol = r.IdRol");
                    query.AppendLine("where u.IdRol = @idUsuario");
                   
                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@idUsuario", idusuario);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Permiso()
                            {
                                ORol = new Rol() { IdRol = Convert.ToInt32(dr["idrol"]) } , // se instancia el objeto desde la entidad "Rol" 
                                NombreMenu = dr["NombreMenu"].ToString(),                                
                            });

                        }
                    }
                }

                catch (Exception ex)
                {
                    lista = new List<Permiso>();

                }


            }

            return lista;
        }
    }
}
