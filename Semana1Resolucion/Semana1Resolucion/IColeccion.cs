using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana1Resolucion
{
    public interface IColeccion
    {

        bool estaVacia();
        Object extraer();
        Object primero();
        bool añadir(Object o);
    }
}
