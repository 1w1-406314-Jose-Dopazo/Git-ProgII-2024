using actividadPractica2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using actividadPractica2.Data;
using actividadPractica2.Services;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace actividadPractica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ArticuloController : ControllerBase
    {
        IAplication service;
        bool aux = false;

        public ArticuloController()
        {
            service = new AplicationService();
        }

        [HttpGet("Articulos")]
        public IActionResult GetArticulos()
        {
            try 
            { 
                return Ok(service.GetArticulos()); 
            }
            catch (HttpRequestException ex) 
            {
                return BadRequest(ex.HttpRequestError);
            }
            
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
                    
                    if(articulo.id == id)
                    {
                        aux = true;
                    }
                    if (aux == false)
                    {
                        return BadRequest("No se encuentra al articulo de ID:"+id.ToString());
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Articulos")]
        public IActionResult DeleteArticulos(List<Articulo> lst,int Articulo1_ID,int Articulo2_ID)
        {
            IActionResult result = BadRequest("Error");
            try
            {
                List<Articulo> lstArt = service.GetArticulos();
                foreach (Articulo articulo in lstArt)
                {
                    if(articulo.id == Articulo1_ID)
                    {
                        lst.Add(articulo);
                        result = Ok(service.RemoveArticulos(lst));
                    }
                    else
                    {
                        result = BadRequest("No se encontro 1 o mas articulos ingresados");
                    }
                    if(articulo.id == Articulo2_ID)
                    {
                        lst.Add(articulo);
                        result = Ok(service.RemoveArticulos(lst));
                    }
                    else
                    {
                        result = BadRequest("No se encontro 1 o mas articulos ingresados");
                    }
                }
                
                return result;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Articulo")]
        public IActionResult CreateArticulo(string nombre,float precioUnitario)
        {
            try
            {
                Articulo art = new Articulo() { id = 0,nombre=nombre,precioUnitario=precioUnitario};
                return Ok(service.SaveArticulo(art));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Articulos")]
        
        public IActionResult CreateArticulos(string Articulo1_nombre,float Articulo1_precioUnitario, string Articulo2_nombre, float Articulo2_precioUnitario)
        {
            List<Articulo> lstArt = new List<Articulo>();
            try
            {
                Articulo art = new Articulo() { id = 0, nombre = Articulo1_nombre, precioUnitario = Articulo1_precioUnitario };
                Articulo art2 = new Articulo() { id = 0, nombre = Articulo2_nombre, precioUnitario = Articulo2_precioUnitario };
                lstArt.Add(art);
                lstArt.Add(art2);
                return Ok(service.SaveArticulos(lstArt));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

        [HttpPatch("Articulo")]
        public IActionResult UptdateArticulo(int ID, string Nombre, float PrecioUnitario)
        {
            List<Articulo> lst = service.GetArticulos();
            IActionResult result = BadRequest("Error al Acualizar");
            try
            {
                foreach (Articulo articulo in lst)
                {
                    if(articulo.id == ID)
                    {
                        Articulo art = new Articulo() { id = ID, nombre = Nombre, precioUnitario = PrecioUnitario };
                        result = Ok(service.UpdateArticulo(art));
                    }
                    else
                    {
                        result = BadRequest("No se encontro El articulo de ID:"+ID.ToString());
                    }
                }
                return result;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("Articulos")]
        public IActionResult UpdateArticulos(List<Articulo> lstArt,int Articulo1_ID,string Articulo1_Nombre,float Articulo1_PrecioUnitario,
           int Articulo2_ID,string Articulo2_Nombre,float Articulo2_PrecioUnitario)
        {
            try
            {
                Articulo art = new Articulo() { id = Articulo1_ID, nombre = Articulo1_Nombre, precioUnitario = Articulo1_PrecioUnitario };
                Articulo art2 = new Articulo() { id = Articulo2_ID, nombre = Articulo2_Nombre, precioUnitario = Articulo2_PrecioUnitario };
                return Ok(service.UpdateArticulos(lstArt));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
