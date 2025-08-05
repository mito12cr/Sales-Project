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
    public class DCliente
    {

        public List<Cliente> Listar()                      //IMPLEMENTAMOS LISTAR LOS CLIENTES
        {
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.Cn))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdCliente, TipoDocumento,Nombre,Apellido,Correo,Telefono,Estado from Cliente");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())  //LLENAMOS EL DATAREADER Y LO MOSTRAMOS EN EL DATAGRIDVIEW
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente()
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])
                                
                            });

                        }
                    }
                }

                catch (Exception ex)
                {
                    lista = new List< Cliente>();

                }


            }

            return lista;
        }

        public int Registrar(Cliente objcliente, out string Mensaje)  //METODO PARA AGREGAR USUARIOS
        {
            int IdClienteGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_RegistraCliente", oConexion);
                    cmd.Parameters.AddWithValue("TipoDocumento", objcliente.TipoDocumento);
                    cmd.Parameters.AddWithValue("Nombre", objcliente.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", objcliente.Apellido);
                    cmd.Parameters.AddWithValue("Correo", objcliente.Correo);
                    cmd.Parameters.AddWithValue("Telefono", objcliente.Telefono);
                    cmd.Parameters.AddWithValue("Estado", objcliente.Estado);
                    cmd.Parameters.Add("ClienteResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    IdClienteGenerado = Convert.ToInt32(cmd.Parameters["ClienteResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }


            }
            catch (Exception ex)
            {
                IdClienteGenerado = 0;
                Mensaje = ex.Message;

            }

            return IdClienteGenerado;

        }


        public bool Editar(Cliente objcliente, out string Mensaje)  //METODO PARA EDITAR UN CLIENTE
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_EditarCliente ", oConexion);
                    cmd.Parameters.AddWithValue("@IdCliente ", objcliente.IdCliente);
                    cmd.Parameters.AddWithValue("TipoDocumento", objcliente.TipoDocumento);
                    cmd.Parameters.AddWithValue("Nombre", objcliente.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", objcliente.Apellido);
                    cmd.Parameters.AddWithValue("Correo", objcliente.Correo);
                    cmd.Parameters.AddWithValue("Telefono", objcliente.Telefono);
                    cmd.Parameters.AddWithValue("Estado", objcliente.Estado);
                    cmd.Parameters.Add("ClienteResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["ClienteResultado"].Value);
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


        public bool Eliminar(Cliente objcliente, out string Mensaje)  // METODO PARA ELIMINAR UN CLIENTE
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_EliminarCliente  ", oConexion);
                    cmd.Parameters.AddWithValue("@IdCliente ", objcliente.IdCliente);
                    cmd.Parameters.Add("RespuestaCliente", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["RespuestaCliente"].Value);
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
