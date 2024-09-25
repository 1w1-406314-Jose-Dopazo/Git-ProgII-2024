using actividadPractica3.Models;
using System.Data;
using System.Data.SqlClient;


namespace actividadPractica3.Data
{
    public class ArticuloRepository : IArticuloRepository
    {
        private AplicationContext _context;
        public ArticuloRepository(AplicationContext context)
        {
            _context = context;
        }

        public Articulo GetById(int id)
        {
            List<Articulo> lstArt = new List<Articulo>();
            lstArt = _context.Articulos.Where(x => x.IdArticulo == id).ToList();
            return lstArt[0];
        }

        public List<Articulo> GetAll()
        {
            return _context.Articulos.ToList();
        }




        public bool DeleteOne(int id)
        {
            try
            {
                _context.Articulos.Remove(GetById(id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                _context.Dispose();
                return false;
            }
        }


        public bool SaveOne(Articulo art)
        {
            try
            {

                _context.Articulos.Add(art);
                _context.SaveChanges();
                return true;
            }
            catch
            {

                _context.Dispose();
                return false;

            }
        }
        public bool UpdateOne(Articulo art)
        {
            try
            {
                _context.Articulos.Update(art);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                _context.Dispose();
                return false;
            }
        }


    }
}