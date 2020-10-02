using System;
using System.Collections.Generic;

namespace APIProfit.Models
{
    public partial class SaHistoricoEstado
    {
        public Guid Rowguid { get; set; }
        public Guid DocOrig { get; set; }
        public string TipoDoc { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
        public byte[] Validador { get; set; }
    }
}
