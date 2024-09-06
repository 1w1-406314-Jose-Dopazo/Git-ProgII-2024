using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_Resolucion_Problema_1._5.Dominio.Clases
{
    public class Factura
    {
        public int id;
        public DateTime fecha;
        public FormaPago fp;
        public string nomCliente;
        public List<DetalleFactura> lstDetalles;

        public Factura(int id,string fecha,FormaPago fp,string nomCliente,List<DetalleFactura> lstDetalles)
        {
            this.id = id;
            this.fecha = Convert.ToDateTime(fecha);
            this.fp = fp;
            this.nomCliente = nomCliente;
            this.lstDetalles = lstDetalles;
        }
        public Factura() 
        {
            id = 0;
            fecha = DateTime.Now;
            fp = new FormaPago();
            nomCliente = string.Empty;
            lstDetalles = new List<DetalleFactura>();
        }

        public override string ToString()
        {
            return "id: "+id.ToString()+"fecha: "+fecha.ToString()+"forma pago: "+fp.nombre+"nombre cliente: "+nomCliente+"nro detalles: "+lstDetalles.Count().ToString();
        }
    }
}
