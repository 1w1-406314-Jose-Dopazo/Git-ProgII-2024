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
        public static DataTable ConsultarUnoSP(string SP, int id)
        {
            DataTable dt = new DataTable();
            ObtenerInstancia();
            
            _instancia.con.Open();
            _instancia.cmd.CommandText = SP;
            _instancia.cmd.CommandType = CommandType.StoredProcedure;
            _instancia.cmd.Parameters.Clear();
            _instancia.cmd.Parameters.AddWithValue("@ID",id);
            dt.Load(_instancia.cmd.ExecuteReader());
            _instancia.con.Close();
            return dt;
        }
        public static DataTable ConsultarSP(string sp)
        {
            DataTable dt = new DataTable();
            ObtenerInstancia();

            _instancia.con.Open();
            _instancia.cmd.CommandText = sp;
            _instancia.cmd.CommandType = CommandType.StoredProcedure;
            dt.Load(_instancia.cmd.ExecuteReader());
            _instancia.con.Close();
            return dt;
        }


        public static bool EjecutarSP(string SP, List<SqlParameter> lstParam)
        {
            bool aux = false;
            ObtenerInstancia();
            _instancia.con.Open();
            _instancia.cmd.CommandText = SP;
            _instancia.cmd.CommandType = CommandType.StoredProcedure;
            _instancia.cmd.Parameters.Clear();
            foreach (SqlParameter p in lstParam) 
            {
                _instancia.cmd.Parameters.Add(p);
            }
            if (_instancia.cmd.ExecuteNonQuery() > 1)
            {
                aux = true;
            }
            _instancia.con.Close();
            return aux;
        }
        public bool Guardar(string SP, List<SqlParameter> lstParam)
        {
            

            
            
            bool aux = false;
            
            con.Open();
            SqlTransaction t = con.BeginTransaction();
            cmd.CommandText = SP;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Transaction = t;
            foreach (SqlParameter p in lstParam)
            {
                cmd.Parameters.Add(p);
            };
            try
            {

                if (cmd.ExecuteNonQuery() > 1)
                {
                    aux = true;
                }
                t.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                t.Rollback();
            }

            con.Close();
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
