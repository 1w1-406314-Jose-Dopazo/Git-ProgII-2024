using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U1_Resolucion_Problema_1._5.Datos;
using U1_Resolucion_Problema_1._5.Dominio.Interfaces;

namespace U1_Resolucion_Problema_1._5.Servicios
{
    abstract class ServicioAbstracto<Clase> :IServicio
    {
        public void Consultar(string sp,string id)
        {
            AccesoDatos.ConsultarSP(sp, id);
        }


        public bool Eliminar(string sp,string id)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            SqlParameter p = new SqlParameter();
            p.Value = id;
            lista.Add(p);
           return AccesoDatos.EjecutarSP("SP_Eliminar", lista);
        }

        public abstract bool Guardar(Clase c);
        
    }
}
