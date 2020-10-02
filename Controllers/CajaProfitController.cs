namespace APIProfit.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Entidades;
    using Models;
    using Repositorio;

    [Route("api/CajaProfit")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class CajaProfitController : ControllerBase
    {
        readonly CajasRepositorio metodo = new CajasRepositorio();
        Response resultado = new Response();

        #region GetCajas
        // GET: api/<CajaProfitController>
        [HttpGet]
        [Route("GetCajas")]
        public IEnumerable<SaCaja> GetCajas(string Emp)
        {
            return metodo.GetAll(Emp);
        }
        #endregion

        #region GetCaja
        // GET api/<CajaProfitController>/5
        [HttpGet("GetCaja")]
        public SaCaja GetCaja(string CodCaja,string Emp)
        {
            return metodo.Find(CodCaja, Emp);
        }
        #endregion

        #region Guardar
        // POST api/<CajaProfitController>
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] SaCaja caja, string Emp)
        {
            resultado=metodo.Save(caja, Emp);
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
        // PUT api/<CajaProfitController>/5
        [HttpPut("Actualizar")]
        public IActionResult Actualizar([FromBody] SaCaja caja, string Emp)
        {
            resultado = metodo.Update(caja, Emp);
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

        // DELETE api/<CajaProfitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
