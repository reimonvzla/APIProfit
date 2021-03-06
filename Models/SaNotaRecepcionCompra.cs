﻿using System;
using System.Collections.Generic;

namespace APIProfit.Models
{
    public partial class SaNotaRecepcionCompra
    {
        public SaNotaRecepcionCompra()
        {
            SaNotaRecepcionCompraReng = new HashSet<SaNotaRecepcionCompraReng>();
        }

        public string DocNum { get; set; }
        public string NroFact { get; set; }
        public string Descrip { get; set; }
        public string CoProv { get; set; }
        public string CoMone { get; set; }
        public string CoCond { get; set; }
        public string PorcDescGlob { get; set; }
        public string PorcReca { get; set; }
        public string Status { get; set; }
        public string NControl { get; set; }
        public DateTime FecEmis { get; set; }
        public DateTime FecVenc { get; set; }
        public DateTime FecReg { get; set; }
        public decimal Tasa { get; set; }
        public decimal Saldo { get; set; }
        public decimal TotalBruto { get; set; }
        public decimal TotalNeto { get; set; }
        public decimal MontoDescGlob { get; set; }
        public decimal MontoReca { get; set; }
        public decimal Otros1 { get; set; }
        public decimal Otros2 { get; set; }
        public decimal Otros3 { get; set; }
        public decimal MontoImp { get; set; }
        public decimal MontoImp2 { get; set; }
        public decimal MontoImp3 { get; set; }
        public bool Anulado { get; set; }
        public bool Impresa { get; set; }
        public int? SerialesE { get; set; }
        public string Salestax { get; set; }
        public string DisCen { get; set; }
        public DateTime? Feccom { get; set; }
        public int? Numcom { get; set; }
        public string DirEnt { get; set; }
        public string Comentario { get; set; }
        public string Campo1 { get; set; }
        public string Campo2 { get; set; }
        public string Campo3 { get; set; }
        public string Campo4 { get; set; }
        public string Campo5 { get; set; }
        public string Campo6 { get; set; }
        public string Campo7 { get; set; }
        public string Campo8 { get; set; }
        public string CoUsIn { get; set; }
        public string CoSucuIn { get; set; }
        public DateTime FeUsIn { get; set; }
        public string CoUsMo { get; set; }
        public string CoSucuMo { get; set; }
        public DateTime FeUsMo { get; set; }
        public string Revisado { get; set; }
        public string Trasnfe { get; set; }
        public byte[] Validador { get; set; }
        public Guid Rowguid { get; set; }
        public bool? Nac { get; set; }
        public string CoCtaIngrEgr { get; set; }

        public virtual SaCondicionPago CoCondNavigation { get; set; }
        public virtual SaCuentaIngEgr CoCtaIngrEgrNavigation { get; set; }
        public virtual SaMoneda CoMoneNavigation { get; set; }
        public virtual SaProveedor CoProvNavigation { get; set; }
        public virtual SaTax SalestaxNavigation { get; set; }
        public virtual ICollection<SaNotaRecepcionCompraReng> SaNotaRecepcionCompraReng { get; set; }
    }
}
