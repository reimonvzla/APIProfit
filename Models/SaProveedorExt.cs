﻿using System;
using System.Collections.Generic;

namespace APIProfit.Models
{
    public partial class SaProveedorExt
    {
        public Guid RowguidProv { get; set; }
        public string Tgasto { get; set; }
        public string TComp { get; set; }
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
        public string Transfe { get; set; }
        public byte[] Validador { get; set; }
        public Guid Rowguid { get; set; }

        public virtual SaTipoComprobante TCompNavigation { get; set; }
        public virtual SaTipoGasto TgastoNavigation { get; set; }
    }
}
