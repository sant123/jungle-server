using JungleBackCore.DTOs;
using JungleBackCore.Entities;
using JungleBackCore.Interfaces;

using JungleBackInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBackInfrastructure.Repositories
{
    public class EstadoRepository : IEstado
    {
        private readonly JungleBaseContext _context;

        public EstadoRepository(JungleBaseContext context)
        {
            _context = context;
        }



        public async Task Actualizar(EstadoDTO estado)
        {
            var estadoActualizar = await _context.Estado.Where(estado => estado.Id == estado.Id).FirstOrDefaultAsync();
            estadoActualizar.Id = estado.Id;
            estadoActualizar.Nombre = estado.Nombre;
            estadoActualizar.Descripcion = estado.Descripcion;
            


        }

        public async Task Eliminar(int idEstado)
        {
            var estado = await _context.Estado.Where(estado => estado.Id == idEstado).FirstOrDefaultAsync();
            _context.Estado.Remove(estado);
            await _context.SaveChangesAsync();
        }

        public async Task<EstadoDTO> Insertar(EstadoDTO datoestado)
        {
            Estado estadoRegistrar = new Estado();
            estadoRegistrar.Id = datoestado.Id;
            estadoRegistrar.Nombre = datoestado.Nombre;
            estadoRegistrar.Descripcion = datoestado.Descripcion;

            _context.Estado.Add(estadoRegistrar);
            await _context.SaveChangesAsync();
            datoestado.Id = estadoRegistrar.Id;
            return datoestado;
        }

    

        public async Task<IEnumerable<EstadoDTO>> ObtenerEstado()
        {
            var EstadoDTO = await _context.Estado.Select(estado => new EstadoDTO
            {
                Id = estado.Id,
                Nombre = estado.Nombre,
                Descripcion = estado.Descripcion,
            
            }).ToListAsync();

            return EstadoDTO;
        }


    }

  
}
