using System;
using System.Collections.Generic;

namespace JungleBackCore.Entities
{
    public partial class TipoProducto
    {
        public TipoProducto()
        {
            Productos = new HashSet<Productos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
