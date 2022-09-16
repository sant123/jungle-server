using System;
using System.Collections.Generic;

namespace JungleBackCore.Entities
{
    public partial class UsuarioXrol
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public int IdUsuario { get; set; }

        public virtual Roles IdRolNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
