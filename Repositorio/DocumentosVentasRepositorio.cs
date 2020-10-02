namespace APIProfit.Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Entidades;
    using Models;

    public class DocumentosVentasRepositorio
    {
        readonly ConexionAlterna conn = new ConexionAlterna();
        
        #region Find
        public SaDocumentoVenta Find(string key, string coTipoDoc, string empresaDB)
        {
            using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));
            return db.SaDocumentoVenta.FirstOrDefault(dv => dv.NroDoc.Trim() == key.Trim() && dv.CoTipoDoc.Trim() == coTipoDoc.Trim());
        } 
        #endregion

        #region GetAll
        public ICollection<SaDocumentoVenta> GetAll(string empresaDB)
        {
            using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));
            return db.SaDocumentoVenta.ToList();
        } 
        #endregion

        #region GetAllByTipoDoc
        public ICollection<SaDocumentoVenta> GetAllByTipoDoc(string coTipoDoc, string empresaDB)
        {
            using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));
            return db.SaDocumentoVenta.Where(dv => dv.CoTipoDoc.Trim() == coTipoDoc.Trim()).ToList();
        } 
        #endregion

        #region Save
        public Response Save(SaDocumentoVenta item, string empresaDB)
        {
            try
            {
                using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));
                string codigoConsecutivo = string.Empty;

                switch (item.CoTipoDoc)
                {
                    case "ADEL":
                        codigoConsecutivo = "DOC_VEN_ADEL";
                        break;
                    default:
                        break;
                }
                string numero = new Utilitarios().GetProximoNumero(codigoConsecutivo, item.CoSucuIn, empresaDB);

                item.NroDoc = numero;

                db.Entry(item).State = EntityState.Added;
                db.SaveChanges();
                return new Response { Status = "OK", Message = "Transacción realizada con éxito.", FacturaID = item.NroDoc.Trim() };
            }
            catch (Exception ex)
            {
                return new Response { Status = "ERROR", Message = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message };
            }
        } 
        #endregion

        #region Update
        public Response Update(SaDocumentoVenta item, string empresaDB)
        {
            try
            {
                using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));
                
                FormattableString DocumentoActualizar = $@"EXEC pActualizarDocumentoVenta 
                                                    @sNro_Doc = {item.NroDoc}
                                                    ,@sNro_DocOri = {item.NroDoc}
                                                    ,@sCo_Tipo_DocOri = {item.CoTipoDoc}
                                                    ,@sCo_Tipo_Doc = {item.CoTipoDoc}
                                                    ,@sDoc_Orig = {item.DocOrig}
                                                    ,@sCo_Cli = {item.CoCli}
                                                    ,@sCo_Mone = {item.CoMone}
                                                    ,@sdFec_Reg = {item.FecReg}
                                                    ,@sdFec_Emis = {item.FecEmis}
                                                    ,@bAnulado = {item.Anulado}
                                                    ,@deAdicional = {item.Adicional}
                                                    ,@sMov_Ban = {item.MovBan}
                                                    ,@bAut = {item.Aut}
                                                    ,@bContrib = {item.Contrib}
                                                    ,@sObserva = {item.Observa}
                                                    ,@sNro_Orig = {item.NroOrig}
                                                    ,@sNro_Che = {item.NroChe}
                                                    ,@sCo_Ven = {item.CoVen}
                                                    ,@sCo_Cta_Ingr_Egr = {item.CoCtaIngrEgr}
                                                    ,@deTasa = {item.Tasa}
                                                    ,@sTipo_Imp = {item.TipoImp}
                                                    ,@deTotal_Bruto = {item.TotalBruto}
                                                    ,@deTotal_Neto = {item.TotalNeto}
                                                    ,@deMonto_Reca = {item.MontoReca}
                                                    ,@deMonto_Imp = {item.MontoImp}
                                                    ,@deMonto_Imp2 = {item.MontoImp2}
                                                    ,@deMonto_Imp3 = {item.MontoImp3}
                                                    ,@deSaldo = {item.Saldo}
                                                    ,@sN_Control = {item.NControl}
                                                    ,@sNum_Comprobante = {item.NumComprobante}
                                                    ,@sDis_Cen = {item.DisCen}
                                                    ,@deComis1 = {item.Comis1}
                                                    ,@deComis2 = {item.Comis2}
                                                    ,@deComis3 = {item.Comis3}
                                                    ,@deComis4 = {item.Comis4}
                                                    ,@deOtros1 = {item.Otros1}
                                                    ,@deOtros2 = {item.Otros2}
                                                    ,@deOtros3 = {item.Otros3}
                                                    ,@sPorc_Desc_Glob = {item.PorcDescGlob}
                                                    ,@deMonto_Desc_Glob = {item.MontoDescGlob}
                                                    ,@sPorc_Reca = {item.PorcReca}
                                                    ,@dePorc_Imp = {item.PorcImp}
                                                    ,@dePorc_Imp2 = {item.PorcImp2}
                                                    ,@dePorc_Imp3 = {item.PorcImp3}
                                                    ,@sSalestax = {item.Salestax}
                                                    ,@bVen_Ter = {item.VenTer}
                                                    ,@sdFec_Venc = {item.FecVenc}
                                                    ,@deComis5 = {item.Comis5}
                                                    ,@deComis6 = {item.Comis6}
                                                    ,@sImpFis = {item.Impfis}
                                                    ,@sImpFisFac = {item.Impfisfac}
                                                    ,@sImp_Nro_Z = {item.ImpNroZ}
                                                    ,@iTipo_Origen = {item.TipoOrigen}
                                                    ,@sCampo1 = {item.Campo1}
                                                    ,@sCampo2 = {item.Campo2}
                                                    ,@sCampo3 = {item.Campo3}
                                                    ,@sCampo4 = {item.Campo4}
                                                    ,@sCampo5 = {item.Campo5}
                                                    ,@sCampo6 = {item.Campo6}
                                                    ,@sCampo7 = {item.Campo7}
                                                    ,@sCampo8 = {item.Campo8}
                                                    ,@sRevisado = {item.Revisado}
                                                    ,@sTrasnfe = {item.Trasnfe}
                                                    ,@tsvalidador = {item.Validador}
                                                    ,@sco_sucu_mo = {item.CoSucuMo}
                                                    ,@sco_us_mo = {item.CoUsMo}
                                                    ,@growguid = {null}
                                                    ,@sMaquina = {string.Empty}
                                                    ,@sCampos = '{item.NroDoc}'";

                int resultSaldoDoc = db.Database.ExecuteSqlInterpolated(DocumentoActualizar);

                return new Response { Status = "OK", Message = "Actualización realizada con éxito." };
            }
            catch (Exception ex)
            {
                return new Response { Status = "ERROR", Message = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message };
            }
        }
        #endregion
    }
}