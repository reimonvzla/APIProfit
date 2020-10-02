namespace APIProfit.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Entidades;
    using Repositorio;
    using Models;

    [Route("api/VendedorProfit")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class VendedorProfitController : ControllerBase
    {
        readonly VendedoresRepositorio metodo = new VendedoresRepositorio();
        Response resultado = new Response();

        #region GetVendedores
        // GET: api/<VendedorProfitController>
        [HttpGet]
        [Route("GetVendedores")]
        public IEnumerable<SaVendedor> GetVendedores(string Emp)
        {
            return metodo.GetAll(Emp);
        } 
        #endregion

        #region GetVendedor
        // GET api/<VendedorProfitController>/5
        [HttpGet("GetVendedor")]
        public SaVendedor GetVendedor(string CodVendedor, string Emp)
        {
            return metodo.Find(CodVendedor, Emp);
        }
        #endregion

        #region Guardar
        // POST api/<VendedorProfitController>
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] SaVendedor vendedor, string Emp)
        {
            resultado = metodo.Save(vendedor, Emp);
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
        // PUT api/<VendedorProfitController>/5
        [HttpPut("Actualizar")]
        public IActionResult Actualizar([FromBody] SaVendedor vendedor, string Emp)
        {
            resultado = metodo.Update(vendedor, Emp);
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

        // DELETE api/<VendedorProfitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
