namespace APIProfit.Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Entidades;
    using Models;

    public class MovimientosCajaRepositorio
    {
        readonly ConexionAlterna conn = new ConexionAlterna();

        #region Find
        public SaMovimientoCaja Find(string origen, string docOrigen, string empresaDB)
        {
            using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));
            return db.SaMovimientoCaja.FirstOrDefault(mv => mv.Origen.Trim() == origen.Trim() && mv.DocNum.Trim() == docOrigen.Trim());
        }
        #endregion

        #region GetAll
        public ICollection<SaMovimientoCaja> GetAll(string empresaDB)
        {
            using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));
            return db.SaMovimientoCaja.ToList();
        } 
        #endregion

        #region Save
        public Response Save(SaMovimientoCaja movcaja, string empresaDB)
        {
            try
            {
                using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));
                FormattableString MovimientoCaja = $@"EXEC pInsertarMovimientoCaja 
                                                    @smov_num = {movcaja.MovNum}
                                                    ,@sdFecha = {movcaja.Fecha}
                                                    ,@sdescrip = {movcaja.Descrip}
                                                    ,@scod_caja = {movcaja.CodCaja}
                                                    ,@detasa = {movcaja.Tasa}
                                                    ,@stipo_mov = {movcaja.TipoMov}
                                                    ,@sforma_pag = {movcaja.FormaPag}
                                                    ,@snum_pago = NULL
                                                    ,@sco_ban = {movcaja.CoBan}
                                                    ,@sco_tar = {movcaja.CoTar}
                                                    ,@sco_vale = {movcaja.CoVale}
                                                    ,@sco_cta_ingr_egr = {movcaja.CoCtaIngrEgr}
                                                    ,@demonto = {movcaja.MontoD}
                                                    ,@bsaldo_ini = 0
                                                    ,@sorigen = 'COBRO'
                                                    ,@sdoc_num = {movcaja.DocNum}
                                                    ,@sDep_Num = NULL
                                                    ,@banulado = 0
                                                    ,@bDepositado = 0
                                                    ,@bConciliado = 0
                                                    ,@btransferido = 0
                                                    ,@smov_nro = NULL
                                                    ,@sdfecha_che = {movcaja.FechaChe}
                                                    ,@sdis_cen = NULL
                                                    ,@sCampo1 = {movcaja.Campo1}
                                                    ,@sCampo2 = {movcaja.Campo2}
                                                    ,@sCampo3 = {movcaja.Campo3}
                                                    ,@sCampo4 = {movcaja.Campo4}
                                                    ,@sCampo5 = {movcaja.Campo5}
                                                    ,@sCampo6 = {movcaja.Campo6}
                                                    ,@sCampo7 = {movcaja.Campo7}
                                                    ,@sCampo8 = {movcaja.Campo8}
                                                    ,@sRevisado = NULL
                                                    ,@sTrasnfe = NULL
                                                    ,@sco_sucu_in = {movcaja.CoSucuIn}
                                                    ,@sco_us_in = {movcaja.CoUsIn}
                                                    ,@sMaquina = {string.Empty}";

                int resultMovCaja = db.Database.ExecuteSqlInterpolated(MovimientoCaja);

                return new Response { Status = "OK", Message = "Transacción realizada con éxito." };
            }
            catch (Exception ex)
            {
                return new Response { Status = "ERROR", Message = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message };
            }
        } 
        #endregion
    
    }
}
