using JungleBackCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JungleBackCore.Interfaces
{
   public interface ITipoMovimientoInventario
    {


        Task<TipoMovimientoInventarioDTO> Insertar(TipoMovimientoInventarioDTO tipoMovimientoInventario);
        Task Actualizar(TipoMovimientoInventarioDTO tipoMovimientoInventario);
        Task Eliminar(int idTipoMovimientoInventario);

        Task<IEnumerable<TipoMovimientoInventarioDTO>> ObtenerTipoMovimientoInventario();
    }
}
