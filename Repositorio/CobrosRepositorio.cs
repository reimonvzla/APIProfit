namespace APIProfit.Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Linq;
    using Entidades;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CobrosRepositorio
    {
        readonly ConexionAlterna conn = new ConexionAlterna();
        readonly Utilitarios utilitarios = new Utilitarios();

        #region GetCobros
        public IEnumerable<SaCobro> GetCobros(string empresaDB)
        {
            using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));

            var Qry = db.SaCobro.Select(c => new SaCobro()
            {
                CobNum = c.CobNum,
                Recibo = c.Recibo,
                Descrip = c.Descrip,
                CoCli = c.CoCli,
                CoVen = c.CoVen,
                CoMone = c.CoMone,
                Tasa = c.Tasa,
                Fecha = c.Fecha,
                Anulado = c.Anulado,
                Monto = c.Monto,
                DisCen = c.DisCen,
                Feccom = c.Feccom,
                Numcom = c.Numcom,
                Campo1 = c.Campo1,
                Campo2 = c.Campo2,
                Campo3 = c.Campo3,
                Campo4 = c.Campo4,
                Campo5 = c.Campo5,
                Campo6 = c.Campo6,
                Campo7 = c.Campo7,
                Campo8 = c.Campo8,
                CoUsIn = c.CoUsIn,
                CoSucuIn = c.CoSucuIn,
                FeUsIn = c.FeUsIn,
                CoUsMo = c.CoUsMo,
                CoSucuMo = c.CoSucuMo,
                FeUsMo = c.FeUsMo,
                Revisado = c.Revisado,
                Trasnfe = c.Trasnfe,
                Validador = c.Validador,
                Rowguid = c.Rowguid,
                SaCobroDocReng = c.SaCobroDocReng.Select(i => new SaCobroDocReng()
                {
                    RengNum = i.RengNum,
                    CobNum = i.CobNum,
                    CoTipoDoc = i.CoTipoDoc,
                    NroDoc = i.NroDoc,
                    MontCob = i.MontCob,
                    DpcobroPorcDesc = i.DpcobroPorcDesc,
                    DpcobroMonto = i.DpcobroMonto,
                    MontoRetencionIva = i.MontoRetencionIva,
                    MontoRetencion = i.MontoRetencion,
                    RetenTerceroRowguidOri = i.RetenTerceroRowguidOri,
                    TipoDoc = i.TipoDoc,
                    NumDoc = i.NumDoc,
                    RowguidRengOri = i.RowguidRengOri,
                    TipoOrigen = i.TipoOrigen,
                    GenOrigen = i.GenOrigen,
                    CoSucuIn = i.CoSucuIn,
                    CoUsIn = i.CoUsIn,
                    FeUsIn = i.FeUsIn,
                    CoSucuMo = i.CoSucuMo,
                    CoUsMo = i.CoUsMo,
                    FeUsMo = i.FeUsMo,
                    Trasnfe = i.Trasnfe,
                    Revisado = i.Revisado,
                    Rowguid = i.Rowguid,
                }).ToList(),
                SaCobroTpreng = c.SaCobroTpreng
            }).ToList();

            return Qry;
        }
        #endregion

        #region Find (por numero de cobro)
        public SaCobro Find(string key, string empresaDB)
        {
            using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));

            var Qry = db.SaCobro.Select(c => new SaCobro()
            {
                CobNum = c.CobNum,
                Recibo = c.Recibo,
                Descrip = c.Descrip,
                CoCli = c.CoCli,
                CoVen = c.CoVen,
                CoMone = c.CoMone,
                Tasa = c.Tasa,
                Fecha = c.Fecha,
                Anulado = c.Anulado,
                Monto = c.Monto,
                DisCen = c.DisCen,
                Feccom = c.Feccom,
                Numcom = c.Numcom,
                Campo1 = c.Campo1,
                Campo2 = c.Campo2,
                Campo3 = c.Campo3,
                Campo4 = c.Campo4,
                Campo5 = c.Campo5,
                Campo6 = c.Campo6,
                Campo7 = c.Campo7,
                Campo8 = c.Campo8,
                CoUsIn = c.CoUsIn,
                CoSucuIn = c.CoSucuIn,
                FeUsIn = c.FeUsIn,
                CoUsMo = c.CoUsMo,
                CoSucuMo = c.CoSucuMo,
                FeUsMo = c.FeUsMo,
                Revisado = c.Revisado,
                Trasnfe = c.Trasnfe,
                Validador = c.Validador,
                Rowguid = c.Rowguid,
                SaCobroDocReng = c.SaCobroDocReng.Select(i => new SaCobroDocReng()
                {
                    RengNum = i.RengNum,
                    CobNum = i.CobNum,
                    CoTipoDoc = i.CoTipoDoc,
                    NroDoc = i.NroDoc,
                    MontCob = i.MontCob,
                    DpcobroPorcDesc = i.DpcobroPorcDesc,
                    DpcobroMonto = i.DpcobroMonto,
                    MontoRetencionIva = i.MontoRetencionIva,
                    MontoRetencion = i.MontoRetencion,
                    RetenTerceroRowguidOri = i.RetenTerceroRowguidOri,
                    TipoDoc = i.TipoDoc,
                    NumDoc = i.NumDoc,
                    RowguidRengOri = i.RowguidRengOri,
                    TipoOrigen = i.TipoOrigen,
                    GenOrigen = i.GenOrigen,
                    CoSucuIn = i.CoSucuIn,
                    CoUsIn = i.CoUsIn,
                    FeUsIn = i.FeUsIn,
                    CoSucuMo = i.CoSucuMo,
                    CoUsMo = i.CoUsMo,
                    FeUsMo = i.FeUsMo,
                    Trasnfe = i.Trasnfe,
                    Revisado = i.Revisado,
                    Rowguid = i.Rowguid,
                }).ToList(),
                SaCobroTpreng = c.SaCobroTpreng
            }).FirstOrDefault(c => c.CobNum == key);

            if (Qry == null) return null;
            return Qry;
        }
        #endregion

        #region Guardar
        public Response Guardar(EncabCobro cobro, bool isAdelanto, string empresaDB)
        {
            try
            {
                using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));

                /*movi devuelve el resultado de la transaccion sea movCaja o movBanco.*/
                Response movi = new Response();

                #region Consecutivo numero de cobro.
                string codigoConsecutivoCobro = "COBRO";
                string numeroCobro = utilitarios.GetProximoNumero(codigoConsecutivoCobro, cobro.CoSucuIn, empresaDB);
                string numeroCajaBanco = null;
                #endregion

                #region Cuenta ingreso/egreso del cliente para movimiento de caja/banco
                var CoCtaIngrEgr = new ClientesRepositorio().Find(cobro.CoCli, empresaDB).CoCtaIngrEgr;
                //db.SaCliente.FirstOrDefault(c => c.CoCli == cobro.CoCli).CoCtaIngrEgr;
                #endregion

                #region Caja/Banco
                var ParamModulo = "COBRO";

                foreach (var i in cobro.TipoCobroTpreng)
                {
                    #region Actualizar saldo (Caja/Banco)
                    decimal resultSaldo = 0;

                    var conn = db.Database.GetDbConnection();
                    conn.Open();
                    var command = conn.CreateCommand();
                    string query = $@"EXEC pSaldoActualizar @sCodigo = '{(string.IsNullOrEmpty(i.CodCta) ? i.CodCaja : i.CodCta)}',@sForma_Pag = '{i.FormaPag}',@sTipoSaldo = '{i.FormaPag}',@deMonto = {i.MontDoc.ToString().Replace(',', '.')},@bSumarSaldo = {true},@sModulo = {$"N'{ParamModulo}'"},@bPermiteSaldoNegativo = {false}";
                    command.CommandText = query;
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        resultSaldo = reader.GetDecimal(0);
                    }
                    reader.Close();
                    conn.Close();
                    #endregion

                    #region Insertar Movimiento (Banco/Caja)

                    #region Consecutivo de Numero de Caja/Banco
                    string codigoConsecutivoCajaBanco = (string.IsNullOrEmpty(i.CodCta) ? "MOVC_NUM" : "MOVB_NUM");
                    numeroCajaBanco = utilitarios.GetProximoNumero(codigoConsecutivoCajaBanco, cobro.CoSucuIn, empresaDB);
                    #endregion

                    if (string.IsNullOrEmpty(i.CodCta))
                    {
                        #region Movimiento de caja
                        SaMovimientoCaja movCaja = new SaMovimientoCaja
                        {
                            MovNum = numeroCajaBanco,
                            Fecha = cobro.Fecha,
                            Descrip = $"Cobro {numeroCobro}",
                            CodCaja = i.CodCaja,
                            Tasa = cobro.Tasa,
                            TipoMov = "I",
                            FormaPag = i.FormaPag,
                            NumPago = null,
                            CoBan = i.CoBan,
                            CoTar = i.CoTar,
                            CoVale = i.CoVale,
                            CoCtaIngrEgr = CoCtaIngrEgr,
                            MontoD = i.MontDoc,
                            Origen = "COBRO",
                            DocNum = numeroCobro,
                            FechaChe = i.FechaChe,
                            CoSucuIn = cobro.CoSucuIn,
                            CoUsIn = cobro.CoUsIn
                        };

                        movi = new MovimientosCajaRepositorio().Save(movCaja, empresaDB);

                        #region Inutilizable
                        //FormattableString MovimientoCaja = $@"EXEC {empresaDB.Trim()}.dbo.pInsertarMovimientoCaja 
                        //                            @smov_num = {numeroCajaBanco}
                        //                            ,@sdFecha = {cobro.Fecha}
                        //                            ,@sdescrip = {$"Cobro {numeroCobro}"}
                        //                            ,@scod_caja = {i.CodCaja}
                        //                            ,@detasa = {cobro.Tasa}
                        //                            ,@stipo_mov = 'I'
                        //                            ,@sforma_pag = {i.FormaPag}
                        //                            ,@snum_pago = NULL
                        //                            ,@sco_ban = {i.CoBan}
                        //                            ,@sco_tar = {i.CoTar}
                        //                            ,@sco_vale = {i.CoVale}
                        //                            ,@sco_cta_ingr_egr = {CoCtaIngrEgr}
                        //                            ,@demonto = {i.MontDoc}
                        //                            ,@bsaldo_ini = 0
                        //                            ,@sorigen = 'COBRO'
                        //                            ,@sdoc_num = {numeroCobro}
                        //                            ,@sDep_Num = NULL
                        //                            ,@banulado = 0
                        //                            ,@bDepositado = 0
                        //                            ,@bConciliado = 0
                        //                            ,@btransferido = 0
                        //                            ,@smov_nro = NULL
                        //                            ,@sdfecha_che = {i.FechaChe}
                        //                            ,@sdis_cen = NULL
                        //                            ,@sCampo1 = {cobro.Campo1}
                        //                            ,@sCampo2 = {cobro.Campo2}
                        //                            ,@sCampo3 = {cobro.Campo3}
                        //                            ,@sCampo4 = {cobro.Campo4}
                        //                            ,@sCampo5 = {cobro.Campo5}
                        //                            ,@sCampo6 = {cobro.Campo6}
                        //                            ,@sCampo7 = {cobro.Campo7}
                        //                            ,@sCampo8 = {cobro.Campo8}
                        //                            ,@sRevisado = NULL
                        //                            ,@sTrasnfe = NULL
                        //                            ,@sco_sucu_in = {cobro.CoSucuIn}
                        //                            ,@sco_us_in = {cobro.CoUsIn}
                        //                            ,@sMaquina = {cobro.Maquina}";

                        //int resultMovCaja = db.Database.ExecuteSqlInterpolated(MovimientoCaja);

                        #endregion                        #endregion

                        #endregion
                    }
                    else
                    {
                        #region Movimiento de banco
                        SaMovimientoBanco movBanco = new SaMovimientoBanco
                        {
                            MovNum = numeroCajaBanco,
                            Descrip = $"Cobro {numeroCobro}",
                            CodCta = i.CodCta,
                            Fecha = cobro.Fecha,
                            Tasa = cobro.Tasa,
                            TipoOp = i.FormaPag,
                            DocNum = i.NumDoc,
                            MontoD = i.MontDoc,
                            CoCtaIngrEgr = CoCtaIngrEgr,
                            Origen = "COBRO",
                            CobPag = numeroCobro,
                            FechaChe = i.FechaChe,
                            CoSucuIn = cobro.CoSucuIn,
                            CoUsIn = cobro.CoUsIn
                        };

                        #region Inutilizable
                        //FormattableString MovimientoBanco = $@"EXEC {empresaDB.Trim()}.dbo.pInsertarMovimientoBanco 
                        //                                    @sMov_Num={numeroCajaBanco}
                        //                                    ,@sDescrip={$"Cobro {numeroCobro}"}
                        //                                    ,@sCod_Cta={i.CodCta}
                        //                                    ,@sdFecha={cobro.Fecha}
                        //                                    ,@deTasa={cobro.Tasa}
                        //                                    ,@sTipo_Op={i.FormaPag}
                        //                                    ,@sDoc_Num={i.NumDoc}
                        //                                    ,@deMonto={i.MontDoc}
                        //                                    ,@sco_cta_ingr_egr={CoCtaIngrEgr}
                        //                                    ,@sOrigen='COBRO'
                        //                                    ,@sCob_Pag={numeroCobro}
                        //                                    ,@deIDB=0,@sDep_Num=NULL
                        //                                    ,@bAnulado=0
                        //                                    ,@bConciliado=0
                        //                                    ,@bSaldo_Ini=0
                        //                                    ,@bOri_Dep=0
                        //                                    ,@iDep_Con=0
                        //                                    ,@sdFec_Con=NULL
                        //                                    ,@sCod_IngBen=NULL
                        //                                    ,@sdFecha_Che={i.FechaChe}
                        //                                    ,@sDis_Cen=NULL
                        //                                    ,@iNro_Transf_Nomi=NULL
                        //                                    ,@sCampo1={cobro.Campo1}
                        //                                    ,@sCampo2={cobro.Campo2}
                        //                                    ,@sCampo3={cobro.Campo3}
                        //                                    ,@sCampo4={cobro.Campo4}
                        //                                    ,@sCampo5={cobro.Campo5}
                        //                                    ,@sCampo6={cobro.Campo6}
                        //                                    ,@sCampo7={cobro.Campo7}
                        //                                    ,@sCampo8={cobro.Campo8}
                        //                                    ,@sRevisado=NULL
                        //                                    ,@sTrasnfe=NULL
                        //                                    ,@sco_sucu_in={cobro.CoSucuIn}
                        //                                    ,@sco_us_in={cobro.CoUsIn}
                        //                                    ,@sMaquina={cobro.Maquina}";

                        //int resultMovBanco = db.Database.ExecuteSqlInterpolated(MovimientoBanco); 
                        #endregion

                        movi = new MovimientosBancoRepositorio().Save(movBanco, empresaDB);

                        #endregion
                    }
                    #endregion
                }
                #endregion

                #region Actualizar documento de venta o crear anticipo
                if (!isAdelanto) //Saber si el cobro a crear no es anticipio se rebaja el saldo del documento.
                {
                    foreach (var i in cobro.DetaCobroDocReng)
                    {
                        #region Seleccionar documento
                        SaDocumentoVenta documentoVenta = new DocumentosVentasRepositorio().Find(i.NroDoc, i.CoTipoDoc, empresaDB);
                        //db.SaDocumentoVenta.FirstOrDefault(d => d.NroDoc == i.NroDoc && d.CoTipoDoc == i.CoTipoDoc);
                        #endregion

                        #region Actualizar saldo del documento

                        documentoVenta.FeUsMo = DateTime.Now;
                        documentoVenta.Saldo -= i.MontCob;

                        Response res = new DocumentosVentasRepositorio().Update(documentoVenta, empresaDB);

                        #region Inutilizable
                        //FormattableString DocumentoActualizar = $@"EXEC {empresaDB.Trim()}.dbo.pActualizarDocumentoVenta 
                        //                            @sNro_Doc = {documentoVenta.NroDoc}
                        //                            ,@sNro_DocOri = {documentoVenta.NroOrig}
                        //                            ,@sCo_Tipo_DocOri = {documentoVenta.CoTipoDoc}
                        //                            ,@sCo_Tipo_Doc = {i.CoTipoDoc}
                        //                            ,@sDoc_Orig = {documentoVenta.DocOrig}
                        //                            ,@sCo_Cli = {cobro.CoCli}
                        //                            ,@sCo_Mone = {cobro.CoMone}
                        //                            ,@sdFec_Reg = {documentoVenta.FecReg}
                        //                            ,@sdFec_Emis = {documentoVenta.FecEmis}
                        //                            ,@bAnulado = {documentoVenta.Anulado}
                        //                            ,@deAdicional = {documentoVenta.Adicional}
                        //                            ,@sMov_Ban = {documentoVenta.MovBan}
                        //                            ,@bAut = {documentoVenta.Aut}
                        //                            ,@bContrib = {documentoVenta.Contrib}
                        //                            ,@sObserva = {documentoVenta.Observa}
                        //                            ,@sNro_Orig = {documentoVenta.NroOrig}
                        //                            ,@sNro_Che = {documentoVenta.NroChe}
                        //                            ,@sCo_Ven = {documentoVenta.CoVen}
                        //                            ,@sCo_Cta_Ingr_Egr = {documentoVenta.CoCtaIngrEgr}
                        //                            ,@deTasa = {documentoVenta.Tasa}
                        //                            ,@sTipo_Imp = {documentoVenta.TipoImp}
                        //                            ,@deTotal_Bruto = {documentoVenta.TotalBruto}
                        //                            ,@deTotal_Neto = {documentoVenta.TotalNeto}
                        //                            ,@deMonto_Reca = {documentoVenta.MontoReca}
                        //                            ,@deMonto_Imp = {documentoVenta.MontoImp}
                        //                            ,@deMonto_Imp2 = {documentoVenta.MontoImp2}
                        //                            ,@deMonto_Imp3 = {documentoVenta.MontoImp3}
                        //                            ,@deSaldo = {documentoVenta.Saldo - i.MontCob}
                        //                            ,@sN_Control = {documentoVenta.NControl}
                        //                            ,@sNum_Comprobante = {documentoVenta.NumComprobante}
                        //                            ,@sDis_Cen = {documentoVenta.DisCen}
                        //                            ,@deComis1 = {documentoVenta.Comis1}
                        //                            ,@deComis2 = {documentoVenta.Comis2}
                        //                            ,@deComis3 = {documentoVenta.Comis3}
                        //                            ,@deComis4 = {documentoVenta.Comis4}
                        //                            ,@deOtros1 = {documentoVenta.Otros1}
                        //                            ,@deOtros2 = {documentoVenta.Otros2}
                        //                            ,@deOtros3 = {documentoVenta.Otros3}
                        //                            ,@sPorc_Desc_Glob = {documentoVenta.PorcDescGlob}
                        //                            ,@deMonto_Desc_Glob = {documentoVenta.MontoDescGlob}
                        //                            ,@sPorc_Reca = {documentoVenta.PorcReca}
                        //                            ,@dePorc_Imp = {documentoVenta.PorcImp}
                        //                            ,@dePorc_Imp2 = {documentoVenta.PorcImp2}
                        //                            ,@dePorc_Imp3 = {documentoVenta.PorcImp3}
                        //                            ,@sSalestax = {documentoVenta.Salestax}
                        //                            ,@bVen_Ter = {documentoVenta.VenTer}
                        //                            ,@sdFec_Venc = {documentoVenta.FecVenc}
                        //                            ,@deComis5 = {documentoVenta.Comis5}
                        //                            ,@deComis6 = {documentoVenta.Comis6}
                        //                            ,@sImpFis = {documentoVenta.Impfis}
                        //                            ,@sImpFisFac = {documentoVenta.Impfisfac}
                        //                            ,@sImp_Nro_Z = {documentoVenta.ImpNroZ}
                        //                            ,@iTipo_Origen = {documentoVenta.TipoOrigen}
                        //                            ,@sCampo1 = {documentoVenta.Campo1}
                        //                            ,@sCampo2 = {documentoVenta.Campo2}
                        //                            ,@sCampo3 = {documentoVenta.Campo3}
                        //                            ,@sCampo4 = {documentoVenta.Campo4}
                        //                            ,@sCampo5 = {documentoVenta.Campo5}
                        //                            ,@sCampo6 = {documentoVenta.Campo6}
                        //                            ,@sCampo7 = {documentoVenta.Campo7}
                        //                            ,@sCampo8 = {documentoVenta.Campo8}
                        //                            ,@sRevisado = {documentoVenta.Revisado}
                        //                            ,@sTrasnfe = {documentoVenta.Trasnfe}
                        //                            ,@tsvalidador = {documentoVenta.Validador}
                        //                            ,@sco_sucu_mo = {documentoVenta.CoSucuMo}
                        //                            ,@sco_us_mo = {documentoVenta.CoUsMo}
                        //                            ,@growguid = {documentoVenta.Rowguid}
                        //                            ,@sMaquina = {cobro.Maquina}
                        //                            ,@sCampos = '[Saldo]={documentoVenta.Saldo} -> {documentoVenta.Saldo - i.MontCob}'";

                        //int resultSaldoDoc = db.Database.ExecuteSqlInterpolated(DocumentoActualizar); 
                        #endregion

                        #endregion

                    }
                }
                #endregion

                #region Insertar Cobro
                FormattableString Cobro = $@"EXEC pInsertarCobro 
                                            @sCob_Num = {numeroCobro}
                                            ,@sRecibo = {cobro.Recibo}
                                            ,@sCo_cli = {cobro.CoCli}
                                            ,@sCo_Ven = {cobro.CoVen}
                                            ,@sCo_Mone = {cobro.CoMone}
                                            ,@deTasa = {cobro.Tasa}
                                            ,@sdfecha = {cobro.Fecha}
                                            ,@bAnulado = {cobro.Anulado}
                                            ,@deMonto = {cobro.Monto}
                                            ,@sDis_Cen = {cobro.DisCen}
                                            ,@sDescrip = {cobro.Descrip}
                                            ,@sCampo1 = {cobro.Campo1}
                                            ,@sCampo2 = {cobro.Campo2}
                                            ,@sCampo3 = {cobro.Campo3}
                                            ,@sCampo4 = {cobro.Campo4}
                                            ,@sCampo5 = {cobro.Campo5}
                                            ,@sCampo6 = {cobro.Campo6}
                                            ,@sCampo7 = {cobro.Campo7}
                                            ,@sCampo8 = {cobro.Campo8}
                                            ,@sRevisado = {cobro.Revisado}
                                            ,@sTrasnfe = {cobro.Trasnfe}
                                            ,@sco_sucu_in = {cobro.CoSucuIn}
                                            ,@sco_us_in = {cobro.CoUsIn}
                                            ,@sMaquina = {cobro.Maquina}";

                int resultCobro = db.Database.ExecuteSqlInterpolated(Cobro);
                #endregion

                #region Insertar renglones de cobro
                foreach (var i in cobro.DetaCobroDocReng)
                {
                    FormattableString CobroRenglones = $@"EXEC pInsertarRenglonesDocCobro 
                                                        @sCob_Num = {numeroCobro}
                                                        ,@sCo_Tipo_Doc = {i.CoTipoDoc}
                                                        ,@sNro_Doc = {i.NroDoc}
                                                        ,@deMont_Cob = {i.MontCob}
                                                        ,@iTipo_Origen = {i.TipoOrigen}
                                                        ,@deDpCobro_Porc_Desc = {i.DpcobroPorcDesc}
                                                        ,@deDpCobro_Monto = {i.DpcobroMonto}
                                                        ,@demonto_retencion_iva = {i.MontoRetencionIva}
                                                        ,@demonto_retencion = {i.MontoRetencion}
                                                        ,@sTipo_Doc = {i.TipoDoc}
                                                        ,@sNum_Doc = {i.NumDoc}
                                                        ,@growguid={Guid.NewGuid()}
                                                        ,@growguid_reng_ori = {i.RowguidRengOri}
                                                        ,@iRENG_NUM = {i.RengNum}
                                                        ,@sREVISADO = {i.Revisado}
                                                        ,@sTRASNFE = {i.Trasnfe}
                                                        ,@sco_sucu_in = {i.CoSucuIn}
                                                        ,@sco_us_in = {i.CoUsIn}
                                                        ,@sMaquina = {cobro.Maquina}";

                    int resultCobroReng = db.Database.ExecuteSqlInterpolated(CobroRenglones);
                }
                #endregion

                #region Insertar forma de pago
                foreach (var i in cobro.TipoCobroTpreng)
                {
                    FormattableString FormaPago = $@"EXEC pInsertarRenglonesTPCobro 
                                                    @sCob_Num={numeroCobro}
                                                    ,@sForma_Pag={i.FormaPag}
                                                    ,@sMov_Num_C={(string.IsNullOrEmpty(i.CodCta) ? numeroCajaBanco : null)}
                                                    ,@sMov_Num_B={(!string.IsNullOrEmpty(i.CodCta) ? numeroCajaBanco : null)}
                                                    ,@sNum_Doc={i.NumDoc}
                                                    ,@bDevuelto={i.Devuelto}
                                                    ,@deMont_Doc={i.MontDoc}
                                                    ,@sCod_Cta={i.CodCta}
                                                    ,@sCod_Caja={i.CodCaja}
                                                    ,@sdfecha_che={i.FechaChe}
                                                    ,@sCo_Ban={i.CoBan}
                                                    ,@sCo_Tar={i.CoTar}
                                                    ,@sCo_Vale={i.CoVale}
                                                    ,@iRENG_NUM={i.RengNum}
                                                    ,@sREVISADO={i.Revisado}
                                                    ,@sTRASNFE={i.Trasnfe}
                                                    ,@sco_sucu_in={i.CoSucuIn}
                                                    ,@sco_us_in={cobro.CoUsIn}
                                                    ,@sMaquina={cobro.Maquina}";

                    int resultFormaPago = db.Database.ExecuteSqlInterpolated(FormaPago);
                }
                #endregion

                #region Validar consistencia modula caja
                FormattableString MoviCajaValidaConsistencia = $@"EXEC pValidarSaldoCaja @bCorregir={true},@IdProcess={Guid.NewGuid()}";
                db.Database.ExecuteSqlInterpolated(MoviCajaValidaConsistencia);
                #endregion

                return new Response { Status = "OK", Message = "Transacción realizada con éxito.", FacturaID = numeroCobro.Trim() };
            }
            catch (Exception ex)
            {
                return new Response { Status = "ERROR", Message = string.Format("{0}", ex.Message) };
            }
        }
        #endregion

    }
}
