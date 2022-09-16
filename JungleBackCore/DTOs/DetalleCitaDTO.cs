using System;
using System.Collections.Generic;
using System.Text;

namespace JungleBackCore.DTOs
{
  public  class DetalleCitaDTO
    {
        public int Id { get; set; }
        public int? IdServicios { get; set; }
        public int? IdProductos { get; set; }
        public int? IdCita { get; set; }
        public int? IdEstado { get; set; }
    }
}
