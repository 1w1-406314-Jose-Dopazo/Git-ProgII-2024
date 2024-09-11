using System;
using System.Collections.Generic;
using System.Data;
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

        public override bool Guardar(Articulo a)
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
            return AccesoDatos.EjecutarSP("SP_Guardar_Articulo", listaParam);
        }
        public List<Articulo> ObtenerArticulos()
        {
            DataTable dt = AccesoDatos.ConsultarSP("SP_Obtener_Articulos");
            List<Articulo> lstArt = new List<Articulo>();
            foreach (DataRow dr in dt.Rows)
            {
                lstArt.Add(new Articulo(Convert.ToInt32(dr["ID_Articulo"].ToString()), dr["Nombre"].ToString(), float.Parse(dr["Precio_Unitario"].ToString())));
            }
            return lstArt;
        }
        public Articulo ObtenerArticuloPorID(int id)
        {
            DataTable dt = AccesoDatos.ConsultarUnoSP("SP_Obtener_Articulo", id);
            DataRow dr = dt.Rows[0];
            Articulo articulo = new Articulo(Convert.ToInt32(dr["ID_Articulo"].ToString()), dr["Nombre"].ToString(), float.Parse(dr["Precio_Unitario"].ToString()));
            return articulo;
        }

        public bool Eliminar(int id)
        {
            List<SqlParameter>lstParam = new List<SqlParameter>();
            SqlParameter param = new SqlParameter() { ParameterName="@ID",Value=id};
            lstParam.Add(param);
            return AccesoDatos.EjecutarSP("SP_Eliminar_Articulo",lstParam);
        }
    }
}
