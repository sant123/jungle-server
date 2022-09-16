using JungleBackCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JungleBackCore.Interfaces
{
   public interface IDetalleCita
    {
        Task<DetalleCitaDTO> Insertar(DetalleCitaDTO detallecita);
        Task Actualizar(DetalleCitaDTO detallecita);
        Task Eliminar(int idDetalleCita);

        Task<IEnumerable<DetalleCitaDTO>> ObtenerDetalleCita();
        
    }
}
