using System;
using System.Collections.Generic;

namespace APIProfit.Models
{
    public partial class VSaDepositoBancario
    {
        public string DepNum { get; set; }
        public string CodCta { get; set; }
        public DateTime Fecha { get; set; }
        public string Deposito { get; set; }
    }
}
