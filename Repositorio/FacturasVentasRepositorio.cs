namespace APIProfit.Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Entidades;
    using Models;

    public class FacturasVentasRepositorio
    {
        readonly ConexionAlterna conn = new ConexionAlterna();
        readonly Utilitarios utilitarios = new Utilitarios();

        #region GetFacturas
        public IEnumerable<SaFacturaVenta> GetFacturas(string empresaDB)
        {
            using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));

            //return db.SaFacturaVenta.ToList();
            var Qry = db.SaFacturaVenta.Select(f => new SaFacturaVenta()
            {
                DocNum = f.DocNum,
                Descrip = f.Descrip,
                CoCli = f.CoCli,
                CoTran = f.CoTran,
                CoMone = f.CoMone,
                CoVen = f.CoVen,
                CoCond = f.CoCond,
                FecEmis = f.FecEmis,
                FecVenc = f.FecVenc,
                FecReg = f.FecReg,
                Anulado = f.Anulado,
                Status = f.Status,
                NControl = f.NControl,
                VenTer = f.VenTer,
                Tasa = f.Tasa,
                PorcDescGlob = f.PorcDescGlob,
                MontoDescGlob = f.MontoDescGlob,
                PorcReca = f.PorcReca,
                MontoReca = f.MontoReca,
                TotalBruto = f.TotalBruto,
                MontoImp = f.MontoImp,
                MontoImp2 = f.MontoImp2,
                MontoImp3 = f.MontoImp3,
                Otros1 = f.Otros1,
                Otros2 = f.Otros2,
                Otros3 = f.Otros3,
                TotalNeto = f.TotalNeto,
                Saldo = f.Saldo,
                DirEnt = f.DirEnt,
                Comentario = f.Comentario,
                DisCen = f.DisCen,
                Feccom = f.Feccom,
                Numcom = f.Numcom,
                Contrib = f.Contrib,
                Impresa = f.Impresa,
                SerialesS = f.SerialesS,
                Salestax = f.Salestax,
                Impfis = f.Impfis,
                Impfisfac = f.Impfisfac,
                ImpNroZ = f.ImpNroZ,
                Campo1 = f.Campo1,
                Campo2 = f.Campo2,
                Campo3 = f.Campo3,
                Campo4 = f.Campo4,
                Campo5 = f.Campo5,
                Campo6 = f.Campo6,
                Campo7 = f.Campo7,
                Campo8 = f.Campo8,
                CoUsIn = f.CoUsIn,
                CoSucuIn = f.CoSucuIn,
                FeUsIn = f.FeUsIn,
                CoUsMo = f.CoUsMo,
                CoSucuMo = f.CoSucuMo,
                FeUsMo = f.FeUsMo,
                Revisado = f.Revisado,
                Trasnfe = f.Trasnfe,
                Validador = f.Validador,
                Rowguid = f.Rowguid,
                CoCtaIngrEgr = f.CoCtaIngrEgr,
                SaFacturaVentaReng = f.SaFacturaVentaReng
            }).ToList();

            return Qry;
        }
        #endregion

        #region Find (por numero de factura)
        public SaFacturaVenta Find(string key,string empresaDB)
        {
            using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));

            var Qry = db.SaFacturaVenta.Select(f => new SaFacturaVenta()
            {
                DocNum = f.DocNum,
                Descrip = f.Descrip,
                CoCli = f.CoCli,
                CoTran = f.CoTran,
                CoMone = f.CoMone,
                CoVen = f.CoVen,
                CoCond = f.CoCond,
                FecEmis = f.FecEmis,
                FecVenc = f.FecVenc,
                FecReg = f.FecReg,
                Anulado = f.Anulado,
                Status = f.Status,
                NControl = f.NControl,
                VenTer = f.VenTer,
                Tasa = f.Tasa,
                PorcDescGlob = f.PorcDescGlob,
                MontoDescGlob = f.MontoDescGlob,
                PorcReca = f.PorcReca,
                MontoReca = f.MontoReca,
                TotalBruto = f.TotalBruto,
                MontoImp = f.MontoImp,
                MontoImp2 = f.MontoImp2,
                MontoImp3 = f.MontoImp3,
                Otros1 = f.Otros1,
                Otros2 = f.Otros2,
                Otros3 = f.Otros3,
                TotalNeto = f.TotalNeto,
                Saldo = f.Saldo,
                DirEnt = f.DirEnt,
                Comentario = f.Comentario,
                DisCen = f.DisCen,
                Feccom = f.Feccom,
                Numcom = f.Numcom,
                Contrib = f.Contrib,
                Impresa = f.Impresa,
                SerialesS = f.SerialesS,
                Salestax = f.Salestax,
                Impfis = f.Impfis,
                Impfisfac = f.Impfisfac,
                ImpNroZ = f.ImpNroZ,
                Campo1 = f.Campo1,
                Campo2 = f.Campo2,
                Campo3 = f.Campo3,
                Campo4 = f.Campo4,
                Campo5 = f.Campo5,
                Campo6 = f.Campo6,
                Campo7 = f.Campo7,
                Campo8 = f.Campo8,
                CoUsIn = f.CoUsIn,
                CoSucuIn = f.CoSucuIn,
                FeUsIn = f.FeUsIn,
                CoUsMo = f.CoUsMo,
                CoSucuMo = f.CoSucuMo,
                FeUsMo = f.FeUsMo,
                Revisado = f.Revisado,
                Trasnfe = f.Trasnfe,
                Validador = f.Validador,
                Rowguid = f.Rowguid,
                CoCtaIngrEgr = f.CoCtaIngrEgr,
                SaFacturaVentaReng = f.SaFacturaVentaReng
            }).FirstOrDefault(f => f.DocNum == key);

            if (Qry == null) return null;
            return Qry;
        }
        #endregion

        #region Guardar
        public Response Guardar(EncabFacturaVenta factura,string empresaDB)
        {
            try
            {
                using var db = new ProfitAdmin2K12(conn.GetDbContextOptions(empresaDB));

                int resultEncab = -1, resultDeta = -1, resultDoc = -1;

                #region Validar datos
                ValidarDatos(factura, empresaDB);
                #endregion

                #region Consecutivo numero de factura
                /*Consecutivo de Numero de Factura.*/
                string codigoConsecutivoFactura = "DOC_VEN_FACT";
                string numeroFactura = utilitarios.GetProximoNumero(codigoConsecutivoFactura, factura.CoSucuIn, empresaDB);
                #endregion

                #region Consecutivo numero de control
                /*Consecutivo de Nro Control*/
                string codigoConsecutivoControl = "FACT_VTA_N_CON";
                string numeroControl = utilitarios.GetProximoNumero(codigoConsecutivoControl, factura.CoSucuIn, empresaDB);
                #endregion

                #region Insertar factura de venta.
                FormattableString FactVenta = $@"EXEC pInsertarFacturaVenta 
                     @sN_Control={numeroControl}
                    ,@sDoc_Num={numeroFactura}
                    ,@sDescrip={factura.Descrip}
                    ,@sCo_Cli={factura.CoCli}
                    ,@sCo_Tran={factura.CoTran}
                    ,@sCo_Cond={factura.CoCond}
                    ,@sCo_Ven={factura.CoVen}
                    ,@sCo_Cta_Ingr_Egr={factura.CoCtaIngrEgr}
                    ,@sCo_Mone={factura.CoMone}
                    ,@bAnulado={factura.Anulado}
                    ,@sdFec_Emis={factura.FecEmis}
                    ,@sdFec_Reg={factura.FecReg}
                    ,@sdFec_Venc={factura.FecVenc}
                    ,@sStatus={factura.Status}
                    ,@deTasa={factura.Tasa}
                    ,@sPorc_Desc_Glob={factura.PorcDescGlob}
                    ,@deMonto_Desc_Glob={factura.MontoDescGlob}
                    ,@sPorc_Reca={factura.PorcReca}
                    ,@deMonto_Reca={factura.MontoReca}
                    ,@deSaldo={factura.Saldo}
                    ,@deTotal_Bruto={factura.TotalBruto}
                    ,@deMonto_Imp={factura.MontoImp}
                    ,@deMonto_Imp3={factura.MontoImp3}
                    ,@deOtros1={factura.Otros1}
                    ,@deOtros2={factura.Otros2}
                    ,@deOtros3={factura.Otros3}
                    ,@deMonto_Imp2={factura.MontoImp2}
                    ,@deTotal_Neto={factura.TotalNeto}
                    ,@sComentario={factura.Comentario}
                    ,@sDir_Ent={factura.DirEnt}
                    ,@bContrib={factura.Contrib}
                    ,@bImpresa={factura.Impresa}
                    ,@sSalestax={factura.Salestax}
                    ,@sImpfis={factura.Impfis}
                    ,@sImpfisfac={factura.Impfisfac}
                    ,@bVen_Ter={factura.VenTer}
                    ,@sDis_Cen={factura.DisCen}
                    ,@sCampo1={factura.Campo1}
                    ,@sCampo2={factura.Campo2}
                    ,@sCampo3={factura.Campo3}
                    ,@sCampo4={factura.Campo4}
                    ,@sCampo5={factura.Campo5}
                    ,@sCampo6={factura.Campo6}
                    ,@sCampo7={factura.Campo7}
                    ,@sCampo8={factura.Campo8}
                    ,@sRevisado={factura.Revisado}
                    ,@sTrasnfe={factura.Trasnfe}
                    ,@sco_sucu_in={factura.CoSucuIn}
                    ,@sco_us_in={factura.CoUsIn}
                    ,@sMaquina={factura.Maquina}";

                resultEncab = db.Database.ExecuteSqlInterpolated(FactVenta);
                #endregion

                #region Insertar renglones de factura de venta.

                /* resultEncab es el resultado devuelto por el stored procedure de insertar factura de venta 
                 * (-1 no registró la transacción en sql) */

                foreach (var i in factura.DetaFacturaVenta)
                {
                    FormattableString RengFactVenta = $@"EXEC pInsertarRenglonesFacturaVenta
                        @iReng_Num={i.RengNum}
                        ,@sDoc_Num={numeroFactura}
                        ,@sCo_Art={i.CoArt}
                        ,@sDes_Art={i.DesArt}
                        ,@sCo_Uni={i.CoUni}
                        ,@sSco_Uni={i.ScoUni}
                        ,@sCo_Alma={i.CoAlma}
                        ,@sCo_Precio={i.CoPrecio}
                        ,@sTipo_Imp={i.TipoImp}
                        ,@sTipo_Imp2={i.TipoImp2}
                        ,@sTipo_Imp3={i.TipoImp3}
                        ,@deTotal_Art={i.TotalArt}
                        ,@deSTotal_Art={i.StotalArt}
                        ,@dePrec_Vta={i.PrecVta}
                        ,@sPorc_Desc={i.PorcDesc}
                        ,@deMonto_Desc={i.MontoDesc}
                        ,@deReng_Neto={i.RengNeto}
                        ,@dePendiente={i.Pendiente}
                        ,@dePendiente2={i.Pendiente2}
                        ,@deMonto_Desc_Glob={i.MontoDescGlob}
                        ,@deMonto_reca_Glob={i.MontoRecaGlob}
                        ,@deOtros1_glob={i.Otros1Glob}
                        ,@deOtros2_glob={i.Otros2Glob}
                        ,@deOtros3_glob={i.Otros3Glob}
                        ,@deMonto_imp_afec_glob={i.MontoImpAfecGlob}
                        ,@deMonto_imp2_afec_glob={i.MontoImp2AfecGlob}
                        ,@deMonto_imp3_afec_glob={i.MontoImp3AfecGlob}
                        ,@sTipo_Doc={i.TipoDoc}
                        ,@gRowguid_Doc={i.RowguidDoc}
                        ,@sNum_Doc={i.NumDoc}
                        ,@dePorc_Imp={i.PorcImp}
                        ,@dePorc_Imp2={i.PorcImp2}
                        ,@dePorc_Imp3={i.PorcImp3}
                        ,@deMonto_Imp={i.MontoImp}
                        ,@deMonto_Imp2={i.MontoImp2}
                        ,@deMonto_Imp3={i.MontoImp3}
                        ,@deOtros={i.Otros}
                        ,@deTotal_Dev={i.TotalDev}
                        ,@deMonto_Dev={i.MontoDev}
                        ,@sComentario={i.Comentario}
                        ,@sDis_Cen={i.DisCen}
                        ,@sCo_Sucu_In={i.CoSucuIn}
                        ,@sCo_Us_In={i.CoUsIn}
                        ,@sREVISADO={i.Revisado}
                        ,@sTRASNFE={i.Trasnfe}
                        ,@sMaquina={i.Maquina}";

                    resultDeta = db.Database.ExecuteSqlInterpolated(RengFactVenta);
                }
                #endregion

                #region Insertar documento de venta

                /*resultDeta devuelve el resultado del stored procedure insertar renglones de factura de venta
                 (-1 no registró la transacción en sql). */

                FormattableString DocumentoVenta = $@"EXEC pInsertarDocumentoVenta 
                        @sNro_Doc = {numeroFactura}
                        ,@sCo_Tipo_Doc = 'FACT'
                        ,@sDoc_Orig = 'FACT'
                        ,@sCo_Cli = {factura.CoCli}
                        ,@sCo_Mone = {factura.CoMone}
                        ,@sdFec_Reg = {factura.FecReg}
                        ,@sdFec_Emis = {factura.FecEmis}
                        ,@bAnulado = {factura.Anulado}
                        ,@deAdicional = 0
                        ,@sMov_Ban = NULL
                        ,@bAut = 1
                        ,@bContrib = {factura.Contrib}
                        ,@sObserva = 'FACT N°  de Cliente {factura.CoCli}'
                        ,@sNro_Orig = {numeroFactura}
                        ,@sNro_Che = NULL
                        ,@sCo_Ven = {factura.CoVen}
                        ,@sCo_Cta_Ingr_Egr = {factura.CoCtaIngrEgr}
                        ,@deTasa = {factura.Tasa}
                        ,@sTipo_Imp = NULL
                        ,@deTotal_Bruto = {factura.TotalBruto}
                        ,@deTotal_Neto = {factura.TotalNeto}
                        ,@deMonto_Reca = {factura.MontoReca}
                        ,@deMonto_Imp = {factura.MontoImp}
                        ,@deMonto_Imp2 = {factura.MontoImp2}
                        ,@deMonto_Imp3 = {factura.MontoImp3}
                        ,@deSaldo = {factura.Saldo}
                        ,@sN_Control = {numeroControl}
                        ,@sNum_Comprobante = NULL
                        ,@sDis_Cen = NULL
                        ,@deComis1 = 0,@deComis2 = 0,@deComis3 = 0,@deComis4 = 0
                        ,@deOtros1 = {factura.Otros1}
                        ,@deOtros2 = {factura.Otros2}
                        ,@deOtros3 = {factura.Otros3}
                        ,@sPorc_Desc_Glob = {factura.PorcDescGlob}
                        ,@deMonto_Desc_Glob = {factura.MontoDescGlob}
                        ,@sPorc_Reca = {factura.PorcReca}
                        ,@dePorc_Imp = 0,@dePorc_Imp2 = 0,@dePorc_Imp3 = 0
                        ,@sSalestax = {factura.Salestax}
                        ,@bVen_Ter = {factura.VenTer}
                        ,@sdFec_Venc = {factura.FecVenc}
                        ,@deComis5 = 0,@deComis6 = 0
                        ,@sImpFis = {factura.Impfis}
                        ,@sImpFisFac = {factura.Impfisfac}
                        ,@sImp_Nro_Z = {factura.ImpNroZ}
                        ,@iTipo_Origen = 0
                        ,@sCampo1 = {factura.Campo1},@sCampo2 = {factura.Campo2},@sCampo3 = {factura.Campo3},@sCampo4 = {factura.Campo4},@sCampo5 = {factura.Campo5},@sCampo6 = {factura.Campo6},@sCampo7 = {factura.Campo7},@sCampo8 = {factura.Campo8}
                        ,@sRevisado = {factura.Revisado}
                        ,@sTrasnfe = {factura.Trasnfe}
                        ,@sco_sucu_in = {factura.CoSucuIn}
                        ,@sco_us_in = {factura.CoUsIn}
                        ,@sMaquina = {factura.Maquina}";

                resultDoc = db.Database.ExecuteSqlInterpolated(DocumentoVenta);
                #endregion

                return new Response { Status = "OK", Message = "Transacción realizada con éxito.", FacturaID = numeroFactura, ControlID = numeroControl };
            }
            catch (Exception ex)
            {
                return new Response { Status = "ERROR", Message = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message };
            }
        }
        #endregion

        #region Validar datos
        private void ValidarDatos(EncabFacturaVenta obj, string empresaDB)
        {
            #region Verificar sucursal
            SaSucursal sucu = new SucursalesRepositorio().Find(obj.CoSucuIn, empresaDB);
            if (sucu == null)
            {
                throw new ArgumentException($"La sucursal {obj.CoSucuIn} no existe.");
            }
            #endregion

            #region Verificar cliente
            SaCliente cliente = new ClientesRepositorio().Find(obj.CoCli, empresaDB);
            if (cliente == null)
            {
                throw new ArgumentException($"El cliente {obj.CoCli} no existe.");
            }
            #endregion

            #region Verificar transporte
            SaTransporte transporte = new TransportesRepositorio().Find(obj.CoTran, empresaDB);
            if (transporte == null)
            {
                throw new ArgumentException($"El transporte {obj.CoTran} no existe.");
            }
            #endregion

            #region Verificar forma de pago
            SaCondicionPago condicion = new CondicionesPagosRepositorio().Find(obj.CoCond, empresaDB);
            if (condicion == null)
            {
                throw new ArgumentException($"La forma de pago {obj.CoCond} no existe.");
            }
            #endregion

            #region Verificar moneda
            utilitarios.GetMoneda(obj.CoMone, empresaDB);
            #endregion

            #region Verificar datos en renglones
            foreach (var iRengFac in obj.DetaFacturaVenta)
            {
                #region Verificar articulo
                SaArticulo articulo = new ArticulosRepositorio().Find(iRengFac.CoArt, empresaDB);
                if (articulo == null)
                {
                    throw new ArgumentException($"El artículo {iRengFac.CoArt.Trim()} suministrado en el renglón {iRengFac.RengNum} no existe.");
                }
                #endregion

                #region Verificar almacen
                SaAlmacen almacen = new AlmacenesRepositorio().Find(iRengFac.CoAlma, empresaDB);
                if (almacen == null)
                {
                    throw new ArgumentException($"El almacén {iRengFac.CoAlma.Trim()} suministrado en el renglón {iRengFac.RengNum} no existe.");
                }
                else
                {
                    if (almacen.CoSucur.Trim() != iRengFac.CoSucuIn.Trim())
                    {
                        throw new ArgumentException($"El almacén {iRengFac.CoAlma.Trim()} suministrado en el renglón {iRengFac.RengNum} no está permitido utilizarlo en la sucursal suministrada {obj.CoSucuIn.Trim()}.");
                    }
                    if (almacen.Noventa)
                    {
                        throw new ArgumentException($"El almacén {iRengFac.CoAlma.Trim()} suministrado en el renglón {iRengFac.RengNum} no está permitido utilizarlo en el módulo de facturas.");
                    }
                }
                #endregion

                #region Verificar unidad primaria
                utilitarios.GetUnidadPrimaria(iRengFac.CoUni.Trim(), empresaDB);
                #endregion

            }
            #endregion

        } 
        #endregion
    }
}