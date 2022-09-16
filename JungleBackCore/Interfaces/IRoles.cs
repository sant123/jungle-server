using JungleBackCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JungleBackCore.Interfaces
{
   public interface IRoles
    {
        Task<RolesDTO> Insertar(RolesDTO roles);
        Task Actualizar(RolesDTO roles);
        Task Eliminar(int idRoles);

        Task<IEnumerable<RolesDTO>> ObtenerRoles();

        Task<RolesDTO> ObtenerByIdRoles(int id);

    }
}
