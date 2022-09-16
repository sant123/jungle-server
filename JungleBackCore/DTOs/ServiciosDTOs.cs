using System;
using System.Collections.Generic;
using System.Text;

namespace JungleBackCore.DTOs
{
   public class ServiciosDTOs
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal? Valor { get; set; }

        public DateTime? FechaCreacion { get; set; }

    }
}
