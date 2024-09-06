using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using U1_Resolucion_Problema_1._5.Datos;
using U1_Resolucion_Problema_1._5.Dominio.Clases;

namespace U1_Resolucion_Problema_1._5.Servicios
{
    internal class ArticuloServicio : ServicioAbstracto<Articulo>
    {

        public override void Guardar(Articulo a)
        {
            SqlParameter id = new SqlParameter();
            SqlParameter nombre = new SqlParameter();
            SqlParameter precioU = new SqlParameter();
            id.Value = a.id;
            id.Direction = System.Data.ParameterDirection.Input;
            id.ParameterName = "@id";
            nombre.Value = a.nombre;
            nombre.Direction = System.Data.ParameterDirection.Input;
            nombre.ParameterName = "@nombre";
            precioU.Value = a.precioUnitario;
            precioU.Direction = System.Data.ParameterDirection.Input;
            precioU.ParameterName = "@precio_unit";
            List<SqlParameter> listaParam = new List<SqlParameter>();
            listaParam.Add(id);
            listaParam.Add(nombre);
            listaParam.Add(precioU);
            AccesoDatos.EjecutarSP("SP_Guardar_Articulo", listaParam);
        }

    }
}
