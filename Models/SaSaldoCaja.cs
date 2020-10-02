﻿using System;
using System.Collections.Generic;

namespace APIProfit.Models
{
    public partial class SaSaldoCaja
    {
        public string CodCaja { get; set; }
        public string Tipo { get; set; }
        public decimal Saldo { get; set; }
        public string Revisado { get; set; }
        public string Trasnfe { get; set; }
        public byte[] Validador { get; set; }

        public virtual SaCaja CodCajaNavigation { get; set; }
    }
}
