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
  public  class DProducto
    {
        public List<Producto> Listar()                      //IMPLEMENTAMOS LISTAR LOS PRODUCTOS
        {
            List <Producto> lista = new List<Producto>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.Cn))
            {
                try {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select p.IdProducto,p.Codigo,p.Nombre,p.Descripcion,c.IdCategoria,c.Descripcion[DescripcionCategoria],p.Stock,p.PrecioCompra,p.PrecioVenta,p.Estado from Producto as p");
                    query.AppendLine("  inner join Categoria as c on c.IdCategoria = p.IdCategoria");

                    SqlCommand cmd = new SqlCommand(query.ToString(),oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())  //LLENAMOS EL DATAREADER Y LO MOSTRAMOS EN EL DATAGRIDVIEW
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Producto()
                            {
                                IdProducto     = Convert.ToInt32(dr["IdProducto"]),
                                Codigo         = dr["Codigo"].ToString(),
                                Nombre         = dr["Nombre"].ToString(),
                                Descripcion    = dr["Descripcion"].ToString(),   
                                OCategoria     = new Categoria() { IdCategoria = Convert.ToInt32(dr["IdCategoria"]), Descripcion = dr["DescripcionCategoria"].ToString() },
                                Stock          = Convert.ToInt32(dr["Stock"]),
                                PrecioCompra   = Convert.ToDecimal(dr["PrecioCompra"]),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            });

                        }
                    }
                }

                catch(Exception ex)
                {
                    lista = new List<Producto>();

                }


            }

            return lista;
        }

        public int Registrar(Producto objProducto, out string Mensaje)  //METODO PARA AGREGAR PRODUCTOS
        {
            int idProductoGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_RegistraProducto", oConexion);
                    cmd.Parameters.AddWithValue("Codigo",        objProducto.Codigo);
                    cmd.Parameters.AddWithValue("Nombre",        objProducto.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion",   objProducto.Descripcion);
                    cmd.Parameters.AddWithValue("IdCategoria",   objProducto.OCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Estado",        objProducto.Estado);      
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction    = ParameterDirection.Output;
                    cmd.Parameters.Add("ProductoResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    idProductoGenerado = Convert.ToInt32(cmd.Parameters["ProductoResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }


            }
            catch (Exception ex)
            {
                idProductoGenerado = 0;
                Mensaje = ex.Message;

            }

            return idProductoGenerado;

        }


        public bool Editar(Producto objProducto, out string Mensaje)  //METODO PARA EDITAR UN PRODUCTO
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_EditarProducto ",oConexion); 
                    cmd.Parameters.AddWithValue("IdProducto ",          objProducto .IdProducto);
                    cmd.Parameters.AddWithValue("Codigo",               objProducto.Codigo);
                    cmd.Parameters.AddWithValue("Nombre",               objProducto.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion",          objProducto.Descripcion);
                    cmd.Parameters.AddWithValue("IdCategoria",          objProducto.OCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Estado",               objProducto.Estado);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction        = ParameterDirection.Output;
                    cmd.Parameters.Add("ProductoResultado", SqlDbType.Int).Direction       = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["ProductoResultado"].Value);
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


        public bool Eliminar(Producto objProducto, out string Mensaje)  // METODO PARA ELIMINAR UN PRODUCTO
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_EliminarProducto  ", oConexion);
                    cmd.Parameters.AddWithValue("@IdProducto ", objProducto.IdProducto);                   
                    cmd.Parameters.Add("ProductoResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["ProductoResultado"].Value);
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
