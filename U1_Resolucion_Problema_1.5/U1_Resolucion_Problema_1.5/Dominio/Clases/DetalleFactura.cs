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
        public int idFactura;
        public Articulo articulo;
        public int cantidad;

        public DetalleFactura(int id,int idF,Articulo art,int cant)
        {
            this.id = id;
            idFactura = idF;
            articulo = art;
            cantidad = cant;
        }

        public override string ToString()
        {
            return "id: "+id.ToString()+"nro Factura: "+idFactura.ToString()+"articulo: "+articulo.nombre+"cantidad: "+cantidad.ToString();
        }
    }
}
