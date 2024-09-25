using actividadPractica3.Models;
using actividadPractica3.Data;

namespace actividadPractica3.Services
{
    public class AplicationService : IAplication
    {
        IArticuloRepository _ArticuloRepository;
        IFacturaRepository _FacturaRepository;

        public AplicationService(IArticuloRepository articuloRepository, IFacturaRepository facturaRepository)
        {
            _ArticuloRepository = articuloRepository;
            _FacturaRepository = facturaRepository;
        }


        public List<Articulo> GetArticulos()
        {
            return _ArticuloRepository.GetAll();
        }



        public bool SaveArticulo(Articulo art)
        {
            return _ArticuloRepository.SaveOne(art);
        }
        public bool RemoveArticulo(int id)
        {
            return _ArticuloRepository.DeleteOne(id);
        }

        public bool UpdateArticulo(Articulo art)
        {
            return _ArticuloRepository.UpdateOne(art);
        }

        public Articulo GetById(int id)
        {
            return _ArticuloRepository.GetById(id);
        }

        public Factura GetFacturaById(int id)
        {
            return _FacturaRepository.GetById(id);
        }

        public List<Factura> GetAllFacturas()
        {
            return _FacturaRepository.GetAllFacturas();
        }

        public List<DetalleFactura> GetDetalles(int idFactura)
        {
            return _FacturaRepository.GetDetalles(idFactura);
        }

        public bool DeleteFactura(int id)
        {
            return _FacturaRepository.DeleteFactura(id);
        }

        public bool DeleteDetalle(int idFactura, int idDetalle)
        {
            return _FacturaRepository.DeleteDetalle(idFactura, idDetalle);
        }

        public bool AddDetalle(int idFactura, DetalleFactura df)
        {
            return _FacturaRepository.AddDetalle(idFactura, df);
        }

        public bool UpdateFactura(Factura Factura)
        {
            return _FacturaRepository.UpdateFactura(Factura);
        }

        public bool SaveFactura(Factura Factura)
        {
            return _FacturaRepository.SaveFactura(Factura);
        }
    }
}
