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
    public class UsuarioRepository: IUsuario
    {
        private readonly JungleBaseContext _context;
      

        public UsuarioRepository(JungleBaseContext context)
        {
            _context = context;
        }

        public Task Actualizar(UsuarioDTO usuario)
        {
            throw new NotImplementedException();
        }

        public Task Eliminar(int idServicio)
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioDTO> Insertar(UsuarioDTO DatoUsuario) 

        {
            Usuarios Usuario1 = new Usuarios();
            Usuario1.IdPersona = DatoUsuario.IdPersona;
            Usuario1.Usuario = DatoUsuario.Usuario;
            Usuario1.Contraseña = DatoUsuario.Password;
            _context.Usuarios.Add(Usuario1);
            await _context.SaveChangesAsync();
            DatoUsuario.Id = Usuario1.Id;
            return DatoUsuario;
        }
 
        public async Task<UsuarioDTO> ValidarIdentidad(UsuarioDTO dataUser)
        {
            var usuario = await _context.Usuarios.Where(usuario => usuario.Usuario == dataUser.Usuario && usuario.Contraseña == dataUser.Password).Select(usuario =>
                new UsuarioDTO
                {
                    Id = usuario.Id,
                    Usuario = usuario.Usuario,
                    Rol = usuario.UsuarioXrol.FirstOrDefault().IdRolNavigation.Nombre
                }
                ).FirstOrDefaultAsync();
            return usuario;
        }

        Task<IEnumerable<UsuarioDTO>> IUsuario.ObtenerUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
