namespace APIProfit.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Entidades;
    using Repositorio;
    using Models;

    [Route("api/ClienteProfit")]
    [ApiController]
    [EnableCors("AllowOrigin")]

    public class ClienteProfitController : ControllerBase
    {
        readonly ClientesRepositorio metodo = new ClientesRepositorio();
        Response resultado = new Response();

        #region GetClientes
        // GET: api/<ClienteProfitController>
        [HttpGet]
        [Route("GetClientes")]
        public IEnumerable<SaCliente> GetClientes(string Emp)
        {
            return metodo.GetAll(Emp);
        }
        #endregion

        #region GetCliente
        // GET api/<ClienteProfitController>/5
        [HttpGet("GetCliente")]
        public SaCliente GetCliente(string codCliente, string Emp)
        {
            return metodo.Find(codCliente, Emp);
        }
        #endregion

        #region GetCuentasIngresoEgreso
        [HttpGet]
        [Route("GetCuentasIngresoEgreso")]
        public IEnumerable<SaCuentaIngEgr> GetCuentasIngresoEgreso(string Emp)
        {
            return metodo.GetAllCtaIngrEgre(Emp);
        }
        #endregion

        #region GetTiposClientes
        [HttpGet]
        [Route("GetTiposClientes")]
        public IEnumerable<SaTipoCliente> GetTiposClientes(string Emp)
        {
            return metodo.GetAllTipoCliente(Emp);
        }
        #endregion

        #region GetSegmentos
        [HttpGet]
        [Route("GetSegmentos")]
        public IEnumerable<SaSegmento> GetSegmentos(string Emp)
        {
            return metodo.GetAllSegmentos(Emp);
        }
        #endregion

        #region GetZonas
        [HttpGet]
        [Route("GetZonas")]
        public IEnumerable<SaZona> GetZonas(string Emp)
        {
            return metodo.GetAllZonas(Emp);
        }
        #endregion

        #region Guardar
        // POST api/<ClienteProfitController>
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] SaCliente cliente, string Emp)
        {
            cliente.CoUsIn = "999";
            cliente.FeUsIn = DateTime.Now;
            resultado = metodo.Save(cliente, Emp);

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
        // PUT api/<ClienteProfitController>/5
        [HttpPut("Actualizar")]
        public IActionResult Actualizar([FromBody] SaCliente cliente, string Emp)
        {
            cliente.CoUsMo = "999";
            cliente.FeUsMo = DateTime.Now;
            resultado = metodo.Update(cliente, Emp);

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
        // DELETE api/<ClienteProfitController>/5
        [HttpDelete("Eliminar")]
        public IActionResult Eliminar(string codCliente, string Emp)
        {
            resultado = metodo.Remove(codCliente, "999", Emp);

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
