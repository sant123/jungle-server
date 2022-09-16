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
    public class CitaRepository : ICita
    {
        private readonly JungleBaseContext _context;

        public CitaRepository(JungleBaseContext context)
        {
            _context = context;
        }



        public async Task Actualizar(CitaDTO cita)
        {
            var citaActualizar = await _context.Cita.Where(x => x.Id == cita.Id).FirstOrDefaultAsync();
            citaActualizar.Id = cita.Id;
            citaActualizar.HoraInicio = cita.HoraInicio;
            citaActualizar.HoraFin = cita.HoraFin;
            citaActualizar.Fecha = cita.Fecha;
            citaActualizar.Sede = cita.Sede;
            citaActualizar.Direccion = cita.Direccion;
            citaActualizar.IdDetalleCita = cita.IdDetalleCita;
            citaActualizar.IdUsuarioAgenda = cita.IdUsuarioAgenda;
            citaActualizar.IdUsuarioAtiende = cita.IdUsuarioAtiende;
            citaActualizar.IdEstado = cita.IdEstado;


        }

        public async Task Eliminar(int idCita)
        {
            var cita = await _context.Cita.Where(cita => cita.Id == idCita).FirstOrDefaultAsync();
            _context.Cita.Remove(cita);
            await _context.SaveChangesAsync();
        }

        public async Task<CitaDTO> Insertar(CitaDTO datosCita)
        {
            Cita citaRegistrar = new Cita();
            citaRegistrar.Id = datosCita.Id;
            citaRegistrar.HoraInicio = datosCita.HoraInicio;
            citaRegistrar.HoraFin = datosCita.HoraFin;
            citaRegistrar.Fecha = datosCita.Fecha;
            citaRegistrar.Sede = datosCita.Sede;
            citaRegistrar.Direccion = datosCita.Direccion;
            citaRegistrar.IdDetalleCita = datosCita.IdDetalleCita;
            citaRegistrar.IdUsuarioAgenda = datosCita.IdUsuarioAgenda;
            citaRegistrar.IdUsuarioAtiende = datosCita.IdUsuarioAtiende;
            citaRegistrar.IdEstado = datosCita.IdEstado;
            _context.Cita.Add(citaRegistrar);
            await _context.SaveChangesAsync();
            datosCita.Id = citaRegistrar.Id;
            return datosCita;
        }

      

        public async Task<IEnumerable<CitaDTO>> ObtenerCita()
        {
            var CitaDTO = await _context.Cita.Select(cita => new CitaDTO
            {
                Id = cita.Id,
                HoraInicio = cita.HoraInicio,
                HoraFin = cita.HoraFin,
                Fecha = cita.Fecha,
                Sede = cita.Sede,
                Direccion = cita.Direccion,
                IdDetalleCita = cita.IdDetalleCita,
                IdUsuarioAgenda = cita.IdUsuarioAgenda,
                IdUsuarioAtiende = cita.IdUsuarioAtiende,
                IdEstado = cita.IdEstado
            }).ToListAsync();

            return CitaDTO;
        }




        public async Task<CitaDTO> ObtenerByIdCita(int id)
        {
            var CitaDTO = await _context.Cita.Where(cita => cita.Id == id). Select(Cita => new CitaDTO

                {
                       Id = Cita.Id,
                HoraInicio = Cita.HoraInicio,
                HoraFin = Cita.HoraFin,
                Fecha = Cita.Fecha,
                Sede = Cita.Sede,
                Direccion = Cita.Direccion,
                IdDetalleCita = Cita.IdDetalleCita,
                IdUsuarioAgenda = Cita.IdUsuarioAgenda,
                IdUsuarioAtiende = Cita.IdUsuarioAtiende,
                IdEstado = Cita.IdEstado
            }).FirstOrDefaultAsync();

            return CitaDTO;
        }


    }

}
