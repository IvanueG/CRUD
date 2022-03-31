using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;              //Librerias Agregadas
using System.Data.SqlClient;    //Librerias Agregadas
using System.Windows.Forms;     //Librerias Agregadas

namespace Examen
{
    public partial class Form1 : Form
    {
        public Producto producto = new Producto();
        public Form1()
        {
            InitializeComponent();
        }
        
        public void btnAlta_Click(object sender, EventArgs e)
        {
            producto.Nombre = txtNombreProducto.Text;
            producto.IdProvedoores = Convert.ToInt32(cmbIdProveedores.SelectedValue.ToString());
            producto.IdTipo = Convert.ToInt32(cmbIdTipo.SelectedValue.ToString());
            producto.Cantidad = Convert.ToInt32(txtCantidad.Text);
            producto.Modelo = txtModelo.Text;
            producto.Marca = txtMarca.Text;

            ConexBD.insertaProducto(producto);
            mostrar("Productos", dataGridView1);
        }
        public void mostrar(String tabla, DataGridView grid)
        {
            string StringConeccion = "Data Source=localhost;Initial Catalog=Examen;User Id=SA;Password=Aaya98020415;";

            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = StringConeccion;
            conectar.Open();
            string query = "SELECT *FROM " + tabla;
            SqlCommand cmd = new SqlCommand(query, conectar);
            //try
            //{
                cmd.ExecuteNonQuery();
                adapter.SelectCommand = cmd;
                adapter.Fill(contenedor);
                grid.DataSource = contenedor;
            //}
            //catch (SqlException ex)
            //{
            //    Console.WriteLine("Error " + ex.ToString());
            //    throw;
            //}
            conectar.Close();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            mostrarReporte(dataGridView1);
        }

        public void mostrarReporte(DataGridView grid)
        {
            string StringConeccion = "Data Source=localhost;Initial Catalog=Examen;User Id=SA;Password=Aaya98020415;";

            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = StringConeccion;
            conectar.Open();
            string query = "Exec Reporte ";
            SqlCommand cmd = new SqlCommand(query, conectar);
            //try
            //{
            cmd.ExecuteNonQuery();
            adapter.SelectCommand = cmd;
            adapter.Fill(contenedor);
            grid.DataSource = contenedor;
            //}
            //catch (SqlException ex)
            //{
            //    Console.WriteLine("Error " + ex.ToString());
            //    throw;
            //}
            conectar.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            producto.Id = Convert.ToInt32(txtId.Text);
            producto.Nombre = txtNombreProducto.Text;
            producto.IdProvedoores = Convert.ToInt32(cmbIdProveedores.SelectedValue.ToString());
            producto.IdTipo = Convert.ToInt32(cmbIdTipo.SelectedValue.ToString());
            producto.Cantidad = Convert.ToInt32(txtCantidad.Text);
            producto.Modelo = txtModelo.Text;
            producto.Marca = txtMarca.Text;

            ConexBD.actualizaProducto(producto);
            mostrar("Productos", dataGridView1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargaCatalogos();
        }
        public void cargaCatalogos()
        {

            string StringConeccion = "Data Source=localhost;Initial Catalog=Examen;User Id=SA;Password=Aaya98020415;";

            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlDataAdapter adapter2 = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            DataTable contenedor2 = new DataTable();
            conectar.ConnectionString = StringConeccion;
            conectar.Open();
            string query = "SELECT *FROM Cat_Proveedores";
            string query2 = "SELECT *FROM Cat_TipoProducto";
            SqlCommand cmd = new SqlCommand(query, conectar);
            SqlCommand cmd2 = new SqlCommand(query2, conectar);
            //try
            //{
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            adapter.SelectCommand = cmd;
            adapter2.SelectCommand = cmd2;
            adapter.Fill(contenedor);
            adapter2.Fill(contenedor2);
            cmbIdProveedores.DataSource = contenedor;
            cmbIdProveedores.ValueMember = "Id_Proveedores";
            cmbIdProveedores.DisplayMember = "NombreProveedor";
            cmbIdTipo.DataSource = contenedor2;
            cmbIdTipo.ValueMember = "Id_Producto";
            cmbIdTipo.DisplayMember = "NombreTipoProducto";
            //}
            //catch (SqlException ex)
            //{
            //    Console.WriteLine("Error " + ex.ToString());
            //    throw;
            //}
            conectar.Close();
        }
        private void lblId_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string StringConeccion = "Data Source=localhost;Initial Catalog=Examen;User Id=SA;Password=Aaya98020415;";

            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = StringConeccion;
            conectar.Open();
            string query = "SELECT *FROM Productos where IdProductos = " + txtId.Text;
            SqlCommand cmd = new SqlCommand(query, conectar);
            //try
            //{
            cmd.ExecuteNonQuery();
            adapter.SelectCommand = cmd;
            adapter.Fill(contenedor);
            DataTable dt = new DataTable();
            dt = contenedor;
            //}
            //catch (SqlException ex)
            //{
            //    Console.WriteLine("Error " + ex.ToString());
            //    throw;
            //}
            conectar.Close();

            txtNombreProducto.Text = dt.Rows[0]["NombreProducto"].ToString();
            cmbIdProveedores.SelectedValue = dt.Rows[0]["IdProveedores"].ToString();
            cmbIdTipo.SelectedValue = dt.Rows[0]["IdTipo"].ToString();
            txtCantidad.Text = dt.Rows[0]["Cantidad"].ToString();
            txtModelo.Text = dt.Rows[0]["Modelo"].ToString();
            txtMarca.Text = dt.Rows[0]["Marca"].ToString();
        }
    }
}
