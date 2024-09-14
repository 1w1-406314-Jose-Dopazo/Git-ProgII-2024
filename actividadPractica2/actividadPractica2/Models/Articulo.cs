namespace actividadPractica2.Models
{
    public class Articulo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public float precioUnitario { get; set; }

        public Articulo(int id, string nom, float precioU)
        {
            this.id = id;
            nombre = nom;
            precioUnitario = precioU;
        }
        public Articulo()
        {
            id = 0;
            nombre = string.Empty;
            precioUnitario = 0;
        }

        public override string ToString()
        {
            return "\nID: " + id.ToString() + "\nNombre: " + nombre + "\nPrecio Unitario: " + precioUnitario.ToString();
        }
    }
}
