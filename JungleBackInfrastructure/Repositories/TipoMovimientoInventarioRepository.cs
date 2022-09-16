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
  public  class TipoMovimientoInventarioRepository: ITipoMovimientoInventario
    {
        private readonly JungleBaseContext _context;

        public TipoMovimientoInventarioRepository(JungleBaseContext context)
        {
            _context = context;
        }

        public async Task Actualizar(TipoMovimientoInventarioDTO tipoMovimientoInventario)
        {
            var tipoMovimientoInventarioActualizar = await _context.TipoMovimientoInventario.Where(tipoMovimientoInventario => tipoMovimientoInventario.Id == tipoMovimientoInventario.Id).FirstOrDefaultAsync();
            tipoMovimientoInventarioActualizar.Id = tipoMovimientoInventario.Id;
            tipoMovimientoInventarioActualizar.Nombre = tipoMovimientoInventario.Nombre;
            tipoMovimientoInventarioActualizar.Salida = tipoMovimientoInventario.Salida;

        }


        public async Task Eliminar(int idTipoMovimientoInventario)
        {
            var tipoMovimientoInventario = await _context.TipoMovimientoInventario.Where(tipoMovimientoInventario => tipoMovimientoInventario.Id == idTipoMovimientoInventario).FirstOrDefaultAsync();
            _context.TipoMovimientoInventario.Remove(tipoMovimientoInventario);
            await _context.SaveChangesAsync();
        }




        public async Task<TipoMovimientoInventarioDTO> Insertar(TipoMovimientoInventarioDTO datotipoMovimientoInventario)
        {
            TipoMovimientoInventario tipoMovimientoInventarioRegistrar = new TipoMovimientoInventario();
            tipoMovimientoInventarioRegistrar.Id = datotipoMovimientoInventario.Id;
            tipoMovimientoInventarioRegistrar.Nombre = datotipoMovimientoInventario.Nombre;
            tipoMovimientoInventarioRegistrar.Salida = datotipoMovimientoInventario.Salida;

            _context.TipoMovimientoInventario.Add(tipoMovimientoInventarioRegistrar);
            await _context.SaveChangesAsync();
            datotipoMovimientoInventario.Id = tipoMovimientoInventarioRegistrar.Id;
            return datotipoMovimientoInventario;
        }


        public async Task<IEnumerable<TipoMovimientoInventarioDTO>> ObtenerTipoMovimientoInventario()
        {
            var TipoMovimientoInventarioDTO = await _context.TipoMovimientoInventario.Select(tipoMovimientoInventario => new TipoMovimientoInventarioDTO
            {
                Id = tipoMovimientoInventario.Id,
                Nombre = tipoMovimientoInventario.Nombre,
                Salida = tipoMovimientoInventario.Salida,

            }).ToListAsync();

            return TipoMovimientoInventarioDTO;
        }


    }
}
