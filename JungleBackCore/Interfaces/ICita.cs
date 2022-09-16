using JungleBackCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JungleBackCore.Interfaces
{
   public interface ICita
    {
        Task<CitaDTO> Insertar(CitaDTO cita);
        Task Actualizar(CitaDTO cita);
        Task Eliminar(int idCita);

        Task<IEnumerable<CitaDTO>> ObtenerCita();

        Task<CitaDTO> ObtenerByIdCita(int id);


    }
}
