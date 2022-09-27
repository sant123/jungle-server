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
            citaActualizar.HoraInicio = cita.HoraInicio;
            citaActualizar.HoraFin = cita.HoraFin;
            citaActualizar.Fecha = cita.Fecha;
            citaActualizar.Sede = cita.Sede;
            citaActualizar.IdUsuarioAgenda = cita.IdUsuarioAgenda;
            citaActualizar.IdUsuarioAtiende = cita.IdUsuarioAtiende;
            citaActualizar.IdEstado = cita.IdEstado;
            await _context.SaveChangesAsync();
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
                IdUsuarioAgenda = cita.IdUsuarioAgenda,
                IdUsuarioAtiende = cita.IdUsuarioAtiende,
                IdEstado = cita.IdEstado,
                Barbero = cita.IdUsuarioAtiendeNavigation.IdPersonaNavigation.Nombre + " " + cita.IdUsuarioAtiendeNavigation.IdPersonaNavigation.Apellido,
                Cliente = cita.IdUsuarioAgendaNavigation.IdPersonaNavigation.Nombre + " " + cita.IdUsuarioAgendaNavigation.IdPersonaNavigation.Apellido

            }).ToListAsync();

            return CitaDTO;
        }

        public async Task<CitaDTO> ObtenerByIdCita(int id)
        {
            var CitaDTO = await _context.Cita.Where(cita => cita.Id == id).Select(Cita => new CitaDTO

            {
                Id = Cita.Id,
                HoraInicio = Cita.HoraInicio,
                HoraFin = Cita.HoraFin,
                Fecha = Cita.Fecha,
                Sede = Cita.Sede,
                IdUsuarioAgenda = Cita.IdUsuarioAgenda,
                IdUsuarioAtiende = Cita.IdUsuarioAtiende,
                IdEstado = Cita.IdEstado
            }).FirstOrDefaultAsync();

            return CitaDTO;
        }

        public async Task<IEnumerable<dynamic>> ObtenerBarberos()
        {
            var Barberos = await (from p in _context.Persona
                                  join u in _context.Usuarios
                                  on p.Id equals u.IdPersona
                                  join uxr in _context.UsuarioXrol
                                  on u.Id equals uxr.IdUsuario
                                  join r in _context.Roles
                                  on uxr.IdRol equals r.Id
                                  where r.Nombre == "Barbero"
                                  select new
                                  {
                                      Id = u.Id,
                                      Nombre = p.Nombre,
                                      Apellido = p.Apellido
                                  }
            ).Distinct().ToListAsync();


            return Barberos;
        }

        public async Task<IEnumerable<dynamic>> ObtenerClientes()
        {
            var Clientes = await (from p in _context.Persona
                                  join u in _context.Usuarios
                                  on p.Id equals u.IdPersona
                                  join uxr in _context.UsuarioXrol
                                  on u.Id equals uxr.IdUsuario
                                  join r in _context.Roles
                                  on uxr.IdRol equals r.Id
                                  where r.Nombre == "Cliente"
                                  select new
                                  {
                                      Id = u.Id,
                                      Nombre = p.Nombre,
                                      Apellido = p.Apellido
                                  }
            ).Distinct().ToListAsync();


            return Clientes;
        }
    }
}
