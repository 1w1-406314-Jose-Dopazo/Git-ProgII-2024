﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace actividadPractica3.Models;

public partial class TipoPago
{
    public int IdTipoPago { get; set; }

    public string Nombre { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}