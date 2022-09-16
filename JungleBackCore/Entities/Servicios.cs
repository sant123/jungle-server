using System;
using System.Collections.Generic;

namespace JungleBackCore.Entities
{
    public partial class Servicios
    {
        public Servicios()
        {
            DetalleCita = new HashSet<DetalleCita>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual ICollection<DetalleCita> DetalleCita { get; set; }
    }
}
