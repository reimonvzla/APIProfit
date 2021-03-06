﻿using System;
using System.Collections.Generic;

namespace APIProfit.Models
{
    public partial class SaCliente
    {
        public SaCliente()
        {
            InverseMatrizNavigation = new HashSet<SaCliente>();
            SaChequeDevueltoVenta = new HashSet<SaChequeDevueltoVenta>();
            SaCobro = new HashSet<SaCobro>();
            SaCotizacionCliente = new HashSet<SaCotizacionCliente>();
            SaDevolucionCliente = new HashSet<SaDevolucionCliente>();
            SaDocumentoElectronicoCoCliDesdeNavigation = new HashSet<SaDocumentoElectronico>();
            SaDocumentoElectronicoCoCliHastaNavigation = new HashSet<SaDocumentoElectronico>();
            SaDocumentoVenta = new HashSet<SaDocumentoVenta>();
            SaFacturaVenta = new HashSet<SaFacturaVenta>();
            SaNotaDespachoVenta = new HashSet<SaNotaDespachoVenta>();
            SaNotaEntregaVenta = new HashSet<SaNotaEntregaVenta>();
            SaPedidoVenta = new HashSet<SaPedidoVenta>();
            SaPlantillaVenta = new HashSet<SaPlantillaVenta>();
            StgFactLoteGenCoCl = new HashSet<StgFactLoteGen>();
            StgFactLoteGenCoCliHNavigation = new HashSet<StgFactLoteGen>();
        }

        public string CoCli { get; set; }
        public string TipCli { get; set; }
        public string CliDes { get; set; }
        public string Direc1 { get; set; }
        public string DirEnt2 { get; set; }
        public string Direc2 { get; set; }
        public string Telefonos { get; set; }
        public string Fax { get; set; }
        public bool Inactivo { get; set; }
        public string Comentario { get; set; }
        public string Respons { get; set; }
        public DateTime FechaReg { get; set; }
        public int Puntaje { get; set; }
        public decimal MontCre { get; set; }
        public string CoMone { get; set; }
        public string CondPag { get; set; }
        public int PlazPag { get; set; }
        public decimal DescPpago { get; set; }
        public string CoZon { get; set; }
        public string CoSeg { get; set; }
        public string CoVen { get; set; }
        public decimal DescGlob { get; set; }
        public string HorarCaja { get; set; }
        public string FrecuVist { get; set; }
        public bool Lunes { get; set; }
        public bool Martes { get; set; }
        public bool Miercoles { get; set; }
        public bool Jueves { get; set; }
        public bool Viernes { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }
        public string Rif { get; set; }
        public string Nit { get; set; }
        public bool Contrib { get; set; }
        public int? Numcom { get; set; }
        public DateTime? Feccom { get; set; }
        public string DisCen { get; set; }
        public string Email { get; set; }
        public string CoCtaIngrEgr { get; set; }
        public bool Juridico { get; set; }
        public int TipoAdi { get; set; }
        public string Matriz { get; set; }
        public string CoTab { get; set; }
        public string TipoPer { get; set; }
        public bool Valido { get; set; }
        public string Ciudad { get; set; }
        public string Zip { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Website { get; set; }
        public bool Sincredito { get; set; }
        public bool ContribuE { get; set; }
        public bool ReteRegisDoc { get; set; }
        public decimal PorcEsp { get; set; }
        public string CoPais { get; set; }
        public string Serialp { get; set; }
        public int Id { get; set; }
        public string Salestax { get; set; }
        public string Estado { get; set; }
        public string Campo1 { get; set; }
        public string Campo2 { get; set; }
        public string Campo3 { get; set; }
        public string Campo4 { get; set; }
        public string Campo5 { get; set; }
        public string Campo6 { get; set; }
        public string Campo7 { get; set; }
        public string Campo8 { get; set; }
        public string CoUsIn { get; set; }
        public DateTime FeUsIn { get; set; }
        public string CoSucuIn { get; set; }
        public string CoUsMo { get; set; }
        public DateTime FeUsMo { get; set; }
        public string CoSucuMo { get; set; }
        public string Revisado { get; set; }
        public string Trasnfe { get; set; }
        public byte[] Validador { get; set; }
        public Guid Rowguid { get; set; }
        public string EmailAlterno { get; set; }

        public virtual SaCuentaIngEgr CoCtaIngrEgrNavigation { get; set; }
        public virtual SaMoneda CoMoneNavigation { get; set; }
        public virtual SaPais CoPaisNavigation { get; set; }
        public virtual SaSegmento CoSegNavigation { get; set; }
        public virtual SaTabuladorIslr CoTabNavigation { get; set; }
        public virtual SaVendedor CoVenNavigation { get; set; }
        public virtual SaZona CoZonNavigation { get; set; }
        public virtual SaCondicionPago CondPagNavigation { get; set; }
        public virtual SaCliente MatrizNavigation { get; set; }
        public virtual SaTipoCliente TipCliNavigation { get; set; }
        public virtual ICollection<SaCliente> InverseMatrizNavigation { get; set; }
        public virtual ICollection<SaChequeDevueltoVenta> SaChequeDevueltoVenta { get; set; }
        public virtual ICollection<SaCobro> SaCobro { get; set; }
        public virtual ICollection<SaCotizacionCliente> SaCotizacionCliente { get; set; }
        public virtual ICollection<SaDevolucionCliente> SaDevolucionCliente { get; set; }
        public virtual ICollection<SaDocumentoElectronico> SaDocumentoElectronicoCoCliDesdeNavigation { get; set; }
        public virtual ICollection<SaDocumentoElectronico> SaDocumentoElectronicoCoCliHastaNavigation { get; set; }
        public virtual ICollection<SaDocumentoVenta> SaDocumentoVenta { get; set; }
        public virtual ICollection<SaFacturaVenta> SaFacturaVenta { get; set; }
        public virtual ICollection<SaNotaDespachoVenta> SaNotaDespachoVenta { get; set; }
        public virtual ICollection<SaNotaEntregaVenta> SaNotaEntregaVenta { get; set; }
        public virtual ICollection<SaPedidoVenta> SaPedidoVenta { get; set; }
        public virtual ICollection<SaPlantillaVenta> SaPlantillaVenta { get; set; }
        public virtual ICollection<StgFactLoteGen> StgFactLoteGenCoCl { get; set; }
        public virtual ICollection<StgFactLoteGen> StgFactLoteGenCoCliHNavigation { get; set; }
    }
}
