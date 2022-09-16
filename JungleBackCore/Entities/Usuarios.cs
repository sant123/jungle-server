using System;
using System.Collections.Generic;

namespace JungleBackCore.Entities
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            CitaIdUsuarioAgendaNavigation = new HashSet<Cita>();
            CitaIdUsuarioAtiendeNavigation = new HashSet<Cita>();
            UsuarioXrol = new HashSet<UsuarioXrol>();
        }

        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public int IdPersona { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual ICollection<Cita> CitaIdUsuarioAgendaNavigation { get; set; }
        public virtual ICollection<Cita> CitaIdUsuarioAtiendeNavigation { get; set; }
        public virtual ICollection<UsuarioXrol> UsuarioXrol { get; set; }
    }
}
