using System;
using System.Collections.Generic;

namespace JungleBackCore.Entities
{
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            Persona = new HashSet<Persona>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public byte[] Descripcion { get; set; }

        public virtual ICollection<Persona> Persona { get; set; }
    }
}
