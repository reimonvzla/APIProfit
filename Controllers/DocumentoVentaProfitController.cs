namespace APIProfit.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Entidades;
    using Models;
    using Repositorio;

    [Route("api/DocumentoVentaProfit")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class DocumentoVentaProfitController : ControllerBase
    {
        DocumentosVentasRepositorio metodo = new DocumentosVentasRepositorio();
        Response resultado = new Response();

        #region GetDocumentos
        // GET: api/<DocumentoVentaProfitController>
        [HttpGet]
        [Route("GetDocumentos")]
        public IEnumerable<SaDocumentoVenta> GetDocumentos(string Emp)
        {
            return metodo.GetAll(Emp);
        }
        #endregion

        #region GetDocumento
        // GET api/<DocumentoVentaProfitController>/5
        [HttpGet("GetDocumento")]
        public SaDocumentoVenta GetDocumento(string NumDocumento, string CodTipoDocumento, string Emp)
        {
            return metodo.Find(NumDocumento, CodTipoDocumento, Emp);
        }
        #endregion

        #region GetDocumentosxTipo
        // GET api/<DocumentoVentaProfitController>/5
        [HttpGet("GetDocumentosxTipo")]
        public ICollection<SaDocumentoVenta> GetDocumentosxTipo(string CodTipoDocumento, string Emp)
        {
            return metodo.GetAllByTipoDoc(CodTipoDocumento, Emp);
        }
        #endregion

        #region Guardar
        // POST api/<DocumentoVentaProfitController>
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] SaDocumentoVenta documento, string Emp)
        {
            resultado = metodo.Save(documento, Emp);
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
        // PUT api/<DocumentoVentaProfitController>/5
        [HttpPost("Actualizar")]
        public IActionResult Actualizar([FromBody] SaDocumentoVenta documento, string Emp)
        {
            resultado = metodo.Update(documento, Emp);
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

        // DELETE api/<DocumentoVentaProfitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
