using actividadPractica3.Models;

namespace actividadPractica3.Services
{
    public interface IAplication
    {


        bool SaveArticulo(Articulo art);

        bool RemoveArticulo(int id);

        bool UpdateArticulo(Articulo art);

        Articulo GetById(int id);

        List<Articulo> GetArticulos();

        Factura GetFacturaById(int id);

        List<Factura> GetAllFacturas();

        List<DetalleFactura> GetDetalles(int idFactura);
        bool DeleteFactura(int id);

        bool DeleteDetalle(int idFactura, int idDetalle);

        bool AddDetalle(int idFactura, DetalleFactura df);

        bool UpdateFactura(Factura Factura);

        bool SaveFactura(Factura Factura);
    }
}
