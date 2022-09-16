using System;
using System.Collections.Generic;

namespace JungleBackCore.Entities
{
    public partial class Inventario
    {
        public Inventario()
        {
            MovimientoInventario = new HashSet<MovimientoInventario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual ICollection<MovimientoInventario> MovimientoInventario { get; set; }
    }
}
