﻿using System;
using System.Collections.Generic;

namespace APIProfit.Models
{
    public partial class SaFactCompRengCaracteristicasAdic
    {
        public Guid DocOrig { get; set; }
        public decimal VolumenNeto { get; set; }
        public decimal PesoNeto { get; set; }

        public virtual SaFacturaCompraReng DocOrigNavigation { get; set; }
    }
}
