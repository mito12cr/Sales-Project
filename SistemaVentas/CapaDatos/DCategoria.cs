using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    class DCategoria
    {
        private int _Idcategoria;
        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }
      

        private string _Nombre;
        public string Nombre { get => _Nombre; set => _Nombre = value; }
       
        
        private string _Descripcion;
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }


        private string _BuscaTexto;
        public string BuscaTexto { get => _BuscaTexto; set => _BuscaTexto = value; }

        public DCategoria()
        {

        }

        public DCategoria(int idCategoria, string nombre, string descripcion, string buscatexto)
        {
            this.Idcategoria = idCategoria;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.BuscaTexto = buscatexto;

        }

        // Insertar Categoria
        public string Insertar(DCategoria Categoria)
        {
            string rpta = "";
            SqlConnection Sqlconexion = new SqlConnection();

            try
            {
                Sqlconexion.ConnectionString = Conexion.Cn;
                Sqlconexion.Open();

                SqlCommand sqlcomando = new SqlCommand();
                sqlcomando.Connection = Sqlconexion;
                sqlcomando.CommandText = "SpInsertar_Categoria";
                sqlcomando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idCategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Direction = ParameterDirection.Output;




            }
            catch (Exception ex)

            {
                rpta = ex.Message;
            }
            finally
            {
                if (Sqlconexion.State == ConnectionState.Open)
                    Sqlconexion.Close();
            }
            return rpta;
        }


        //public string Editar(DCategoria Categoria)
        //{

        //}

        //public string Eliminar(DCategoria Categoria)
        //{

        //}

        //public DataTable Buscar()
        //{

        //}

        //public DataTable BuscarNombre(DCategoria Categoria)
        //{

        //}

    }
}
