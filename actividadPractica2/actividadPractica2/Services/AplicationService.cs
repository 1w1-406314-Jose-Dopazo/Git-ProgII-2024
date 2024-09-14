using actividadPractica2.Data;
using actividadPractica2.Models;

namespace actividadPractica2.Services
{
    public class AplicationService : IAplication
    {
        ArticuloRepository _ArticuloRepository = new ArticuloRepository();
        public bool SaveArticulos()
        {
            throw new NotImplementedException();
        }

        public List<Articulo> GetArticulos()
        {
           return _ArticuloRepository.GetAll();
        }

        public bool RemoveArticulos(List<Articulo> lst)
        {
           return _ArticuloRepository.DeleteMany(lst);
        }

        public bool UpdateArticulos(List<Articulo> lst)
        {
            return _ArticuloRepository.SaveMany(lst);
        }

        public bool SaveArticulo(Articulo art)
        {
            return _ArticuloRepository.SaveOne(art);
        }
        public bool SaveArticulos(List<Articulo> lst)
        {
            return _ArticuloRepository.SaveMany(lst);
        }

        public bool RemoveArticulo(int id)
        {
            return _ArticuloRepository.DeleteOne(id);
        }

        public bool UpdateArticulo(Articulo art)
        {
            return _ArticuloRepository.SaveOne(art);
        }

        public Articulo GetById(int id)
        {
            return _ArticuloRepository.GetById(id);
        }
    }
}
