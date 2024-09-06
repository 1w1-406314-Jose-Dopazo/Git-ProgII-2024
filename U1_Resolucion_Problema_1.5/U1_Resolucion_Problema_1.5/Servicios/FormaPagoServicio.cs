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
    internal class FormaPagoServicio : ServicioAbstracto<FormaPago>
    {
        public override void Guardar(FormaPago fp)
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
            AccesoDatos.EjecutarSP("SP_Guardar_Forma_Pago",lstParam);
        }
    }
}
