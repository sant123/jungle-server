using JungleBackCore.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JungleBackCore.Interfaces
{
    public interface IPersona
    {
        Task<PersonaDTO> Insertar(PersonaDTO persona);
        Task Actualizar(PersonaDTO persona);
        Task Eliminar(int idPersona);
        Task<IEnumerable<PersonaDTO>> ObtenerPersonas();
        Task<PersonaDTO> ObtenerByIdPersona(int id);
    }
}
