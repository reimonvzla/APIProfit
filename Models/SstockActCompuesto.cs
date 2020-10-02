using System;
using System.Collections.Generic;

namespace APIProfit.Models
{
    public partial class SstockActCompuesto
    {
        public string CoArt { get; set; }
        public string CoAlma { get; set; }
        public decimal? TotalArt { get; set; }
        public string TipoStock { get; set; }
        public DateTime Fecha { get; set; }
    }
}
