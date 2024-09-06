
using U1_Resolucion_Problema_1._5.Datos;
using U1_Resolucion_Problema_1._5.Dominio.Clases;
using U1_Resolucion_Problema_1._5.Servicios;

Articulo art = new Articulo(4, "Galletas Oreo", 890);

FormaPago formaPago = new FormaPago(4, "Fiado");

DetalleFactura d1 = new DetalleFactura(5,6,art,3);

Factura f1 = new Factura();
f1.fp = formaPago;
f1.id = 6;
f1.fecha = DateTime.Parse("02-09-2024");
f1.lstDetalles.Add(d1);
f1.nomCliente = "marco";
FacturaServicio fs = new FacturaServicio();
fs.Guardar(f1);