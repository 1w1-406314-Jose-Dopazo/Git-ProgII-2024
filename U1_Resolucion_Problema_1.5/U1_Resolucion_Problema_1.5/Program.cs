
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using U1_Resolucion_Problema_1._5.Datos;
using U1_Resolucion_Problema_1._5.Dominio.Clases;
using U1_Resolucion_Problema_1._5.Servicios;


ArticuloServicio _ArticuloServicio = new ArticuloServicio();
TipoPagoServicio _TipoPagoServicio = new TipoPagoServicio();
DetalleFacturaServicio _DetalleFacturaServicio = new DetalleFacturaServicio();
FacturaServicio _FacturaServicio = new FacturaServicio();

List<Articulo> lstArticulos = _ArticuloServicio.ObtenerArticulos();
List<TipoPago> lstTiposPagos = _TipoPagoServicio.ObtenerTiposPagos();
List<Factura> lstFacturas = _FacturaServicio.ObtenerFacturas();
List<DetalleFactura> lstDetalles = new List<DetalleFactura>();

#region PantallaDeInicio
string Inicio =
    "Bienvenido" + "\nAcciones disponibles:" +
    "\n" +
    "\nInicio: vuelve a esta pantalla." +
    "\nListar Articulos: Lista los articulos existentes." +
    "\nListar FormasPagos: Lista las Formas de pago existentes." +
    "\nListar Facturas: Lista las Facturas existentes." +
    "\nMostrar Detalles + nroFactura: Muestra los Detalles de la factura." +
    "\n" +
    "\nNuevo articulo: crea un nuevo Articulo con la informacion brindada." +
    "\nNueva FormaPago: crea una nueva Forma de pago con la informacion brindada." +
    "\nNueva Factura: crea una nueva Factura con la informacion brindada." +
    "\nNuevo Detalle: crea un nuevo Detalle con la informacion brindada." +
    "\n" +
    "\nGuardar Articulo: guarda el articulo especificado en la base de datos." +
    "\nGuardar FormaPago: guarda la Forma de pago especificada en la base de datos." +
    "\nGuardar Factura: guarda la Factura especificada en la base de datos." +
    "\nGuardar Detalle: guarda un Detalle de la Factura especificada en la base de datos." +
    "\n" +
    "\nEliminar Articulo: elimina el Articulo especificado de la base de datos." +
    "\nEliminar FormaPago: elimina el Articulo especificado de la base de datos." +
    "\nEliminar Factura: elimina el Articulo especificado de la base de datos." +
    "\nEliminar Detalle: elimina el Articulo especificado de la base de datos." +
    "\n"+
    "\n";
#endregion


void Mostrar(string s)
{
    Console.WriteLine(s);
};
void EjecutarComando()
{
    string comando = string.Empty;
    comando = Console.ReadLine();
    comando.ToLower();
    switch (comando)
    {
        case "inicio": Mostrar(Inicio); break;

        case "listar articulos": foreach(Articulo ar in lstArticulos) { ar.ToString(); } ; break;

        case "listar formaspagos": foreach (TipoPago tp in lstTiposPagos) { tp.ToString(); }; break;

        case "listar facturas": foreach (Factura f in lstFacturas) { f.ToString(); }; break;

        case "mostrar detalles":
            Console.WriteLine("Ingrese el Nro de Factura: ");
            lstDetalles.Clear();
            Factura f1 = new Factura();
            foreach (Factura f in lstFacturas)
            {
                if (f.id == Convert.ToInt32(Console.ReadLine().ToString())) 
                    {
                    lstDetalles = _DetalleFacturaServicio.ObtenerDetallesPorFactura(f);
                    }
            }
            foreach (DetalleFactura df in lstDetalles)
            {
                df.ToString();
            };
            break;

        case "nuevo articulo":
            Console.WriteLine("\ningrese el Codigo de articulo");
            string codigo = Console.ReadLine();
            Console.WriteLine("\ningrese el Nombre del Articulo");
            string nombre = Console.ReadLine();
            Console.WriteLine("\nIngrese el Precio del Articulo");
            string precio = Console.ReadLine();
            foreach(Articulo a in lstArticulos)
            {
                if (a.id == Convert.ToInt32(codigo))
                {
                    a.nombre = nombre;
                    a.precioUnitario = float.Parse(precio);
                }
                else
                {
                    Articulo art = new Articulo(Convert.ToInt32(codigo),nombre,float.Parse(precio));
                    lstArticulos.Add(art);
                }
            };
            break;
    }

}








