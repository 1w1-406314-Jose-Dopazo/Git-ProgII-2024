using System;
using System.Collections.Generic;
using System.Data;
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
        ArticuloServicio artS = new ArticuloServicio();
        public bool Guardar(DetalleFactura df,int idFactura)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            SqlParameter idf = new SqlParameter() { ParameterName= "@ID_Factura",Value = idFactura };
            SqlParameter art = new SqlParameter() {ParameterName="@ID_Articulo",Value =df.articulo.id};
            SqlParameter cant = new SqlParameter() { ParameterName = "@Cantidad", Value = df.cantidad };
            lstParam.Add(idf);
            lstParam.Add(art);
            lstParam.Add(cant);
            return AccesoDatos.ObtenerInstancia().Guardar("SP_Guardar_Detalle", lstParam);
        }

        public override bool Guardar(DetalleFactura c)
        {
            throw new NotImplementedException();
        }
        public bool Eliminar(int id)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            SqlParameter param = new SqlParameter() { ParameterName = "@ID", Value = id };
            lstParam.Add(param);
            return AccesoDatos.EjecutarSP("SP_Eliminar_Detalle", lstParam);
        }

        public List<DetalleFactura> ObtenerDetallesPorFactura(Factura f)
        {
            List<DetalleFactura> lista = new List<DetalleFactura>();
            DataTable dt = AccesoDatos.ConsultarUnoSP("SP_Obtener_Detalles_Por_Factura", f.id);
            foreach (DataRow dr in dt.Rows)
            {
              Articulo a =  artS.ObtenerArticuloPorID(Convert.ToInt32(dr["ID_Articulo"].ToString()));
                DetalleFactura detalle = new DetalleFactura(Convert.ToInt32(dr["ID_Detalle_Factura"].ToString()), a, Convert.ToInt32(dr["Cantidad"].ToString()));
                lista.Add(detalle);
            }
            return lista;
        }
        
    }
}
