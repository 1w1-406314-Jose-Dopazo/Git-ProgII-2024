using actividadPractica2.Models;

namespace actividadPractica2.Services
{
    public interface IAplication
    {
        bool SaveArticulos(List<Articulo> lst);
        bool RemoveArticulos(List<Articulo>lst);

        bool UpdateArticulos(List<Articulo>lst);

        bool SaveArticulo(Articulo art);

        bool RemoveArticulo(int id);

        bool UpdateArticulo(Articulo art);

        Articulo GetById(int id);

        List<Articulo> GetArticulos();
    }
}
