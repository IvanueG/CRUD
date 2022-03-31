using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;              //Librerias Agregadas
using System.Data.SqlClient;    //Librerias Agregadas
using System.Windows.Forms;     //Librerias Agregadas

namespace Examen
{
    public class ConexBD
    {
        //GOD: https://youtu.be/CRxJxcbwUWI?t=165
        //string de coneccion
        //public static string StringConeccion = "Data Source=51.1.9.241;Initial Catalog=ExamenIvanue;User Id=SA;Password=p$2j&E%2rDQDUz;";
        public static string StringConeccion = "Data Source=localhost;Initial Catalog=Examen;User Id=SA;Password=Aaya98020415;";
        

        public static void insertaProducto(Producto producto)
        {
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = StringConeccion;
            conectar.Open();

            SqlCommand cmd = new SqlCommand("insertaProducto", conectar);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NombreProducto", producto.Nombre);
            cmd.Parameters.AddWithValue("@IdProveedores", producto.IdProvedoores);
            cmd.Parameters.AddWithValue("@IdTipo", producto.IdTipo);
            cmd.Parameters.AddWithValue("@Cantidad", producto.Cantidad);
            cmd.Parameters.AddWithValue("@Modelo", producto.Modelo);
            cmd.Parameters.AddWithValue("@Marca", producto.Marca);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.ToString());
                throw;
            }
            
        }

        public static void actualizaProducto(Producto producto)
        {

            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = StringConeccion;
            conectar.Open();

            SqlCommand cmd = new SqlCommand("Actualizar", conectar);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdProducto", producto.Id);
            cmd.Parameters.AddWithValue("@NombreProducto", producto.Nombre);
            cmd.Parameters.AddWithValue("@IdProveedores", producto.IdProvedoores);
            cmd.Parameters.AddWithValue("@IdTipo", producto.IdTipo);
            cmd.Parameters.AddWithValue("@Cantidad", producto.Cantidad);
            cmd.Parameters.AddWithValue("@Modelo", producto.Modelo);
            cmd.Parameters.AddWithValue("@Marca", producto.Marca);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.ToString());
                throw;
            }

        }
    }
}
