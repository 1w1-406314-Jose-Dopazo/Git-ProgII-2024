using actividadPractica3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using actividadPractica3.Data;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using actividadPractica3.Services;

namespace actividadPractica3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ArticuloController : ControllerBase
    {
        IAplication service;

        public ArticuloController(AplicationService aplicationService)
        {
            service = aplicationService;
        }


        [HttpGet("Articulos")]
        public IActionResult GetArticulos()
        {
            return Ok(service.GetArticulos());
        }


        [HttpGet("Articulo")]
        public IActionResult GetArticulo(int id)
        {
            try
            {
                List<Articulo> lst = service.GetArticulos();
                bool aux = false;
                foreach (Articulo articulo in lst)
                {

                    if (articulo.IdArticulo == id)
                    {
                        aux = true;
                    }
                    if (aux == false)
                    {
                        return BadRequest("No se encuentra al articulo de ID:" + id.ToString());
                    }
                }
                return Ok(service.GetById(id));
            }
            catch (HttpRequestException ex)
            {
                return BadRequest(ex.HttpRequestError);
            }
        }

        [HttpDelete("Articulo")]
        public IActionResult DeleteArticulo(int id)
        {
            try
            {
                return Ok(service.RemoveArticulo(id));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost("Articulo")]
        public IActionResult CreateArticulo(string nombre, float precioUnitario)
        {
            try
            {
                Articulo art = new Articulo() { IdArticulo = 0, Nombre = nombre, PrecioUnitario = precioUnitario };
                return Ok(service.SaveArticulo(art));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpPatch("Articulo")]
        public IActionResult UptdateArticulo(int ID, string nombre, float precioUnitario)
        {
            IActionResult result = BadRequest("Error al Acualizar");
            try
            {
                Articulo art = new Articulo() { IdArticulo = ID, Nombre = nombre, PrecioUnitario = precioUnitario };
                return Ok(service.UpdateArticulo(art));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
