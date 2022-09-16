using System;
using System.Collections.Generic;

namespace JungleBackCore.Entities
{
    public partial class Roles
    {
        public Roles()
        {
            UsuarioXrol = new HashSet<UsuarioXrol>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<UsuarioXrol> UsuarioXrol { get; set; }
    }
}
