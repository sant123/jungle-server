
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
    public class MovimientoInventarioRepository : IMovimientoInventario
    {
        private readonly JungleBaseContext _context;
        public MovimientoInventarioRepository(JungleBaseContext context)
        {
            _context = context;
        }

        public async Task Actualizar(MovimientoInventarioDTO movimientoinventario)
        {
            var movimientoinventariosActualizar = await _context.MovimientoInventario.Where(movimientoinventario => movimientoinventario.Id == movimientoinventario.Id).FirstOrDefaultAsync();
            movimientoinventariosActualizar.Id = movimientoinventario.Id;
            movimientoinventariosActualizar.Cantidad = movimientoinventario.Cantidad;
            movimientoinventariosActualizar.IdProductos = movimientoinventario.IdProductos;
            movimientoinventariosActualizar.IdInventario = movimientoinventario.IdInventario;
            movimientoinventariosActualizar.IdTipoMovimientoInventario = movimientoinventario.IdTipoMovimientoInventario;
            movimientoinventariosActualizar.FechaCreacion = movimientoinventario.FechaCreacion;

            _ = _context.SaveChangesAsync();

        }


        public async Task Eliminar(int idMovimientoInventario)
        {
            var movimientoinventario = await _context.MovimientoInventario.Where(movimientoinventario => movimientoinventario.Id == idMovimientoInventario).FirstOrDefaultAsync();
            _context.MovimientoInventario.Remove(movimientoinventario);
            await _context.SaveChangesAsync();

        }


        public async Task<MovimientoInventarioDTO> Insertar(MovimientoInventarioDTO DatoMovimientoInventario)
        {
            MovimientoInventario MovimientoInventarioAregistrar = new MovimientoInventario();
            MovimientoInventarioAregistrar.Cantidad = DatoMovimientoInventario.Cantidad;
            MovimientoInventarioAregistrar.IdInventario = DatoMovimientoInventario.IdInventario;
            MovimientoInventarioAregistrar.IdProductos = DatoMovimientoInventario.IdProductos;
            MovimientoInventarioAregistrar.IdTipoMovimientoInventario = DatoMovimientoInventario.IdTipoMovimientoInventario;
            MovimientoInventarioAregistrar.FechaCreacion = DateTime.Now;
            _context.MovimientoInventario.Add(MovimientoInventarioAregistrar);
            await _context.SaveChangesAsync();
            DatoMovimientoInventario.Id = MovimientoInventarioAregistrar.Id;
            return DatoMovimientoInventario;

        }

     

        public async Task<IEnumerable<MovimientoInventarioDTO>> ObtenerMovimientoInventario(int idInventario)
        {
            var MovimientoInventarioDTO = await _context.MovimientoInventario.Where(inventario=> inventario.IdInventario == idInventario).Select(Movimientoiinventario => new MovimientoInventarioDTO
            {
                Id = Movimientoiinventario.Id,
                Cantidad = Movimientoiinventario.Cantidad,
                IdProductos = Movimientoiinventario.IdProductos,
                NombreProducto = Movimientoiinventario.IdProductosNavigation.Nombre,
                NombreTipoMovimiento = Movimientoiinventario.IdTipoMovimientoInventarioNavigation.Nombre,
                IdInventario = Movimientoiinventario.IdInventario,
                IdTipoMovimientoInventario = Movimientoiinventario.IdTipoMovimientoInventario,
                FechaCreacion = Movimientoiinventario.FechaCreacion,

            }).ToListAsync();

            return MovimientoInventarioDTO;
        }

      
    }
}
