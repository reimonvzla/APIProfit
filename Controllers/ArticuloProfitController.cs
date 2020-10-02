namespace APIProfit.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Entidades;
    using Repositorio;
    using Models;

    [Route("api/ArticuloProfit")]
    [ApiController]
    [EnableCors("AllowOrigin")]

    public class ArticuloProfitController : ControllerBase
    {
        readonly ArticulosRepositorio metodo = new ArticulosRepositorio();
        Response resultado = new Response();

        #region GetArticulos
        // GET: api/<ArticuloProfitController>
        [HttpGet]
        [Route("GetArticulos")]
        public IEnumerable<SaArticulo> GetArticulos(string Emp)
        {
            return metodo.GetAll(Emp);
        }
        #endregion

        #region FindArticulo
        // GET api/<ArticuloProfitController>/5
        [HttpGet("FindArticulo")]
        public SaArticulo FindArticulo(string codArticulo,string Emp)
        {
            return metodo.Find(codArticulo, Emp);
        }
        #endregion

        #region Guardar
        // POST api/<ArticuloProfitController>
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] SaArticulo articulo,string Emp)
        {
            articulo.CoUsIn = "999";
            articulo.FeUsIn = DateTime.Now;

            resultado = metodo.Save(articulo, Emp);

            if (resultado.Status == "OK")
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest(resultado);
            }
        }
        #endregion

        #region Actualizar
        // PUT api/<ArticuloProfitController>/5
        [HttpPut("Actualizar")]
        public IActionResult Actualizar([FromBody] SaArticulo articulo,string Emp)
        {
            articulo.CoUsMo = "999";
            articulo.FeUsMo = DateTime.Now;
            resultado = metodo.Update(articulo, Emp);

            if (resultado.Status == "OK")
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest(resultado);
            }
        }
        #endregion

        #region Eliminar
        // DELETE api/<ArticuloProfitController>/5
        [HttpDelete("Eliminar")]
        public IActionResult Eliminar(string codArticulo,string Emp)
        {
            resultado = metodo.Remove(codArticulo, "999",Emp);

            if (resultado.Status == "OK")
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest(resultado);
            }
        }
        #endregion
    }
}
