using System;
using System.Collections.Generic;
using System.Text;

namespace JungleBackCore.DTOs
{
  public  class ProductosDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ValorUnitario { get; set; }
        public string RefereciaMarca { get; set; }
        public int? IdTipoProducto { get; set; }
        public string TipoProducto { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
