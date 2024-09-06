using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U1_Resolucion_Problema_1._5.Datos;
using U1_Resolucion_Problema_1._5.Dominio.Clases;

namespace U1_Resolucion_Problema_1._5.Servicios
{
    internal class DetalleFacturaServicio : ServicioAbstracto<DetalleFactura>
    {
        public override bool Guardar(DetalleFactura df)
        {
            bool resultado = false;
            SqlTransaction t = null;
            SqlParameter id = new SqlParameter();
            SqlParameter articulo = new SqlParameter();
            SqlParameter cantidad = new SqlParameter();
            SqlParameter idFactura = new SqlParameter();
            id.Value = df.id;
            id.ParameterName = "@id";
            articulo.Value = df.articulo.id;
            articulo.ParameterName = "@id_articulo";
            cantidad.Value = df.cantidad;
            cantidad.ParameterName = "@cantidad";
            idFactura.Value = df.idFactura;
            idFactura.ParameterName = "@id_factura";
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(id);
            lstParam.Add(articulo);
            lstParam.Add(cantidad);
            lstParam.Add(idFactura);
            if (AccesoDatos.EjecutarSP("SP_Guardar_Detalle", lstParam) == true)
            {
                resultado=true;
            }
            return resultado;
        }
        
    }
}
