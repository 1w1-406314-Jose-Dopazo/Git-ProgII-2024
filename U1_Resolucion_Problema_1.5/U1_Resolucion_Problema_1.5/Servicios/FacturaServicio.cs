using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U1_Resolucion_Problema_1._5.Datos;
using U1_Resolucion_Problema_1._5.Dominio.Clases;

namespace U1_Resolucion_Problema_1._5.Servicios
{
    internal class FacturaServicio : ServicioAbstracto<Factura>
    {
        DetalleFacturaServicio dfs = new DetalleFacturaServicio();
        TipoPagoServicio tps = new TipoPagoServicio();
        public void AgregarDetalle(Factura f, DetalleFactura df)
        {
            if (df.id == 0)
            {
                f.lstDetalles.Add(df);
            }
            else
            {
                Console.WriteLine("No se puede agregar detalles con ID existente");
            }
            
        }
        public override bool Guardar(Factura f)
            //region de guardado desplegable
        #region Guardar
        {

            bool aux = false;


            List<SqlParameter> lstParam = new List<SqlParameter>()
            {
                new SqlParameter ("@fecha",f.fecha),
                new SqlParameter ("@id_forma_pago",f.fp.id),
                new SqlParameter ("@nom_cliente",f.nomCliente),
                new SqlParameter ("@id_factura",f.id)
            };
            
            SqlParameter nroFactura = new SqlParameter();
            nroFactura.ParameterName = "@nro_factura";
            nroFactura.Direction = System.Data.ParameterDirection.Output;
            nroFactura.SqlDbType = SqlDbType.Int;
            lstParam.Add(nroFactura);
            
            if (f.id == 0)
            {
                lstParam.RemoveAt(3);

                aux = (AccesoDatos.ObtenerInstancia().Guardar("SP_Nueva_Factura", lstParam));

                foreach (DetalleFactura df in f.lstDetalles)
                {

                    List<SqlParameter> lst = new List<SqlParameter>()
                    {
                        new SqlParameter("@id_factura",Convert.ToInt32(nroFactura.Value)),
                        new SqlParameter("@id_articulo", df.articulo.id),
                        new SqlParameter("@cantidad", df.cantidad)
                    };

                        aux = AccesoDatos.ObtenerInstancia().Guardar("SP_Nuevo_Detalle", lst);


                }
            }
            else
            {
                
                aux = (AccesoDatos.ObtenerInstancia().Guardar("SP_Actualizar_Factura", lstParam));
                
                foreach (DetalleFactura df in f.lstDetalles)
                {
                    if (df.id > 0)
                    {
                        List<SqlParameter> lst = new List<SqlParameter>()
                        {
                            new SqlParameter("@id",df.id),
                            new SqlParameter("@id_factura", f.id),
                            new SqlParameter("@id_articulo", df.articulo.id),
                            new SqlParameter("@cantidad", df.cantidad)
                        };

                        aux = AccesoDatos.ObtenerInstancia().Guardar("SP_Actualizar_Detalle", lst);
                    }
                    else
                    {
                        List<SqlParameter> lst = new List<SqlParameter>()
                        {
                            new SqlParameter("@id_factura", f.id),
                            new SqlParameter("@id_articulo", df.articulo.id),
                            new SqlParameter("@cantidad", df.cantidad)
                        };

                        aux = AccesoDatos.ObtenerInstancia().Guardar("SP_Nuevo_Detalle", lst);
                    }
                }



                
            }
                return aux;

        }
        #endregion 

        public List<Factura> ObtenerFacturas()
        {
            DataTable dt = AccesoDatos.ConsultarSP("SP_Obtener_Facturas");
            List<Factura> lstFacturas = new List<Factura>();
            
            foreach (DataRow dr in dt.Rows)
            {
                Factura f = new Factura();
                f.fp = tps.ObtenerTipoPagoPorID(Convert.ToInt32(dr["ID_Forma_Pago"].ToString()));
                f.fecha = Convert.ToDateTime(dr["Fecha"].ToString());
                f.nomCliente = dr["Nom_Cliente"].ToString();
                f.id = Convert.ToInt32(dr["ID_Factura"].ToString());
                f.lstDetalles = dfs.ObtenerDetallesPorFactura(f);
                lstFacturas.Add(f);
            }
            return lstFacturas;
        }
        public bool Eliminar(int id)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>();
            SqlParameter param = new SqlParameter() { ParameterName = "@ID", Value = id };
            lstParam.Add(param);
            return AccesoDatos.EjecutarSP("SP_Eliminar_Factura", lstParam);
        }
    }
}
