
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
    "\nSalir: cierra la consola"+
    "\n" +
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
    while (comando != "salir")
    {


        comando = Console.ReadLine().ToString();
        comando.ToLower().Trim();
        switch (comando)
        {
            case "inicio": Mostrar(Inicio); break;

            case "listar articulos":
                if (lstArticulos.Count() > 0)
                {
                foreach (Articulo ar in lstArticulos) { ar.ToString(); }; break;

                }
                else
                {
                    Console.WriteLine("la lista Esta Vacia");
                    
                };break;

            case "listar formaspagos":

                if (lstTiposPagos.Count() > 0)
                {
                    foreach (TipoPago tp in lstTiposPagos) { tp.ToString(); }; break;

                }
                else
                {
                    Console.WriteLine("la lista Esta Vacia");

                }; break;

            case "listar facturas":

                if (lstFacturas.Count() > 0)
                {
                    foreach (Factura fac in lstFacturas) { fac.ToString(); }; break;

                }
                else
                {
                    Console.WriteLine("la lista Esta Vacia");

                }; break;


            case "mostrar detalles":

                if (lstFacturas.Count() > 0)
                {
                    if (lstDetalles.Count() > 0)
                    {
                        Console.WriteLine("Ingrese el Nro de Factura: ");
                        foreach (Factura f in lstFacturas)
                        {
                            f.ToString();
                        }
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
                    }
                    else
                    {
                        Console.WriteLine("la lista de Detalles Esta Vacia");

                    }; break;
                }
                else
                {
                    Console.WriteLine("la lista De Facturas Esta Vacia");

                }; break;

                

            case "nueva factura": lstFacturas.Add(CrearFactura()); break;

            case "nuevo detalle": lstDetalles.Add(CrearDetalle()); break;

            case "nuevo articulo": lstArticulos.Add(CrearArticulo()); break;

            case "nueva formapago": lstTiposPagos.Add(CrearTipoPago()); break;

            case "guardar articulo":
                Console.WriteLine("\nseleccione un articulo por ID: ");
                foreach (Articulo a in lstArticulos)
                {
                    a.ToString();
                }
                var artID = Console.ReadLine().ToString();
                foreach (Articulo a in lstArticulos)
                {
                    foreach (char c in artID)
                    {
                        if (!char.IsDigit(c))
                        {
                            Console.WriteLine("!!!\nDebe ingresar un ID exclusivamente Numerico!!!"); break;
                        }
                        if (int.Parse(artID) == a.id)
                        {
                            _ArticuloServicio.Guardar(a);
                        }
                    }
                }
                ; break;

            case "guardar formapago":

                Console.WriteLine("\nseleccione una Forma de Pago por ID: ");
                foreach (TipoPago t in lstTiposPagos)
                {
                    t.ToString();
                }
                var fpID = Console.ReadLine().ToString();
                foreach (TipoPago tp in lstTiposPagos)
                {
                    foreach (char c in fpID)
                    {
                        if (!char.IsDigit(c))
                        {
                            Console.WriteLine("\n!!!Debe ingresar un ID exclusivamente Numerico!!!"); break;
                        }
                        if (int.Parse(fpID) == tp.id)
                        {
                            _TipoPagoServicio.Guardar(tp);
                        }
                    }
                }
                ; break;

            case "guardar detalle":
                Console.WriteLine("\nSeleccione una Factura por ID:");
                foreach (Factura f in lstFacturas)
                {
                    f.ToString();
                }
                var fID = Console.ReadLine().ToString();
                Console.WriteLine("\nSeleccione un Detalle por ID:");
                foreach (DetalleFactura df in lstDetalles)
                {
                    df.ToString();
                }
                var dfID = Console.ReadLine().ToString();
                foreach (DetalleFactura df in lstDetalles)
                {
                    foreach (char c in dfID)
                    {
                        if (!char.IsDigit(c))
                        {
                            Console.WriteLine("\n!!!Debe ingresar un ID exclusivamente Numerico!!!"); break;
                        }
                        if (int.Parse(dfID) == df.id)
                        {
                            _DetalleFacturaServicio.Guardar(df, int.Parse(fID));
                        }
                    }
                }
                ; break;

            case "guardar factura":
                Console.WriteLine("\nSeleccione una Factura por ID:");
                foreach (Factura f in lstFacturas)
                {
                    f.ToString();
                }
                var facID = Console.ReadLine().ToString();
                foreach (Factura f in lstFacturas)
                {
                    foreach (char c in facID)
                    {
                        if (!char.IsDigit(c))
                        {
                            Console.WriteLine("\n!!!Debe ingresar un ID exclusivamente Numerico!!!"); break;
                        }
                        if (int.Parse(facID) == f.id)
                        {
                            _FacturaServicio.Guardar(f);
                        }
                    }
                };
                break;

            case "eliminar articulo":

                Console.WriteLine("\nSeleccione un articulo por ID:");
                foreach (Articulo a in lstArticulos)
                {
                    a.ToString();
                }
                var articID = Console.ReadLine().ToString();

                foreach (char c in articID)
                {
                    if (!char.IsDigit(c))
                    {
                        Console.WriteLine("!!!\nDebe ingresar un ID exclusivamente Numerico!!!"); break;
                    }
                }
                _ArticuloServicio.Eliminar(int.Parse(articID));

                ; break;


                TipoPago CrearTipoPago()
                {
                    int id = new int();
                    string nombre = string.Empty;

                    Console.WriteLine("\ningrese el codigo de la nueva Forma de Pago:");
                    if (Convert.ToInt32(Console.ReadLine().ToString()) > 0)
                    {
                        id = Convert.ToInt32(Console.ReadLine());
                    }
                    else { Console.WriteLine("\n!!!!Digite un codigo numerico mayor a cero!!!"); }

                    Console.WriteLine("\ningrese el nombre de la nueva Forma de Pago:");
                    var nombreV = Console.ReadLine().ToString();
                    bool aux = true;
                    foreach (char c in nombreV)
                    {
                        if (c is int)
                        {
                            aux = false;
                        }
                    }
                    if (aux == true)
                    {
                        nombre = nombreV;
                    }
                    else
                    {
                        Console.WriteLine("!!El nombre de la Forma de Pago no puede contener numeros");

                    }

                    TipoPago tp = new TipoPago();
                    tp.id = id;
                    tp.nombre = nombre;
                    return tp;
                }

                bool PreguntarPorExistencia(string s)
                {
                    s.ToLower();
                    s.Trim();
                    bool aux = false;
                    if (s == "nueva")
                    { aux = true; }
                    else if (s == "nuevo")
                    {
                        aux = true;
                    }
                    else if (s == "existente")
                    {
                        aux = false;
                    }
                    return aux;
                }

                Articulo CrearArticulo()
                {
                    int id = new int();
                    string nombre = string.Empty;
                    float precioUnitario = new float();

                    Console.WriteLine("\ningrese el codigo del Articulo: ");
                    if (Convert.ToInt32(Console.ReadLine().ToString()) > 0)
                    {
                        id = Convert.ToInt32(Console.ReadLine().ToString());
                    }
                    else { Console.WriteLine("\n!!!!Digite un codigo numerico mayor a cero!!!"); };

                    Console.WriteLine("\ningrese el nombre del Articulo:");
                    nombre = Console.ReadLine().ToString();

                    Articulo art = new Articulo();
                    art.id = id;
                    art.nombre = nombre;
                    return art;
                }

                DetalleFactura CrearDetalle()
                {
                    Articulo art = new Articulo();
                    int cantidad = 1;
                    Console.WriteLine("¿Detalle Con producto Nuevo o existente?");
                    if (PreguntarPorExistencia(Console.ReadLine().ToString()) == true)
                    {
                        art = CrearArticulo();
                    }
                    else
                    {
                        Console.WriteLine("seleccione un articulo: ");
                        foreach (Articulo a in lstArticulos)
                        {
                            Console.WriteLine(a.nombre);

                        }
                        foreach (Articulo a in lstArticulos)
                        {
                            if (Console.ReadLine().ToString() == a.nombre)
                            {
                                art = a;
                            }
                        }
                    }
                    Console.WriteLine("¿Cuantos?");
                    var cantidadV = Console.ReadLine().ToString();
                    if (Convert.ToInt32(cantidadV) > 0)
                    {
                        cantidad = Convert.ToInt32(cantidadV);
                    }
                    DetalleFactura df = new DetalleFactura(art, cantidad);

                    return df;

                }

                Factura CrearFactura()
                {
                    Console.WriteLine("\ningrese el Codigo de la Factura");
                    string codigoF = Console.ReadLine().ToString();
                    Console.WriteLine("\ningrese la Fecha de la Factura");
                    string fechaF = Console.ReadLine().ToString();
                    Console.WriteLine("\ningrese el Nombre de el/la cliente");
                    string nomClienteF = Console.ReadLine().ToString();
                    List<DetalleFactura> lstDetallesF = new List<DetalleFactura>();

                    TipoPago tipoPago = new TipoPago();

                    Console.WriteLine("\n¿Desea Agregar una forma de Pago Nueva o Existente?");
                    if (PreguntarPorExistencia(Console.ReadLine().ToString()) == true)
                    {
                        tipoPago = CrearTipoPago();
                    }
                    else
                    {
                        Console.WriteLine("\nSeleccione una Forma De Pago: ");
                        foreach (TipoPago tp in lstTiposPagos)
                        {
                            tp.nombre.ToString().Trim();
                            if (Console.ReadLine().ToString() == tp.nombre)
                            {
                                tipoPago = tp;
                            }
                        };
                    }

                    Console.WriteLine("\n¿Desea Agregar un detalle a la factura? SI/NO");
                    string respuesta = Console.ReadLine().ToString();
                    respuesta.ToLower().Trim();

                    if (respuesta == "si")
                    {
                        Console.WriteLine("\n¿Nuevo o Existente?:");
                        if (PreguntarPorExistencia(Console.ReadLine().ToString()) == true)
                        {
                            CrearDetalle();
                        }
                        else
                        {
                            Console.WriteLine("\nseleccione un ID detalle:");
                            foreach (DetalleFactura df in lstDetalles)
                            {
                                df.ToString();
                            }
                            string aux = Console.ReadLine().ToString();
                            if (Convert.ToInt32(aux.ToString()) > 0)
                            {
                                foreach (DetalleFactura df in lstDetalles)
                                {
                                    if (int.Parse(aux) == df.id)
                                    {
                                        lstDetallesF.Add(df);
                                    }
                                }
                            }
                        }

                    }
                    else if (respuesta == "no")
                    {

                    }
                    else
                    {
                        Console.WriteLine("Por favor Responder con Si o No");
                    }
                    Factura f = new Factura();
                    f.id = int.Parse(codigoF);
                    f.fecha = Convert.ToDateTime(fechaF);
                    f.nomCliente = nomClienteF;
                    f.fp = tipoPago;
                    f.lstDetalles = lstDetallesF;

                    return f;
                }

            case "eliminar formapago":

                Console.WriteLine("\nSeleccione una Forma de Pago por ID:");
                foreach (TipoPago t in lstTiposPagos)
                {
                    t.ToString();
                }
                var tpID = Console.ReadLine().ToString();
                foreach (char c in tpID)
                {
                    if (!char.IsDigit(c))
                    {
                        Console.WriteLine("!!!\nDebe ingresar un ID exclusivamente Numerico!!!"); break;
                    }
                }
                _TipoPagoServicio.Eliminar(int.Parse(tpID));
                ; break;

            case "eliminar factura":

                Console.WriteLine("\nSeleccione una Factura por ID:");
                foreach (Factura f in lstFacturas)
                {
                    f.ToString();
                }
                var facturaID = Console.ReadLine().ToString();
                foreach (char c in facturaID)
                {
                    if (!char.IsDigit(c))
                    {
                        Console.WriteLine("!!!\nDebe ingresar un ID exclusivamente Numerico!!!"); break;
                    }
                }
                _FacturaServicio.Eliminar(int.Parse(facturaID));
                ; break;

            case "eliminar detalle":

                Console.WriteLine("\nSeleccione una Forma de Pago por ID:");
                foreach (DetalleFactura detalle in lstDetalles)
                {
                    detalle.ToString();
                }
                var detID = Console.ReadLine();
                foreach (char c in detID)
                {
                    if (!char.IsDigit(c))
                    {
                        Console.WriteLine("!!!\nDebe ingresar un ID exclusivamente Numerico!!!"); break;
                    }
                }
                _DetalleFacturaServicio.Eliminar(int.Parse(detID));
                ; break;
        }
    }
}

Mostrar(Inicio);
EjecutarComando();