using actividadPractica3.Models;

namespace actividadPractica3.Data
{
    public class FacturaRepository : IFacturaRepository
    {
        private AplicationContext _AplicationContext;
        public FacturaRepository(AplicationContext context)
        {
            _AplicationContext = context;
        }
        public bool AddDetalle(int idFactura, DetalleFactura df)
        {
            Factura f = _AplicationContext.Facturas.Find(idFactura);
            if (f != null)
            {
                f.DetallesFacturas.Add(df);
                _AplicationContext.Facturas.Update(f);
                _AplicationContext.SaveChanges();
            }
            if (f == null)
            {
                _AplicationContext.Dispose();
                return false;
            }
            else
            {
                _AplicationContext.Dispose();
                return false;
            }

        }

        public bool DeleteDetalle(int idFactura, int idDetalle)
        {
            List<Factura> lstFacturas = new List<Factura>();
            List<DetalleFactura> lstDetalles = new List<DetalleFactura>();

            try
            {
                lstFacturas = _AplicationContext.Facturas.Where(x => x.IdFactura == idFactura).ToList();
                lstDetalles = _AplicationContext.DetallesFacturas.Where(y => y.IdDetalleFactura == idDetalle).ToList();

                lstFacturas[0].DetallesFacturas.Remove(lstDetalles[0]);
                UpdateFactura(lstFacturas[0]);
                _AplicationContext.SaveChanges();
                return true;
            }
            catch
            {
                _AplicationContext.Dispose();
                return false;
            }


        }

        public bool DeleteFactura(int id)
        {
            try
            {
                _AplicationContext.Facturas.Remove(GetById(id));
                _AplicationContext.SaveChanges();
                return true;

            }
            catch
            {
                _AplicationContext.Dispose();
                return false;
            }

        }

        public List<Factura> GetAllFacturas()
        {
            return _AplicationContext.Facturas.ToList();
        }

        public Factura GetById(int id)
        {

            List<Factura> lstFactura = new List<Factura>();
            lstFactura = _AplicationContext.Facturas.Where(x => x.IdFactura == id).ToList();
            return lstFactura[0];
        }

        public List<DetalleFactura> GetDetalles(int idFactura)
        {
            return _AplicationContext.DetallesFacturas.Where(x => x.IdFactura == idFactura).ToList();
        }

        public bool SaveFactura(Factura Factura)
        {
            try
            {
                _AplicationContext.Facturas.Add(Factura);
                _AplicationContext.SaveChanges();
                return true;

            }
            catch
            {
                _AplicationContext.Dispose();
                return false;
            }
        }

        public bool UpdateFactura(Factura Factura)
        {
            try
            {
                _AplicationContext.Facturas.Update(Factura);
                _AplicationContext.SaveChanges();
                return true;
            }
            catch
            {
                _AplicationContext.Dispose();
                return false;
            }
        }
    }
}
