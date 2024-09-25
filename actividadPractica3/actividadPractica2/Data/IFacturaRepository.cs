using actividadPractica3.Models;

namespace actividadPractica3.Data
{
    public interface IFacturaRepository
    {
        Factura GetById(int id);

        List<Factura> GetAllFacturas();

        List<DetalleFactura> GetDetalles(int idFactura);
        bool DeleteFactura(int id);

        bool DeleteDetalle(int idFactura, int idDetalle);

        bool AddDetalle(int idFactura, DetalleFactura df);

        bool UpdateFactura(Factura Factura);

        bool SaveFactura(Factura Factura);
    }
}
