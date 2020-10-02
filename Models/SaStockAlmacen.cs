﻿using System;
using System.Collections.Generic;

namespace APIProfit.Models
{
    public partial class SaStockAlmacen
    {
        public string CoAlma { get; set; }
        public string CoArt { get; set; }
        public string Tipo { get; set; }
        public decimal Stock { get; set; }
        public string Revisado { get; set; }
        public string Trasnfe { get; set; }
        public byte[] Validador { get; set; }

        public virtual SaAlmacen CoAlmaNavigation { get; set; }
        public virtual SaArticulo CoArtNavigation { get; set; }
    }
}
