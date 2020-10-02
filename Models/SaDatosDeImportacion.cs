﻿using System;
using System.Collections.Generic;

namespace APIProfit.Models
{
    public partial class SaDatosDeImportacion
    {
        public Guid RowguidFacturaRenglon { get; set; }
        public string FactNum { get; set; }
        public string BlAwbCpi { get; set; }
        public int? Tasa { get; set; }
        public decimal? TotalImp { get; set; }
        public decimal? TasaValor { get; set; }
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

        public virtual SaFacturaCompra FactNumNavigation { get; set; }
        public virtual SaFacturaCompraReng RowguidFacturaRenglonNavigation { get; set; }
    }
}
