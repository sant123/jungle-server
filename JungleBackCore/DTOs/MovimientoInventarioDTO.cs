using System;
using System.Collections.Generic;
using System.Text;

namespace JungleBackCore.DTOs
{
  public  class MovimientoInventarioDTO
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int IdProductos { get; set; }
        public string NombreProducto { get; set; }
        public string NombreTipoMovimiento { get; set; }
        public int IdInventario { get; set; }
        public int IdTipoMovimientoInventario { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
