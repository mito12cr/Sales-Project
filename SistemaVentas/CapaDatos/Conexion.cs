using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace CapaDatos
{
   public class Conexion
    {
         public static string Cn = ConfigurationManager.ConnectionStrings ["cadena_Conexion"].ToString();
     //  public static string Cn = "Data Source=DESKTOP-8H4F1H3\\SQLEXPRESS; Initial Catalog=DbSisVentas, Integrated Security = true";

    }
}
