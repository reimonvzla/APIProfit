﻿using System;
using System.Collections.Generic;

namespace APIProfit.Models
{
    public partial class PvTipoTarjeta
    {
        public PvTipoTarjeta()
        {
            PvTarjetaCreditoExt = new HashSet<PvTarjetaCreditoExt>();
        }

        public string TipoTarjeta { get; set; }
        public string DescripcionTipo { get; set; }
        public Guid Rowguid { get; set; }

        public virtual ICollection<PvTarjetaCreditoExt> PvTarjetaCreditoExt { get; set; }
    }
}
