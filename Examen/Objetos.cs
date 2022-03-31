using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    public class Objetos
    {
        public void insertaProducto(Producto producto)
        {
            ConexBD.insertaProducto(producto);
        }
    }
    
    public class Producto
    {
        public int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string _Nombre = "";
        public string Nombre 
        { 
            get { return _Nombre; } 
            set { _Nombre = value; } 
        }

        public int _IdProveedores = 0;
        public int IdProvedoores
        {
            get { return _IdProveedores; }
            set { _IdProveedores = value; }
        }

        public int _IdTipo = 0;
        public int IdTipo
        {
            get { return _IdTipo; }
            set { _IdTipo = value; }
        }

        public int _Cantidad = 0;
        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        public string _Modelo = "";
        public string Modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }

        public string _Marca = "";
        public string Marca
        {
            get { return _Marca; }
            set { _Marca = value; }
        }
    }
}
