﻿using System;
using System.Collections.Generic;

namespace APIProfit.Models
{
    public partial class SaTipoComprobante
    {
        public SaTipoComprobante()
        {
            SaClienteExtNCrNavigation = new HashSet<SaClienteExt>();
            SaClienteExtNDbNavigation = new HashSet<SaClienteExt>();
            SaClienteExtTCompNavigation = new HashSet<SaClienteExt>();
            SaProveedorExt = new HashSet<SaProveedorExt>();
        }

        public string CoTipo { get; set; }
        public string DesTipo { get; set; }
        public bool Tipo { get; set; }
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

        public virtual ICollection<SaClienteExt> SaClienteExtNCrNavigation { get; set; }
        public virtual ICollection<SaClienteExt> SaClienteExtNDbNavigation { get; set; }
        public virtual ICollection<SaClienteExt> SaClienteExtTCompNavigation { get; set; }
        public virtual ICollection<SaProveedorExt> SaProveedorExt { get; set; }
    }
}
