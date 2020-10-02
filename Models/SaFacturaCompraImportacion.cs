﻿using System;
using System.Collections.Generic;

namespace APIProfit.Models
{
    public partial class SaFacturaCompraImportacion
    {
        public string DocNum { get; set; }
        public string CoTipoDoc { get; set; }
        public string NumPlanImpor { get; set; }
        public string NumExpImpor { get; set; }
        public string CoIncoterm { get; set; }
        public string LugarEmbarque { get; set; }
        public string LugarDesembarque { get; set; }
        public string EmpresaTransporte { get; set; }
        public string Documentacion { get; set; }
        public string CondicionesSeguro { get; set; }
        public string Empaque { get; set; }
        public string Marcas { get; set; }
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

        public virtual SaIncoterm CoIncotermNavigation { get; set; }
    }
}