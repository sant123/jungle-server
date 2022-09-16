using JungleBackCore.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JungleBackApi.Controllers
{
    public interface IServicios
    { 
        Task <ServiciosDTOs> Insertar(ServiciosDTOs servicios);
        Task Actualizar(ServiciosDTOs servicios);
        Task Eliminar(int idServicio);

        Task<IEnumerable<ServiciosDTOs>> ObtenerServicios();

        Task<ServiciosDTOs> ObtenerByIdServicios(int id);

    }
}
