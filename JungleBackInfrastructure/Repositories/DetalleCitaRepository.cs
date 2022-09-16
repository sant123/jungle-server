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
    public class DetalleCitaRepository : IDetalleCita
    {
        private readonly JungleBaseContext _context;

        public DetalleCitaRepository(JungleBaseContext context)
        {
            _context = context;
        }



        public async Task Actualizar(DetalleCitaDTO detallecita)
        {
            var DetallecitaActualizar = await _context.DetalleCita.Where(detallecita => detallecita.Id == detallecita.Id).FirstOrDefaultAsync();
            DetallecitaActualizar.Id = detallecita.Id;
            DetallecitaActualizar.IdServicios = detallecita.IdServicios;
            DetallecitaActualizar.IdProductos = detallecita.IdProductos;
            DetallecitaActualizar.IdCita = detallecita.IdCita;
            DetallecitaActualizar.IdEstado = detallecita.IdEstado;
    
        }



        public async Task Eliminar(int idDetalleCita)
        {
            var detallecita = await _context.DetalleCita.Where(detallecita1 => detallecita1.Id == idDetalleCita).FirstOrDefaultAsync();
            _context.DetalleCita.Remove(detallecita);
            await _context.SaveChangesAsync();
        }

        public async Task<DetalleCitaDTO> Insertar(DetalleCitaDTO DetalledatosCita)
        {
            DetalleCita DetallecitaRegistrar = new DetalleCita();
            DetallecitaRegistrar.Id = DetalledatosCita.Id;
            DetallecitaRegistrar.IdServicios = DetalledatosCita.IdServicios;
            DetallecitaRegistrar.IdProductos = DetalledatosCita.IdProductos;
            DetallecitaRegistrar.IdCita = DetalledatosCita.IdCita;
            DetallecitaRegistrar.IdEstado = DetalledatosCita.IdEstado;
      
            _context.DetalleCita.Add(DetallecitaRegistrar);
            await _context.SaveChangesAsync();
            DetalledatosCita.Id = DetallecitaRegistrar.Id;
            return DetalledatosCita;
        }

 
        public async Task<IEnumerable<DetalleCitaDTO>> ObtenerCita()
        {
            var DetalleCitaDTO = await _context.DetalleCita.Select(detallecita => new DetalleCitaDTO
            {
                Id = detallecita.Id,
                IdServicios = detallecita.IdServicios,
                IdProductos = detallecita.IdProductos,
                IdCita = detallecita.IdCita,
                IdEstado = detallecita.IdEstado,
              
            }).ToListAsync();

            return DetalleCitaDTO;
        }

        public Task<IEnumerable<DetalleCitaDTO>> ObtenerDetalleCita()
        {
            throw new NotImplementedException();
        }

    
    }

}
