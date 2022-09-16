using JungleBackCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JungleBackCore.Interfaces
{
    public interface IProductos
    {
        Task <ProductosDTO> Insertar(ProductosDTO productos);
        Task Actualizar(ProductosDTO productos);
        Task Eliminar(int idProductos);

        Task<IEnumerable<ProductosDTO>> ObtenerProductos();

        Task<ProductosDTO>ObtenerbyIdProductos(int id);



    }
}
