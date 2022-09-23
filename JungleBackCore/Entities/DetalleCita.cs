using System;
using System.Collections.Generic;

namespace JungleBackCore.Entities
{
    public partial class DetalleCita
    {
        public int Id { get; set; }
        public int? IdServicios { get; set; }
        public int? IdProductos { get; set; }
        public int? IdCita { get; set; }
        public int? IdEstado { get; set; }

        public virtual Cita Cita { get; set; }
        public virtual Productos IdProductosNavigation { get; set; }
        public virtual Servicios IdServiciosNavigation { get; set; }
    }
}
