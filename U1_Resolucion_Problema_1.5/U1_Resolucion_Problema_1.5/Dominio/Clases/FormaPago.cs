﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_Resolucion_Problema_1._5.Dominio.Clases
{
    public class FormaPago
    {
        public int id;
        public string nombre;

        public FormaPago(int id,string nom)
        {
            this.id = id;
            nombre = nom;
        }
        public FormaPago()
        {
            id = 0;
            nombre = string.Empty;
        }

        public override string ToString()
        {
            return "id: "+id.ToString()+"tipo pago: "+nombre;
        }
    }
}
