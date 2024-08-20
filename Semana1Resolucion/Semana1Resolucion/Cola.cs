using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana1Resolucion
{
    internal class Cola : IColeccion
    {
        static List<Object> lst = new List<Object> ();

        public int contar()
        {
            int i = 0;
            foreach (Object o in lst)
            {

                if (o != null) { i++; }
            }
            return i;
        }
        public bool añadir(object o)
        {
            bool aux = false;
            lst.Add(o);
            foreach(Object ob in lst)
            {
                if(ob == o) { aux = true; }
            }
            return aux;
        }

        public bool estaVacia()
        {
            bool aux = false;
            if (lst.Count == 0) 
            {
                aux= true;
            }
            return aux;
        }

        public object extraer()
        {
            Object o = new Object();
            if (lst.Count() > 0) { o=lst[0]; lst.RemoveAt(0); }
            else { Console.WriteLine("No hay elementos en la cola"); }
            return o;

            
        }

        public object primero()
        {
            Object o = new Object();
            if (lst.Count() > 0)
            {
                o = lst[0];
            }
            else { Console.WriteLine("No hay elementos en la cola"); }
            return (o);
        }
    }
}
