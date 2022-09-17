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
    public class PersonaRepository : IPersona
    {
        private readonly JungleBaseContext _context;

        public PersonaRepository(JungleBaseContext context)
        {
            _context = context;
        }

        public async Task Actualizar(PersonaDTO persona)
        {
            var personaActualizar = await _context.Persona.Where(x => x.Id == persona.Id).FirstOrDefaultAsync();
            personaActualizar.IdTipoDocumento = persona.IdTipoDocumento;
            personaActualizar.Nombre = persona.Nombre;
            personaActualizar.Apellido = persona.Apellido;
            personaActualizar.Direccion = persona.Direccion;
            personaActualizar.Correo = persona.Correo;
            personaActualizar.Telefono = persona.Telefono;
            personaActualizar.FechaNacimiento = DateTime.Now;
            personaActualizar.NumeroDocumento = persona.NumeroDocumento;
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int idPersona)
        {
            var persona = await _context.Persona.Where(persona => persona.Id == idPersona).FirstOrDefaultAsync();
            _context.Persona.Remove(persona);
            await _context.SaveChangesAsync();
        }

        public async Task<PersonaDTO> Insertar(PersonaDTO datosPersona)
        {
            Persona personaARegistrar = new Persona();
            personaARegistrar.IdTipoDocumento = datosPersona.IdTipoDocumento;
            personaARegistrar.Nombre = datosPersona.Nombre;
            personaARegistrar.Apellido = datosPersona.Apellido;
            personaARegistrar.Direccion = datosPersona.Direccion;
            personaARegistrar.Correo = datosPersona.Correo;
            personaARegistrar.Telefono = datosPersona.Telefono;
            personaARegistrar.FechaNacimiento = datosPersona.FechaNacimiento;
            personaARegistrar.NumeroDocumento = datosPersona.NumeroDocumento;
            _context.Persona.Add(personaARegistrar);
            await _context.SaveChangesAsync();
            datosPersona.Id = personaARegistrar.Id;
            return datosPersona;
        }

        public Task ObtenerPersona()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PersonaDTO>> ObtenerPersonas()
        {
            var PersonaDTO = await _context.Persona.Select(persona => new PersonaDTO {
                Id = persona.Id,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Telefono = persona.Telefono,
                Correo = persona.Correo,
                Direccion = persona.Direccion,
                IdTipoDocumento = persona.IdTipoDocumento,
                FechaNacimiento = persona.FechaNacimiento,
                NumeroDocumento = persona.NumeroDocumento,
                RolUsuario = persona.Usuarios.FirstOrDefault().UsuarioXrol.FirstOrDefault().IdRolNavigation.Nombre,
                IdUsuario = persona.Usuarios.FirstOrDefault().Id,
                Usuario = persona.Usuarios.FirstOrDefault().Usuario
            }).ToListAsync();

            return PersonaDTO;
        }

        public async Task<PersonaDTO> ObtenerByIdPersona(int id)
        {
            var PersonaDTO = await _context.Persona.Where(persona => persona.Id ==id).Select(Persona => new PersonaDTO
            {
                Id = Persona.Id,
                Nombre = Persona.Nombre,
                Apellido = Persona.Apellido,
                Telefono = Persona.Telefono,
                Correo = Persona.Correo,
                Direccion = Persona.Direccion,
                IdTipoDocumento = Persona.IdTipoDocumento,
                FechaNacimiento = DateTime.Now,
                NumeroDocumento = Persona.NumeroDocumento

            }).FirstOrDefaultAsync();

            return PersonaDTO;
        }
    } 
}
