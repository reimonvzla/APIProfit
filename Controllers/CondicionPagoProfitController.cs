namespace APIProfit.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Entidades;
    using Repositorio;
    using Models;

    [Route("api/CondicionPagoProfit")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class CondicionPagoProfitController : ControllerBase
    {
        readonly CondicionesPagosRepositorio metodo = new CondicionesPagosRepositorio();
        Response resultado = new Response();

        #region GetCondicionesPagos
        // GET: api/<CondicionPagoProfitController>
        [HttpGet]
        [Route("GetCondicionesPago")]
        public IEnumerable<SaCondicionPago> GetCondicionesPago(string Emp)
        {
            return metodo.GetAll(Emp);
        } 
        #endregion

        #region GetCondicionPago
        // GET api/<CondicionPagoProfitController>/5
        [HttpGet("GetCondicionPago")]
        public SaCondicionPago GetCondicionPago(string CodCondicionPago, string Emp)
        {
            return metodo.Find(CodCondicionPago, Emp);
        } 
        #endregion

        #region Guardar
        // POST api/<CondicionPagoProfitController>
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] SaCondicionPago condicionpago, string Emp)
        {
            resultado = metodo.Save(condicionpago, Emp);
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
        // PUT api/<CondicionPagoProfitController>/5
        [HttpPut("Actualizar")]
        public IActionResult Actualizar([FromBody] SaCondicionPago condicionpago, string Emp)
        {
            resultado = metodo.Update(condicionpago, Emp);
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

        // DELETE api/<CondicionPagoProfitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
