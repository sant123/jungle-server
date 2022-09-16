using JungleBackCore.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JungleBackApi.Controllers
{
    public interface IUsuarioXrol
    { 
        Task <UsuarioXrolDTO> Insertar(UsuarioXrolDTO usuarioXrol);
        Task Actualizar(UsuarioXrolDTO usuarioXrol);
        Task Eliminar(int idUsuario);
        Task ValidarIdentidad(UsuarioXrolDTO usuarioXrol);

        Task<IEnumerable<UsuarioXrolDTO>> ObtenerUsuarioXrol();

        Task<UsuarioXrolDTO> ObtenerByIdUsuarioXrol(int id);
    }
}
