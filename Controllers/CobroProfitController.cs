namespace APIProfit.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Entidades;
    using Repositorio;
    using Models;

    [Route("api/CobroProfit")]
    [ApiController]
    [EnableCors("AllowOrigin")]

    public class CobroProfitController : ControllerBase
    {
        readonly CobrosRepositorio metodo = new CobrosRepositorio();
        Response resultado = new Response();

        #region GetCobros
        // GET: api/<CobroProfitController>
        [HttpGet]
        [Route("GetCobros")]
        public IEnumerable<SaCobro> GetCobros(string Emp)
        {
            return metodo.GetCobros(Emp);
        }
        #endregion

        #region GetCobro
        // GET api/<CobroProfitController>/5
        [HttpGet("GetCobro")]
        public SaCobro GetCobro(string NumCobro, string Emp)
        {
            return metodo.Find(NumCobro, Emp);
        }
        #endregion

        #region Guardar
        // POST api/<CobroProfitController>
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] EncabCobro cobro, bool isAdelanto,string Emp)
        {
            cobro.CoUsIn = "999";
            cobro.FeUsIn = DateTime.Now;

            resultado = metodo.Guardar(cobro,isAdelanto, Emp);
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
        // PUT api/<CobroProfitController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        #endregion

        #region Eliminar
        // DELETE api/<CobroProfitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion

    }
}
