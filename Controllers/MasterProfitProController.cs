namespace APIProfit.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Entidades;
    using Repositorio;

    [Route("api/MasterProfitPro")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class MasterProfitProController : ControllerBase
    {
        readonly Utilitarios metodo = new Utilitarios();

        #region GetEmpresas
        // GET: api/<MasterProfitProController>
        [HttpGet]
        [Route("GetEmpresas")]
        public IEnumerable<Empresa> GetEmpresas()
        {
            return metodo.GetEmpresas();
        } 
        #endregion

    }
}
