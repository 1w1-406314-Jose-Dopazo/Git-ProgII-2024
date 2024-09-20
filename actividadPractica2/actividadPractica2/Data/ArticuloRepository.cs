using actividadPractica2.Models;
using System.Data;
using System.Data.SqlClient;


namespace actividadPractica2.Data
{
    public class ArticuloRepository : IArticuloRepository
    {


        public Articulo GetById(int id)
        {
            Articulo articulo = new Articulo();
            SqlParameter p = new SqlParameter() { ParameterName = "@ID", Value = id };
            List<SqlParameter> lstParam = new List<SqlParameter>();
            lstParam.Add(p);
            DataTable dt = DataHelper.GetInstance().GetBySP("SP_Obtener_Articulo", lstParam);
            foreach (DataRow dr in dt.Rows)
            {
                articulo.id = Convert.ToInt32(dr["ID_Articulo"].ToString());
                articulo.nombre = dr["Nombre"].ToString();
                articulo.precioUnitario = float.Parse(dr["Precio_Unitario"].ToString());
            }
            return articulo;
        }

        public List<Articulo> GetAll()
        {
            List<Articulo> lstArticulos = new List<Articulo>();
            DataTable dt = DataHelper.GetInstance().GetBySP("SP_Obtener_Articulos");
            foreach (DataRow dr in dt.Rows)
            {
                Articulo art = new Articulo() { id = Convert.ToInt32(dr["ID_Articulo"].ToString()), nombre = dr["Nombre"].ToString(), precioUnitario = float.Parse(dr["Precio_Unitario"].ToString()) };
                lstArticulos.Add(art);
            }
            return lstArticulos;
        }


        public bool DeleteMany(List<Articulo> lst)
        {
            bool result = false;
            foreach (Articulo articulo in lst)
            {
                SqlParameter p = new SqlParameter() { ParameterName="@ID",Value=articulo.id };
                result = DataHelper.GetInstance().ExecuteSP("SP_Eliminar_Articulo",p);

            }
            return result;
        }

        public bool DeleteOne(int id)
        {
            SqlParameter p = new SqlParameter() { ParameterName="@ID",Value=id};
            return DataHelper.GetInstance().ExecuteSP("SP_Eliminar_Articulo",p);
        }


        public bool SaveMany(List<Articulo> lst)
        {
            bool result = false;
            foreach (Articulo articulo in lst) 
            {
                
                SqlParameter aID = new SqlParameter() { ParameterName = "@id", Value = articulo.id };
                SqlParameter aName = new SqlParameter() { ParameterName = "@nombre", Value = articulo.nombre };
                SqlParameter aPrecioU = new SqlParameter() { ParameterName = "@precio_unit", Value = articulo.precioUnitario };
                List<SqlParameter> lstParam = new List<SqlParameter>() { aID, aName, aPrecioU };
                DataHelper.GetInstance().ExecuteSP("SP_Guardar_Articulo",null, lstParam);
                result = true;
            }
            return result;
        }

        public bool SaveOne(Articulo art)
        {
            
            SqlParameter id  = new SqlParameter() { ParameterName = "@id", Value = art.id };
            SqlParameter name = new SqlParameter() { ParameterName = "@nombre", Value = art.nombre };
            SqlParameter precioU = new SqlParameter() { ParameterName = "@precio_unit", Value = art.precioUnitario };
            List<SqlParameter> lstParam = new List<SqlParameter>() { id,name, precioU };
            return  DataHelper.GetInstance().ExecuteSP("SP_Guardar_Articulo",null,lstParam);
        }


    }
}