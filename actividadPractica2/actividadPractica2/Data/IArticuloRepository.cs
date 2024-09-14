using actividadPractica2.Models;

namespace actividadPractica2.Data
{
    public interface IArticuloRepository
    {

        Articulo GetById(int id);

        List<Articulo> GetAll();

        bool DeleteOne(int id);

        bool DeleteMany(List<Articulo> lst);

        bool SaveOne(Articulo art);

        bool SaveMany(List<Articulo> lst);
    }
}
