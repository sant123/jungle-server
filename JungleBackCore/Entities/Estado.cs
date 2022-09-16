using System;
using System.Collections.Generic;

namespace JungleBackCore.Entities
{
    public partial class Estado
    {
        public Estado()
        {
            Cita = new HashSet<Cita>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Cita> Cita { get; set; }
    }
}
