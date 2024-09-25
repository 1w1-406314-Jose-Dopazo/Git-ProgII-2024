using actividadPractica3.Models;
using actividadPractica3.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace actividadPractica3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private IAplication _aplicationService;

        public FacturaController(IAplication aplication)
        {
            _aplicationService = aplication;
        }

        // GET: api/<FacturaController>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_aplicationService.GetAllFacturas());
        }

        // GET api/<FacturaController>/5
        [HttpGet("ID")]
        public IActionResult GetFactura(int id)
        {
            return Ok(_aplicationService.GetFacturaById(id));
        }

        [HttpGet("Detalles")]
        public IActionResult GetDetalles(int idFactura)
        {
            return Ok(_aplicationService.GetDetalles(idFactura));
        }

        // POST api/<FacturaController>
        [HttpPost]
        public IActionResult Post(DateTime Fecha, int Forma_Pago, string Nombre_Cliente)
        {
            Factura f = new Factura();
            f.Fecha = Fecha;
            f.IdFormaPago = Forma_Pago;
            f.NomCliente = Nombre_Cliente;
            return Ok(_aplicationService.SaveFactura(f));
        }

        // PUT api/<FacturaController>/5
        [HttpPut("Update")]
        public IActionResult Put(int Id_Factura, DateTime Fecha, int Forma_Pago, string Nombre_Cliente)
        {
            Factura f = new Factura();
            f.IdFactura = Id_Factura;
            f.IdFormaPago = Forma_Pago;
            f.Fecha = Fecha;
            f.NomCliente = Nombre_Cliente;
            return Ok(_aplicationService.UpdateFactura(f));
        }

        // DELETE api/<FacturaController>/5
        [HttpDelete("Fatura/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_aplicationService.DeleteFactura(id));
        }
    }
}
