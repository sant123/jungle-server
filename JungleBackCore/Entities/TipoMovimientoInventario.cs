using System;
using System.Collections.Generic;

namespace JungleBackCore.Entities
{
    public partial class TipoMovimientoInventario
    {
        public TipoMovimientoInventario()
        {
            MovimientoInventario = new HashSet<MovimientoInventario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Salida { get; set; }

        public virtual ICollection<MovimientoInventario> MovimientoInventario { get; set; }
    }
}
