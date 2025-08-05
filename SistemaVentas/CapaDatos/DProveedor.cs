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
   public class DProveedor
    {
        public List<Proveedor> Listar()                      //IMPLEMENTAMOS LISTAR LOS ProveedoreS
        {
            List<Proveedor> lista = new List<Proveedor>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.Cn))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdProveedor,TipoDocumento,Correo,Telefono,Estado from Proveedor");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())  //LLENAMOS EL DATAREADER Y LO MOSTRAMOS EN EL DATAGRIDVIEW
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Proveedor()
                            {
                                IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                                TipoDocumento = dr["TipoDocumento"].ToString(),                                
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])

                            });

                        }
                    }
                }

                catch (Exception ex)
                {
                    lista = new List<Proveedor>();

                }


            }

            return lista;
        }

        public int Registrar(Proveedor objProveedor, out string Mensaje)  //METODO PARA AGREGAR Proveedores
        {
            int IdProveedorGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_RegistraProveedor", oConexion);
                    cmd.Parameters.AddWithValue("TipoDocumento", objProveedor.TipoDocumento);
                    cmd.Parameters.AddWithValue("Correo", objProveedor.Correo);
                    cmd.Parameters.AddWithValue("Telefono", objProveedor.Telefono);
                    cmd.Parameters.AddWithValue("Estado", objProveedor.Estado);
                    cmd.Parameters.Add("ResultadoProveedor", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    IdProveedorGenerado = Convert.ToInt32(cmd.Parameters["ResultadoProveedor"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }


            }
            catch (Exception ex)
            {
                IdProveedorGenerado = 0;
                Mensaje = ex.Message;

            }

            return IdProveedorGenerado;

        }


        public bool Editar(Proveedor objProveedor, out string Mensaje)  //METODO PARA EDITAR UN Proveedor
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_EditarProveedor ", oConexion);
                    cmd.Parameters.AddWithValue("@IdProveedor ", objProveedor.IdProveedor);
                    cmd.Parameters.AddWithValue("TipoDocumento", objProveedor.TipoDocumento);
                    cmd.Parameters.AddWithValue("Correo", objProveedor.Correo);
                    cmd.Parameters.AddWithValue("Telefono", objProveedor.Telefono);
                    cmd.Parameters.AddWithValue("Estado", objProveedor.Estado);
                    cmd.Parameters.Add("ResultadoProveedor", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["ResultadoProveedor"].Value);
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


        public bool Eliminar(Proveedor objProveedor, out string Mensaje)  // METODO PARA ELIMINAR UN Proveedor
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_EliminarProveedor  ", oConexion);
                    cmd.Parameters.AddWithValue("@IdProveedor ", objProveedor.IdProveedor);
                    cmd.Parameters.Add("ResultadoProveedor", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["ResultadoProveedor"].Value);
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
