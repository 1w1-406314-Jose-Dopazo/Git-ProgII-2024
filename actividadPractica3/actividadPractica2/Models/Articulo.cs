﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace actividadPractica3.Models;

public partial class Articulo
{
    public int IdArticulo { get; set; }

    public string Nombre { get; set; }

    public double? PrecioUnitario { get; set; }

    public virtual ICollection<DetalleFactura> DetallesFacturas { get; set; } = new List<DetalleFactura>();
}