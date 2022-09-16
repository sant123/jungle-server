using System;
using System.Collections.Generic;

namespace JungleBackCore.Entities
{
    public partial class MovimientoInventario
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int IdProductos { get; set; }
        public int IdInventario { get; set; }
        public int IdTipoMovimientoInventario { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual Inventario IdInventarioNavigation { get; set; }
        public virtual Productos IdProductosNavigation { get; set; }
        public virtual TipoMovimientoInventario IdTipoMovimientoInventarioNavigation { get; set; }
    }
}
