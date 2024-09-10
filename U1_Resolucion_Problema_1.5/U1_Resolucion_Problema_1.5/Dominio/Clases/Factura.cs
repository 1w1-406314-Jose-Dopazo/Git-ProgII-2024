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
        public string nomCliente;
        public List<DetalleFactura> lstDetalles;
        public TipoPago fp;

        public Factura(int id,string fecha,TipoPago fp,string nomCliente,List<DetalleFactura> lstDetalles)
        {
            this.id = id;
            this.fecha = Convert.ToDateTime(fecha);
            this.nomCliente = nomCliente;
            this.lstDetalles = lstDetalles;
            this.fp = fp;
        }
        public Factura(string fecha, TipoPago fp, string nomCliente, List<DetalleFactura> lstDetalles)
        {
            id = 0;
            this.fecha = Convert.ToDateTime(fecha);
            this.nomCliente = nomCliente;
            this.lstDetalles = lstDetalles;
            this.fp = fp;
        }
        public Factura() 
        {
            id = 0;
            fecha = DateTime.Now;
            nomCliente = string.Empty;
            lstDetalles = new List<DetalleFactura>();
            fp = new TipoPago();
        }

        public override string ToString()
        {
            return "\nID_Factura: " + id.ToString() + "\nFecha: " + fecha.ToString() + "\nNombre Cliente: " + nomCliente + "\nForma de Pago: " + fp.nombre.ToString();
        }
    }
}
