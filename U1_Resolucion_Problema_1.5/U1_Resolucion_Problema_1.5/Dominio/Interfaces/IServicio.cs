using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_Resolucion_Problema_1._5.Dominio.Interfaces
{
    internal interface IServicio
    {
        bool Eliminar(string sp,string id);


        void Consultar(string sp,string id);

    }
}
