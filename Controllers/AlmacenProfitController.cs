namespace APIProfit.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Entidades;
    using Repositorio;

    [Route("api/AlmacenProfit")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class AlmacenProfitController : ControllerBase
    {
        readonly AlmacenesRepositorio metodo = new AlmacenesRepositorio();
        Response resultado = new Response();

        #region GetAlmacenes
        // GET: api/<AlmacenProfitController>
        [HttpGet]
        [Route("GetAlmacenes")]
        public IEnumerable<SaAlmacen> GetAlmacenes(string Emp)
        {
            return metodo.GetAll(Emp);
        } 
        #endregion

        #region GetAlmacen
        // GET api/<AlmacenProfitController>/5
        [HttpGet("GetAlmacen")]
        public SaAlmacen GetAlmacen(string CodAlmacen, string Emp)
        {
            return metodo.Find(CodAlmacen, Emp);
        } 
        #endregion

        #region Guardar
        // POST api/<AlmacenProfitController>
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] SaAlmacen almacen, string Emp)
        {
            resultado = metodo.Save(almacen, Emp);
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
        // PUT api/<AlmacenProfitController>/5
        [HttpPut("Actualizar")]
        public IActionResult Actualizar([FromBody] SaAlmacen almacen, string Emp)
        {
            resultado = metodo.Update(almacen, Emp);
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

        // DELETE api/<AlmacenProfitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
