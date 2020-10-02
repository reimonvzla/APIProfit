namespace APIProfit.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Entidades;
    using Models;
    using Repositorio;

    [Route("api/FacturaVentaProfit")]
    [ApiController]
    [EnableCors("AllowOrigin")]

    public class FacturaVentaProfitController : ControllerBase
    {
        readonly FacturasVentasRepositorio metodo = new FacturasVentasRepositorio();
        Response resultado = new Response();

        #region GetFacturas
        // GET: api/<FacturaVentaProfitController>
        [HttpGet]
        [Route("GetFacturas")]
        public IEnumerable<SaFacturaVenta> GetFacturas(string Emp)
        {
            var result = metodo.GetFacturas(Emp);
            return result;
        }
        #endregion

        #region GetFactura
        // GET api/<FacturaVentaProfitController>/5
        [HttpGet("GetFactura")]
        public SaFacturaVenta GetFactura(string NumFactura, string Emp)
        {
            return metodo.Find(NumFactura, Emp);
        }
        #endregion

        #region Guardar
        // POST api/<FacturaVentaProfitController>
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] EncabFacturaVenta factura, string Emp)
        {
            factura.CoUsIn = "999";
            factura.FeUsIn = DateTime.Now;
            resultado = metodo.Guardar(factura, Emp);
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
        // PUT api/<FacturaVentaProfitController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        #endregion

        #region Eliminar
        // DELETE api/<FacturaVentaProfitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion    

    }
}
