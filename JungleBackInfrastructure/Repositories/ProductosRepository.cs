using JungleBackCore.DTOs;
using JungleBackCore.Entities;
using JungleBackCore.Interfaces;
using JungleBackInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JungleBackInfrastructure.Repositories
{
    public class ProductosRepository : IProductos
    {
        private readonly JungleBaseContext _context;

        public ProductosRepository(JungleBaseContext context)
        {
            _context = context;
        }
        public async Task Actualizar(ProductosDTO productos)
        {
            var productosActualizar = await _context.Productos.Where(x => x.Id == productos.Id).FirstOrDefaultAsync();
            productosActualizar.Id = productos.Id;
            productosActualizar.Nombre = productos.Nombre;
            productosActualizar.ValorUnitario = productos.ValorUnitario;
            productosActualizar.RefereciaMarca = productos.RefereciaMarca;
            productosActualizar.IdTipoProducto = productos.IdTipoProducto;
            await _context.SaveChangesAsync();

        }
        public async Task Eliminar(int idProductos)
        {
            var productos = await _context.Persona.Where(productos => productos.Id == idProductos).FirstOrDefaultAsync();
            _context.Persona.Remove(productos);
            await _context.SaveChangesAsync();

        }

        public async Task<ProductosDTO> Insertar(ProductosDTO DatoProducto)
        {
            Productos ProductoAregistrar = new Productos();
            ProductoAregistrar.Nombre = DatoProducto.Nombre;
            ProductoAregistrar.ValorUnitario = DatoProducto.ValorUnitario;
            ProductoAregistrar.RefereciaMarca = DatoProducto.RefereciaMarca;
            ProductoAregistrar.IdTipoProducto = DatoProducto.IdTipoProducto;
            ProductoAregistrar.FechaCreacion = DateTime.Now;
            _context.Productos.Add(ProductoAregistrar);
            await _context.SaveChangesAsync();
            DatoProducto.Id = ProductoAregistrar.Id;
            return DatoProducto;

        }



        public async Task<IEnumerable<ProductosDTO>> ObtenerProductos()
        {
            var ProductosDTO = await _context.Productos.Select(Productos => new ProductosDTO
            {
                Id = Productos.Id,
                Nombre = Productos.Nombre,
                ValorUnitario = Productos.ValorUnitario,
                RefereciaMarca = Productos.RefereciaMarca,
                IdTipoProducto = Productos.IdTipoProducto,
                TipoProducto = Productos.IdTipoProductoNavigation.Nombre,

                FechaCreacion = DateTime.Now
            }).ToListAsync();

            return ProductosDTO;



        }


        public async Task<ProductosDTO>ObtenerbyIdProductos(int id)
        {
            var ProductosDTO = await _context.Productos.Where(Productos => Productos.Id == id).Select(Productos => new ProductosDTO

                        {
                            Id = Productos.Id,
                Nombre = Productos.Nombre,
                ValorUnitario = Productos.ValorUnitario,
                RefereciaMarca = Productos.RefereciaMarca,
                IdTipoProducto = Productos.IdTipoProducto,
                TipoProducto = Productos.IdTipoProductoNavigation.Nombre,
                FechaCreacion = DateTime.Now
            }).FirstOrDefaultAsync();

            return ProductosDTO;
        }
    }
}
