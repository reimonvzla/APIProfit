﻿using System;
using System.Collections.Generic;

namespace APIProfit.Models
{
    public partial class VSaOrdenCompra
    {
        public string DocNum { get; set; }
        public string CoProv { get; set; }
        public DateTime FecEmis { get; set; }
        public decimal TotalNeto { get; set; }
        public string Status { get; set; }
        public string ProvDes { get; set; }
        public string NroFact { get; set; }
        public string Descrip { get; set; }
        public string CoMone { get; set; }
        public string CoCond { get; set; }
        public decimal TotalBruto { get; set; }
        public string NControl { get; set; }
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
        public string CoUsMo { get; set; }
        public string CoSucuMo { get; set; }
        public decimal Saldo { get; set; }
    }
}
