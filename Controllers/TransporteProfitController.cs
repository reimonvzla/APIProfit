namespace APIProfit.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Entidades;
    using Models;
    using Repositorio;

    [Route("api/TransporteProfit")]
    [ApiController]
    [EnableCors("AllowOrigin")]

    public class TransporteProfitController : ControllerBase
    {
        readonly TransportesRepositorio metodo = new TransportesRepositorio();
        Response resultado = new Response();

        #region GetTransportes
        // GET: api/<TransporteProfitController>
        [HttpGet]
        [Route("GetTransportes")]
        public IEnumerable<SaTransporte> GetTransportes(string Emp)
        {
            return metodo.GetAll(Emp);
        } 
        #endregion

        #region GetTransporte
        // GET api/<TransporteProfitController>/5
        [HttpGet("GetTransporte")]
        public SaTransporte GetTransporte(string CodTransporte, string Emp)
        {
            return metodo.Find(CodTransporte, Emp);
        }

        #endregion
        
        #region Guardar
        // POST api/<TransporteProfitController>
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] SaTransporte transporte, string Emp)
        {
            resultado = metodo.Save(transporte, Emp);
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
        // PUT api/<TransporteProfitController>/5
        [HttpPut("Actualizar")]
        public IActionResult Actualizar([FromBody] SaTransporte transporte, string Emp)
        {
            resultado = metodo.Update(transporte, Emp);
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

        // DELETE api/<TransporteProfitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
