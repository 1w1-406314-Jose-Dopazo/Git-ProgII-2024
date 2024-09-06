using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U1_Resolucion_Problema_1._5.Dominio.Interfaces;
using System.Resources;
using U1_Resolucion_Problema_1._5.Properties;

namespace U1_Resolucion_Problema_1._5.Datos
{
    internal class AccesoDatos 
    {

        private SqlCommand cmd;
        private SqlConnection con;
        static AccesoDatos _instancia;

        private AccesoDatos()
        {
            con = new SqlConnection();
            con.ConnectionString = Resources.CadenaConexion;
            cmd = new SqlCommand();
            cmd.Connection = con;

        }
        public static DataTable ConsultarSP(string SP, string id)
        {
            DataTable dt = new DataTable();
            AccesoDatos acceso = ObtenerInstancia();
            
            acceso.con.Open();
            acceso.cmd.CommandText = SP;
            acceso.cmd.CommandType = CommandType.StoredProcedure;
            acceso.cmd.Parameters.AddWithValue("@ID",id);
            dt.Load(acceso.cmd.ExecuteReader());
            acceso.con.Close();
            return dt;
        }


        public static bool EjecutarSP(string SP, List<SqlParameter> lstParam)
        {
            bool aux = false;
            AccesoDatos a = ObtenerInstancia();
            a.con.Open();
            a.cmd.CommandText = SP;
            a.cmd.CommandType = CommandType.StoredProcedure;
            a.cmd.Parameters.Clear();
            foreach (SqlParameter p in lstParam) 
            {
                a.cmd.Parameters.Add(p);
            }
            if (a.cmd.ExecuteNonQuery() > 1)
            {
                aux = true;
            }
            a.con.Close();
            return aux;
        }
        public static bool GuardarMaestroDetalle(string SP, List<SqlParameter> lstParam,SqlTransaction t)
        {
            bool aux = false;
            AccesoDatos a = ObtenerInstancia();
            a.con.Open();
            a.cmd.CommandText = SP;
            a.cmd.CommandType = CommandType.StoredProcedure;
            a.cmd.Parameters.Clear();
            a.cmd.Transaction= t;
            foreach (SqlParameter p in lstParam)
            {
                a.cmd.Parameters.Add(p);
            }
            if (a.cmd.ExecuteNonQuery() > 1)
            {
                aux = true;
            }
            a.con.Close();
            return aux;
        }

        public static AccesoDatos ObtenerInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new AccesoDatos();
            }
            return _instancia;
        }
    }
}
