﻿using System;
using System.Collections.Generic;

namespace APIProfit.Models
{
    public partial class VSaPagoProveedor
    {
        public string CobNum { get; set; }
        public string CoProv { get; set; }
        public DateTime Fecha { get; set; }
        public string Recibo { get; set; }
    }
}
