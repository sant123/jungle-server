using System;
using System.Collections.Generic;

namespace JungleBackCore.Entities
{
    public partial class Persona
    {
        public Persona()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int? IdTipoDocumento { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string NumeroDocumento { get; set; }

        public virtual TipoDocumento IdTipoDocumentoNavigation { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
