using JungleBackCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JungleBackCore.Interfaces
{
   public interface IEstado
    {
        Task<EstadoDTO> Insertar(EstadoDTO estado);
        Task Actualizar(EstadoDTO estado);
        Task Eliminar(int idEstado);

        Task<IEnumerable<EstadoDTO>> ObtenerEstado();
        
    }
}
