using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana1Resolucion
{
    public class Pila : IColeccion
    {

        static Object[] A = new Object[5];
      
      

        
        public int contar()
        {
            int i = 0;
            foreach (Object o in A)
            {
                
                if (o != null) { i++;}
            }
            return i;
        }


        //añadir(): añade un objeto por el extremo que corresponda, y devuelve true si
       // se ha añadido y false en caso contrario

        //*1 (añadir un objeto a el array)
        //*2 (poder devolver una variable booleana probablemente con una variable local)
 
        public bool añadir(Object o)
        {
            
            
            bool aux = false;
            if (this.contar() < 5)
            {
                
                A[this.contar()] = o;
                aux = true;
            }
            
           

            return aux;
          
         
            
        }

        public bool estaVacia()
        {
            Pila p = new Pila();
            bool aux = false;
            if (p.contar() == 0) 
            {
                aux = true;
            }
            return aux;
        }

        public Object extraer()
        {
          int i = this.contar();
            Object objeto = "error";
            objeto = A[i-1];
            A[i-1] = null;
            return objeto;
        }

        public Object primero()
        {
            Pila p = new Pila();
                return A[p.contar()-1];
           
        }
    }
}
