using System;
using System.Collections.Generic;

namespace JungleBackCore.Entities
{
    public partial class Productos
    {
        public Productos()
        {
            DetalleCita = new HashSet<DetalleCita>();
            MovimientoInventario = new HashSet<MovimientoInventario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ValorUnitario { get; set; }
        public string RefereciaMarca { get; set; }
        public int? IdTipoProducto { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual TipoProducto IdTipoProductoNavigation { get; set; }
        public virtual ICollection<DetalleCita> DetalleCita { get; set; }
        public virtual ICollection<MovimientoInventario> MovimientoInventario { get; set; }
    }
}
