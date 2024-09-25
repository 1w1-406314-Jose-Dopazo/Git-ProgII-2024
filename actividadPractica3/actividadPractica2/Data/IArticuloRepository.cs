using actividadPractica3.Models;

namespace actividadPractica3.Data
{
    public interface IArticuloRepository
    {

        Articulo GetById(int id);

        List<Articulo> GetAll();

        bool DeleteOne(int id);


        bool UpdateOne(Articulo art);

        bool SaveOne(Articulo art);

    }
}
