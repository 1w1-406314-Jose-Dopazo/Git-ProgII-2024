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
    internal class FacturaServicio : ServicioAbstracto<Factura>
    {
      
        public void AgregarDetalle(Factura f,DetalleFactura df)
        {
            f.lstDetalles.Add(df);
        }
        public override async bool Guardar(Factura f)
        {
            UnitOfWork uow = new UnitOfWork();
            bool aux = false;
            int detallesIncertados = 0;
            DetalleFacturaServicio dfs = new DetalleFacturaServicio();
            SqlParameter id = new SqlParameter();
            SqlParameter fecha = new SqlParameter();
            SqlParameter formaPago = new SqlParameter();
            SqlParameter nomCliente = new SqlParameter();
            id.Value = f.id;
            id.ParameterName = "@id";
            fecha.Value = f.fecha;
            fecha.ParameterName = "@fecha";
            formaPago.Value = f.fp.id;
            formaPago.ParameterName = "@id_forma_pago";
            nomCliente.Value = f.nomCliente;
            nomCliente.ParameterName = "@nom_cliente";
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(id);
            lstParam.Add(fecha);
            lstParam.Add(formaPago);
            lstParam.Add(nomCliente);
            
           if(AccesoDatos.EjecutarSP("SP_Guardar_Factura", lstParam) == true)
            {
                aux = true;
                uow.GuardarCambios();
                
            }


            foreach (DetalleFactura df in f.lstDetalles) await AccesoDatos.EjecutarSP();
            {
                
                df.idFactura = f.id;
               if(dfs.Guardar(df) == true)
                {
                    uow.GuardarCambios();
                    Console.WriteLine("detalles incertados" + detallesIncertados++.ToString());
                }
                
            }
            uow.Dispose();
            return  aux;
        }
    }
}
