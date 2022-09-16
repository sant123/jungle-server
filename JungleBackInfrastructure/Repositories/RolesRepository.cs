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
    public class RolesRepository : IRoles
    {
        private readonly JungleBaseContext _context;

        public RolesRepository(JungleBaseContext context)
        {
            _context = context;
        }



        public async Task Actualizar(RolesDTO roles)
        {
            var rolesActualizar = await _context.Roles.Where(r => r.Id == roles.Id).FirstOrDefaultAsync();
            rolesActualizar.Id = roles.Id;
            rolesActualizar.Nombre = roles.Nombre;
            rolesActualizar.Descripcion = roles.Descripcion;
            


        }

        public async Task Eliminar(int idRoles)
        {
            var roles = await _context.Roles.Where(roles => roles.Id == idRoles).FirstOrDefaultAsync();
            _context.Roles.Remove(roles);
            await _context.SaveChangesAsync();
        }

        public async Task<RolesDTO> Insertar(RolesDTO datoroles)
        {
            Roles rolesRegistrar = new Roles();
            rolesRegistrar.Id = datoroles.Id;
            rolesRegistrar.Nombre = datoroles.Nombre;
            rolesRegistrar.Descripcion = datoroles.Descripcion;

            _context.Roles.Add(rolesRegistrar);
            await _context.SaveChangesAsync();
            datoroles.Id = rolesRegistrar.Id;
            return datoroles;
        }

    

        public async Task<IEnumerable<RolesDTO>> ObtenerRoles()
        {
            var RolesDTO = await _context.Roles.Select(roles => new RolesDTO
            {
                Id = roles.Id,
                Nombre = roles.Nombre,
                Descripcion = roles.Descripcion,
            
            }).ToListAsync();

            return RolesDTO;
        }


        public async Task<RolesDTO> ObtenerByIdRoles(int id)
        {
            var RolesDTO = await _context.Roles.Where(Roles => Roles.Id == id).Select(Roles => new RolesDTO

            {
                Id = Roles.Id,
                Nombre = Roles.Nombre,
                Descripcion = Roles.Descripcion,
            }).FirstOrDefaultAsync();

            return RolesDTO;
        }
    }

}
