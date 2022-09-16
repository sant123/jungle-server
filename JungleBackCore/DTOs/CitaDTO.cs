using System;
using System.Collections.Generic;
using System.Text;

namespace JungleBackCore.DTOs
{
  public  class CitaDTO
    {
        public int Id { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan? HoraFin { get; set; }
        public DateTime Fecha { get; set; }
        public string Sede { get; set; }
        public string Direccion { get; set; }
        public int? IdDetalleCita { get; set; }
        public int? IdUsuarioAgenda { get; set; }
        public int? IdUsuarioAtiende { get; set; }
        public int? IdEstado { get; set; }
    }
}
