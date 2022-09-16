using System;
using System.Collections.Generic;
using System.Text;

namespace JungleBackCore.DTOs
{
   public class PersonaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int? IdTipoDocumento { get; set; }
        public int IdRol { get; set; }

        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string NumeroDocumento { get; set; }
        public string RolUsuario { get; set; }
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
    }
}
