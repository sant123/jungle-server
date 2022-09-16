using JungleBackCore.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JungleBackApi.Controllers
{
    public interface IUsuario
    { 
        Task <UsuarioDTO> Insertar(UsuarioDTO usuario);
        Task Actualizar(UsuarioDTO usuario);
        Task Eliminar(int idServicio);
        Task <UsuarioDTO> ValidarIdentidad(UsuarioDTO usuario);

        Task<IEnumerable<UsuarioDTO>> ObtenerUsuario();
    }
}
