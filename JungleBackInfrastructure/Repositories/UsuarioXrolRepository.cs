using JungleBackApi.Controllers;
using JungleBackCore.DTOs;
using JungleBackCore.Entities;
using JungleBackInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JungleBackInfrastructure.Repositories
{
    public class UsuarioXrolRepository: IUsuarioXrol
    {
        private readonly JungleBaseContext _context;
      

        public UsuarioXrolRepository(JungleBaseContext context)
        {
            _context = context;
        }

        public async Task Actualizar(UsuarioXrolDTO usuarioXrol)
        {
            var usuarioXrolActualizar = await _context.UsuarioXrol.Where(u => u.Id == usuarioXrol.Id).FirstOrDefaultAsync();
            usuarioXrolActualizar.Id = usuarioXrol.Id;
            usuarioXrolActualizar.IdRol = usuarioXrol.IdRol;
            usuarioXrolActualizar.IdUsuario = usuarioXrol.IdUsuario;
            await _context.SaveChangesAsync();


        }

        public async Task Eliminar(int idUsuario)
        {
            var usuarioXrol = await _context.UsuarioXrol.Where(usuarioXrol => usuarioXrol.Id == idUsuario).FirstOrDefaultAsync();
            _context.UsuarioXrol.Remove(usuarioXrol);
            await _context.SaveChangesAsync();
        }

        public async Task<UsuarioXrolDTO> Insertar(UsuarioXrolDTO DatousuarioXrol) 

        {
            UsuarioXrol Usuariorol = new UsuarioXrol();
            Usuariorol.Id = DatousuarioXrol.Id;
            Usuariorol.IdRol = DatousuarioXrol.IdRol;
            Usuariorol.IdUsuario = DatousuarioXrol.IdUsuario;
            _context.UsuarioXrol.Add(Usuariorol);
            await _context.SaveChangesAsync();
            DatousuarioXrol.Id = Usuariorol.Id;
            return DatousuarioXrol;
        }

        public Task ValidarIdentidad(UsuarioXrolDTO usuarioXrol)
        {
            throw new NotImplementedException();
        }



        public async Task<IEnumerable<UsuarioXrolDTO>> ObtenerUsuarioXrol()
        {
            var UsuarioXrolDTO = await _context.UsuarioXrol.Select(usuarioXrol => new UsuarioXrolDTO
            {
                Id = usuarioXrol.Id,
                IdRol = usuarioXrol.IdRol,
                IdUsuario = usuarioXrol.IdUsuario,
           
            }).ToListAsync();

            return UsuarioXrolDTO;
        }


       public async Task<UsuarioXrolDTO> ObtenerByIdUsuarioXrol(int id)
        {
            var UsuarioXrolDTO = await _context.UsuarioXrol.Where(usuarioXrol => usuarioXrol.Id == id).Select(usuarioXrol => new UsuarioXrolDTO
            {
                Id = usuarioXrol.Id,
                IdRol = usuarioXrol.IdRol,
                IdUsuario = usuarioXrol.IdUsuario,

            }).FirstOrDefaultAsync();

            return UsuarioXrolDTO;
        }


    }
}
