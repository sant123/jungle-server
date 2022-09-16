using System;
using System.Collections.Generic;
using System.Text;

namespace JungleBackCore.DTOs
{
  public  class InventarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
