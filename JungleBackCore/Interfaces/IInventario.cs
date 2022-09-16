using JungleBackCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JungleBackCore.Interfaces
{
  public  interface IInventario
    {
        Task<InventarioDTO> Insertar(InventarioDTO inventario);
        Task Actualizar(InventarioDTO inventario);
        Task Eliminar(int idInventario);

        Task<IEnumerable<InventarioDTO>> ObtenerInventario();
        Task<InventarioDTO> ObtenerByIdInventario(int id);
    
    }
}
