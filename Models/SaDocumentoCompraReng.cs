﻿using System;
using System.Collections.Generic;

namespace APIProfit.Models
{
    public partial class SaDocumentoCompraReng
    {
        public int RengNum { get; set; }
        public string CoTipoDoc { get; set; }
        public string NroDoc { get; set; }
        public string CoArt { get; set; }
        public string DesArt { get; set; }
        public string CoAlma { get; set; }
        public string CoUni { get; set; }
        public decimal CostoAdi1 { get; set; }
        public decimal CostoAdi2 { get; set; }
        public decimal CostoAdi3 { get; set; }
        public decimal TotalArt { get; set; }
        public decimal CostUnit { get; set; }
        public decimal CostUnitOm { get; set; }
        public decimal RengNeto { get; set; }
        public string TipoImp { get; set; }
        public string TipoImp2 { get; set; }
        public string TipoImp3 { get; set; }
        public decimal PorcImp { get; set; }
        public decimal PorcImp2 { get; set; }
        public decimal PorcImp3 { get; set; }
        public decimal MontoImp { get; set; }
        public decimal MontoImp2 { get; set; }
        public decimal MontoImp3 { get; set; }
        public string PorcDesc { get; set; }
        public decimal MontoDesc { get; set; }
        public decimal MontoDescGlob { get; set; }
        public decimal MontoImpAfecGlob { get; set; }
        public decimal MontoImp2AfecGlob { get; set; }
        public decimal MontoImp3AfecGlob { get; set; }
        public decimal MontoRecaGlob { get; set; }
        public decimal Otros { get; set; }
        public decimal Otros1Glob { get; set; }
        public decimal Otros2Glob { get; set; }
        public decimal Otros3Glob { get; set; }
        public string DisCen { get; set; }
        public string CoUsIn { get; set; }
        public string CoSucuIn { get; set; }
        public DateTime FeUsIn { get; set; }
        public string CoUsMo { get; set; }
        public string CoSucuMo { get; set; }
        public DateTime FeUsMo { get; set; }
        public string Revisado { get; set; }
        public string Trasnfe { get; set; }
        public Guid Rowguid { get; set; }

        public virtual SaArtUnidad Co { get; set; }
        public virtual SaDocumentoCompra SaDocumentoCompra { get; set; }
    }
}
