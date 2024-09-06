using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U1_Resolucion_Problema_1._5.Properties;
using U1_Resolucion_Problema_1._5.Servicios;

namespace U1_Resolucion_Problema_1._5.Datos
{
    public class UnitOfWork : IDisposable
    {
        private SqlTransaction _transaccion;
        private SqlConnection _connexion;
        private FacturaServicio _facturaServicio;

        public UnitOfWork()
        {
            _connexion = new SqlConnection(Resources.CadenaConexion);
            _connexion.Open();
            _transaccion = _connexion.BeginTransaction();
        }
        public void GuardarCambios()
        {
            try
            {
                _transaccion.Commit();
            }
            catch (Exception ex)
            {
                _transaccion.Rollback();
                throw new Exception("Error al guardar Cambios", ex);
            }
            
        }
        public void Dispose()
        {
            if (_transaccion != null) 
            {
                _transaccion.Dispose();
            }
            if(_connexion != null)
            {
                _connexion.Close();
                _connexion.Dispose();
            }
        }
        
    }
}
