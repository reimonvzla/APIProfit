﻿using System;
using System.Collections.Generic;

namespace APIProfit.Models
{
    public partial class SaGiroCompra
    {
        public SaGiroCompra()
        {
            SaGiroCompraReng = new HashSet<SaGiroCompraReng>();
        }

        public string CoGiro { get; set; }
        public string DesGiro { get; set; }
        public string CoProv { get; set; }
        public DateTime Fecha { get; set; }
        public int CantGiro { get; set; }
        public string Frecuencia { get; set; }
        public DateTime FecPGiro { get; set; }
        public decimal PorcInteres { get; set; }
        public string CobNum { get; set; }
        public string CoTipoDoc { get; set; }
        public string NroDoc { get; set; }
        public decimal MontDoc { get; set; }
        public bool Procesado { get; set; }
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

        public virtual SaPago CobNumNavigation { get; set; }
        public virtual ICollection<SaGiroCompraReng> SaGiroCompraReng { get; set; }
    }
}
