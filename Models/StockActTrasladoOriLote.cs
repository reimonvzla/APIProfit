﻿using System;
using System.Collections.Generic;

namespace APIProfit.Models
{
    public partial class StockActTrasladoOriLote
    {
        public string CoArt { get; set; }
        public string CoAlma { get; set; }
        public decimal? TotalArt { get; set; }
        public string TipoStock { get; set; }
        public DateTime Fecha { get; set; }
        public Guid Rowguid { get; set; }
        public string TrasNum { get; set; }
    }
}
