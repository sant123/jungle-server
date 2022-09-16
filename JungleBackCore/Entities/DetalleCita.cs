using System;
using System.Collections.Generic;

namespace JungleBackCore.Entities
{
    public partial class DetalleCita
    {
        public DetalleCita()
        {
            Cita = new HashSet<Cita>();
        }

        public int Id { get; set; }
        public int? IdServicios { get; set; }
        public int? IdProductos { get; set; }
        public int? IdCita { get; set; }
        public int? IdEstado { get; set; }

        public virtual Productos IdProductosNavigation { get; set; }
        public virtual Servicios IdServiciosNavigation { get; set; }
        public virtual ICollection<Cita> Cita { get; set; }
    }
}
