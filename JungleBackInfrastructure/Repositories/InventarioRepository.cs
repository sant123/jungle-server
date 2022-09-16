
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
    public class InventarioRepository : IInventario
    {
        private readonly JungleBaseContext _context;
        public InventarioRepository(JungleBaseContext context)
        {
            _context = context;
        }

        public async Task Actualizar(InventarioDTO inventario)
        {
            var inventariosActualizar =  _context.Inventario.Where(x => x.Id == inventario.Id).FirstOrDefault();
            inventariosActualizar.Nombre = inventario.Nombre;
            inventariosActualizar.FechaCreacion = DateTime.Now;
      await _context.SaveChangesAsync();

        }

        public async Task Eliminar(int idInventario)
        {
            var inventario = await _context.Inventario.Where(inventario => inventario.Id == idInventario).FirstOrDefaultAsync();
            _context.Inventario.Remove(inventario);
            await _context.SaveChangesAsync();

        }



        public async Task<InventarioDTO> Insertar(InventarioDTO DatoInventario)
        {
            Inventario InventarioAregistrar = new Inventario();
            InventarioAregistrar.Nombre = DatoInventario.Nombre;
            InventarioAregistrar.FechaCreacion = DateTime.Now;
            _context.Inventario.Add(InventarioAregistrar);
            await _context.SaveChangesAsync();
            DatoInventario.Id = InventarioAregistrar.Id;
            return DatoInventario;

        }
       

        public async Task<IEnumerable<InventarioDTO>> ObtenerInventario()
        {
            var InventarioDTO = await _context.Inventario.Select(Inventario => new InventarioDTO
            {
                Id = Inventario.Id,
                Nombre = Inventario.Nombre,
                FechaCreacion=Inventario.FechaCreacion
         
            }).ToListAsync();

            return InventarioDTO;
        }

        public async Task<InventarioDTO> ObtenerByIdInventario(int id)
        {
            var InventarioDTO = await _context.Inventario.Where(inventario=> inventario.Id ==id).Select(Inventario => new InventarioDTO
            {
                Id = Inventario.Id,
                Nombre = Inventario.Nombre,
                FechaCreacion = Inventario.FechaCreacion

            }).FirstOrDefaultAsync();

            return InventarioDTO;
        }

    }
}
