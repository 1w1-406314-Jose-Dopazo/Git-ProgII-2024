using actividadPractica2.Properties;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Versioning;

namespace actividadPractica2.Data
{
    public class DataHelper
    {
        private string _conectionString = Resources.conectionString;
        private SqlCommand _cmd;
        private SqlConnection _connection;
        private static DataHelper _Instance;

        private DataHelper()
        {
            _cmd = new SqlCommand();
            _connection = new SqlConnection();
            _connection.ConnectionString = _conectionString;
            _cmd.Connection = _connection;
        }
        public static DataHelper GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new DataHelper();
            }
            return _Instance;
        }
        public bool ExecuteSP(string sp,SqlParameter? p = null,List<SqlParameter>? lstParam = null)
        {
            bool result = false;
            GetInstance();
            _Instance._connection.Open();
            _Instance._cmd.Parameters.Clear();
            _Instance._cmd.CommandText = sp;
            _Instance._cmd.CommandType = CommandType.StoredProcedure;
            if(p != null)
            {
                _cmd.Parameters.Add(p);
            }
            if(lstParam != null)
            {
                foreach(SqlParameter param in lstParam)
                {
                    _cmd.Parameters.Add(param);
                }
            }
            result = _Instance._cmd.ExecuteNonQuery() > 0;
            _Instance._connection.Close();
            return result;

        }
        public DataTable GetBySP(string sp, List<SqlParameter>? pl = null)
        {
            DataTable dt = new DataTable();
            _Instance._connection.Open();
            _Instance._cmd.CommandText = sp;
            _Instance._cmd.CommandType = CommandType.StoredProcedure;
            _Instance._cmd.Parameters.Clear();
            if (pl != null)
            {
                foreach (SqlParameter p in pl)
                {
                    _cmd.Parameters.Add(p);
                }
            }
            dt.Load(_Instance._cmd.ExecuteReader());
            _Instance._connection.Close();
            return dt;
        }
    }
}
