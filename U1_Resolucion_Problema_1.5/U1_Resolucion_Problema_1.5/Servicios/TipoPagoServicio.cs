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
    internal class TipoPagoServicio : ServicioAbstracto<TipoPago>
    {
        public override bool Guardar(TipoPago fp)
        {
            SqlParameter id = new SqlParameter();
            SqlParameter nombre = new SqlParameter();
            id.Value = fp.id;
            id.ParameterName = "@id";
            nombre.Value = fp.nombre;
            nombre.ParameterName = "@nombre";
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(id);
            lstParam.Add(nombre);
            return AccesoDatos.EjecutarSP("SP_Guardar_Forma_Pago",lstParam);
        }
        public TipoPago ObtenerTipoPagoPorID(int id)
        {
            DataTable dt = AccesoDatos.ConsultarUnoSP("SP_Obtener_Tipo_Pago", id);
            DataRow dr = dt.Rows[0];
            TipoPago fp = new TipoPago();
            fp.nombre = dr["Nombre"].ToString();
            fp.id = id;
            return fp;
            
        }
        public List<TipoPago> ObtenerTiposPagos()
        {
            DataTable dt = AccesoDatos.ConsultarSP("SP_Obtener_Tipos_Pagos");
            List<TipoPago> lstTiposPagos = new List<TipoPago>();
            foreach (DataRow dr in dt.Rows)
            {
                TipoPago fp = new TipoPago();
                fp.nombre = dr["Nombre"].ToString();
                fp.id = Convert.ToInt32(dr["ID_Tipo_Pago"].ToString());
                lstTiposPagos.Add(fp);
            }
            return lstTiposPagos;
        }

        public bool Eliminar(int id)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            SqlParameter param = new SqlParameter() { ParameterName = "@ID", Value = id };
            lstParam.Add(param);
            return AccesoDatos.EjecutarSP("SP_Eliminar_Tipo_Pago", lstParam);
        }
    }
}
