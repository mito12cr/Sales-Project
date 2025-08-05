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
   public class DCategoria
    {
        public List<Categoria> Listar()                      //IMPLEMENTAMOS LISTAR LOS CategoriaS
        {
            List<Categoria> lista = new List<Categoria>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.Cn))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdCategoria, Descripcion, Estado from Categoria");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())  //LLENAMOS EL DATAREADER Y LO MOSTRAMOS EN EL DATAGRIDVIEW
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Categoria()
                            {
                                IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                Estado      = Convert.ToBoolean(dr["Estado"])
                            });

                        }
                    }
                }

                catch (Exception ex)
                {
                    lista = new List<Categoria>();

                }


            }

            return lista;
        }

        public int Registrar(Categoria objCategoria, out string Mensaje)  //METODO PARA AGREGAR CategoriaS
        {
            int idCategoriaGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_RegistrarCategoria", oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", objCategoria.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", objCategoria.Estado);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    idCategoriaGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }


            }
            catch (Exception ex)
            {
                idCategoriaGenerado = 0;
                Mensaje = ex.Message;

            }

            return idCategoriaGenerado;

        }


        public bool Editar(Categoria objCategoria, out string Mensaje)  //METODO PARA EDITAR UN Categoria
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_EditarCategoria ", oConexion);
                    cmd.Parameters.AddWithValue("@IdCategoria ", objCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Descripcion", objCategoria.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", objCategoria.Estado);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
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


        public bool Eliminar(Categoria objCategoria, out string Mensaje)  // METODO PARA ELIMINAR UN Categoria
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_EliminarCategoria  ", oConexion);
                    cmd.Parameters.AddWithValue("@Idcategoria ", objCategoria.IdCategoria);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
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
