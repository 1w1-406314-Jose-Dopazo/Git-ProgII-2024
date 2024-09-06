using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_Resolucion_Problema_1._5.Dominio.Clases
{
    public class Articulo
    {
        public int id;
        public string nombre;
        public float precioUnitario;

        public Articulo(int id,string nom,float precioU)
        {
            this.id = id;
            nombre= nom;
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
            return "id: "+id.ToString()+"nombre: "+nombre+"precio unitario: "+precioUnitario.ToString();
        }
    }
}
