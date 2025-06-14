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
   public class DUsuario
    {
        public List<Usuario> Listar()                      //IMPLEMENTAMOS LISTAR LOS USUARIOS
        {
            List < Usuario > lista = new List<Usuario>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.Cn))
            {
                try {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select u.IdUsuario, u.TipoDocumento, u.Nombre, u.Apellido, u.Correo, u.Telefono, u.Estado, u.Username, u.Contraseña, r.IdRol,r.Descripcion from dbo.Usuario as u");
                    query.AppendLine("inner join dbo.Rol as r on r.IdRol = u.IdRol");

                    SqlCommand cmd = new SqlCommand(query.ToString(),oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())  //LLENAMOS EL DATAREADER Y LO MOSTRAMOS EN EL DATAGRIDVIEW
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                IdUsuario     = Convert.ToInt32(dr["IdUsuario"]),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                Nombre        = dr["Nombre"].ToString(),
                                Apellido      = dr["Apellido"].ToString(),
                                Correo        = dr["Correo"].ToString(),
                                Telefono      = dr["Telefono"].ToString(),
                                Estado        = Convert.ToBoolean(dr["Estado"]),
                                Username      = dr["Username"].ToString(),                    
                                Contraseña    = dr["Contraseña"].ToString(),
                                ORol          = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]), Descripcion = dr["Descripcion"].ToString() } ,

                            });

                        }
                    }
                }

                catch(Exception ex)
                {
                    lista = new List<Usuario>();

                }


            }

            return lista;
        }

        public int Registrar(Usuario objusuario, out string Mensaje)  //METODO PARA AGREGAR USUARIOS
        {
            int idUsuarioGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_RegistraUsuario", oConexion);
                    cmd.Parameters.AddWithValue("TipoDocumento", objusuario.TipoDocumento);
                    cmd.Parameters.AddWithValue("Nombre",        objusuario.Nombre);
                    cmd.Parameters.AddWithValue("Apellido",      objusuario.Apellido);
                    cmd.Parameters.AddWithValue("Correo",        objusuario.Correo);
                    cmd.Parameters.AddWithValue("Telefono",      objusuario.Telefono);
                    cmd.Parameters.AddWithValue("Estado",        objusuario.Estado);
                    cmd.Parameters.AddWithValue("UserName",      objusuario.Username);
                    cmd.Parameters.AddWithValue("Contraseña",    objusuario.Contraseña);
                    cmd.Parameters.AddWithValue("IdRol",         objusuario.ORol.IdRol);
                    cmd.Parameters.Add("IdUsuarioResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction    = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    idUsuarioGenerado = Convert.ToInt32(cmd.Parameters["IdUsuarioResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }


            }
            catch (Exception ex)
            {
                idUsuarioGenerado = 0;
                Mensaje = ex.Message;

            }

            return idUsuarioGenerado;

        }


        public bool Editar(Usuario objusuario, out string Mensaje)  //METODO PARA EDITAR UN USUARIO
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_EditarUsuario ",oConexion); 
                    cmd.Parameters.AddWithValue("@IdUsuario ",          objusuario .IdUsuario);
                    cmd.Parameters.AddWithValue("TipoDocumento",        objusuario.TipoDocumento);
                    cmd.Parameters.AddWithValue("Nombre",               objusuario.Nombre);
                    cmd.Parameters.AddWithValue("Apellido",             objusuario.Apellido);
                    cmd.Parameters.AddWithValue("Correo",               objusuario.Correo);
                    cmd.Parameters.AddWithValue("Telefono",             objusuario.Telefono);
                    cmd.Parameters.AddWithValue("Estado",               objusuario.Estado);
                    cmd.Parameters.AddWithValue("UserName",             objusuario.Username);
                    cmd.Parameters.AddWithValue("Contraseña",           objusuario.Contraseña);
                    cmd.Parameters.AddWithValue("IdRol",                objusuario.ORol.IdRol);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction       = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje   = cmd.Parameters["Mensaje"].Value.ToString();

                }


            }
            catch (Exception ex)
            {
                Respuesta = false;
                Mensaje = ex.Message;

            }

            return Respuesta;

        }


        public bool Eliminar(Usuario objusuario, out string Mensaje)  // METODO PARA ELIMINAR UN USUARIO
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_EliminarUsuario  ", oConexion);
                    cmd.Parameters.AddWithValue("@IdUsuario ", objusuario.IdUsuario);                   
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }


            }
            catch (Exception ex)
            {
                Respuesta = false;
                Mensaje = ex.Message;

            }

            return Respuesta;

        }

    }
}
