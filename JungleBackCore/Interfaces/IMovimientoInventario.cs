using JungleBackCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JungleBackCore.Interfaces
{
  public  interface IMovimientoInventario
    {
        Task<MovimientoInventarioDTO> Insertar(MovimientoInventarioDTO movivimientoinventario);
        Task Actualizar(MovimientoInventarioDTO movivimientoinventario);
        Task Eliminar(int idMovimientoInventario);

        Task<IEnumerable<MovimientoInventarioDTO>> ObtenerMovimientoInventario(int idInventario );

    }
}
