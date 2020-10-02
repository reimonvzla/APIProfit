namespace APIProfit.Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Entidades;
    using Models;

    public class MovimientosBancoRepositorio
    {
        readonly ConexionAlterna conn = new ConexionAlterna();

        #region Find
        public SaMovimientoBanco Find(string origen, string cobPag, string empresaDB)
        {
            using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));
            return db.SaMovimientoBanco.FirstOrDefault(mb => mb.Origen.Trim() == origen.Trim() && mb.CobPag.Trim() == cobPag.Trim());
        } 
        #endregion

        #region Save
        public Response Save(SaMovimientoBanco movbanco, string empresaDB)
        {
            try
            {
                using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));

                FormattableString MovimientoBanco = $@"EXEC pInsertarMovimientoBanco 
                                                            @sMov_Num={movbanco.MovNum}
                                                            ,@sDescrip={movbanco.Descrip}
                                                            ,@sCod_Cta={movbanco.CodCta}
                                                            ,@sdFecha={movbanco.Fecha}
                                                            ,@deTasa={movbanco.Tasa}
                                                            ,@sTipo_Op={movbanco.TipoOp}
                                                            ,@sDoc_Num={movbanco.DocNum}
                                                            ,@deMonto={movbanco.MontoD}
                                                            ,@sco_cta_ingr_egr={movbanco.CoCtaIngrEgr}
                                                            ,@sOrigen='COBRO'
                                                            ,@sCob_Pag={movbanco.CobPag}
                                                            ,@deIDB=0,@sDep_Num=NULL
                                                            ,@bAnulado=0
                                                            ,@bConciliado=0
                                                            ,@bSaldo_Ini=0
                                                            ,@bOri_Dep=0
                                                            ,@iDep_Con=0
                                                            ,@sdFec_Con=NULL
                                                            ,@sCod_IngBen=NULL
                                                            ,@sdFecha_Che={movbanco.FechaChe}
                                                            ,@sDis_Cen=NULL
                                                            ,@iNro_Transf_Nomi=NULL
                                                            ,@sCampo1={movbanco.Campo1}
                                                            ,@sCampo2={movbanco.Campo2}
                                                            ,@sCampo3={movbanco.Campo3}
                                                            ,@sCampo4={movbanco.Campo4}
                                                            ,@sCampo5={movbanco.Campo5}
                                                            ,@sCampo6={movbanco.Campo6}
                                                            ,@sCampo7={movbanco.Campo7}
                                                            ,@sCampo8={movbanco.Campo8}
                                                            ,@sRevisado=NULL
                                                            ,@sTrasnfe=NULL
                                                            ,@sco_sucu_in={movbanco.CoSucuIn}
                                                            ,@sco_us_in={movbanco.CoUsIn}
                                                            ,@sMaquina={string.Empty}";

                int resultMovBanco = db.Database.ExecuteSqlInterpolated(MovimientoBanco);

                return new Response { Status = "OK", Message = "Transacción realizada con éxito." };
            }
            catch (Exception ex)
            {
                return new Response { Status = "ERROR", Message = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message };
            }
        }
        #endregion

        #region GetAll
        public ICollection<SaMovimientoBanco> GetAll(string empresaDB)
        {
            using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));
            return db.SaMovimientoBanco.ToList();
        } 
        #endregion

    }
}
