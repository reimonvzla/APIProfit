namespace APIProfit.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Entidades;
    using Models;
    using Repositorio;

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class SucursalProfitController : ControllerBase
    {
        readonly SucursalesRepositorio metodo = new SucursalesRepositorio();
        Response resultado = new Response();

        #region GetSucursales
        // GET: api/<SucursalProfitController>
        [HttpGet]
        [Route("GetSucursales")]
        public IEnumerable<SaSucursal> GetSucursales(string Emp)
        {
            return metodo.GetAll(Emp);
        }
        #endregion

        #region MyRegion
        // GET api/<SucursalProfitController>/5
        [HttpGet("GetSucursal")]
        public SaSucursal GetSucursal(string CodSucursal, string Emp)
        {
            return metodo.Find(CodSucursal, Emp);
        }
        #endregion

        #region Guardar
        // POST api/<SucursalProfitController>
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] SaSucursal sucursal, string Emp)
        {
            resultado = metodo.Save(sucursal, Emp);
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
        // PUT api/<SucursalProfitController>/5
        [HttpPut("Actualizar")]
        public IActionResult Actualizar([FromBody] SaSucursal sucursal, string Emp)
        {
            resultado = metodo.Update(sucursal, Emp);
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

        // DELETE api/<SucursalProfitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
