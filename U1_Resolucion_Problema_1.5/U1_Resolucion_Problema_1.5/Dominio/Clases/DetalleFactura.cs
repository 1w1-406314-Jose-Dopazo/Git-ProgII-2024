using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_Resolucion_Problema_1._5.Dominio.Clases
{
    public class DetalleFactura
    {
        public int id;
        public Articulo articulo;
        public int cantidad;

        public DetalleFactura(Articulo art,int cant)
        {
            articulo = art;
            cantidad = cant;
            id = 0;
        }
        public DetalleFactura(int id,Articulo art,int cant)
        {
            articulo = art;
            cantidad = cant;
            this.id = id;
        }

        public override string ToString()
        {
            return "\nID_Detalle: " +id.ToString()+ "\nArticulo: "+articulo.nombre.ToString()+ "\nCantidad: "+cantidad.ToString();
        }
    }
}
