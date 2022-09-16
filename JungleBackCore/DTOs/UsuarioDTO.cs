using System;
using System.Collections.Generic;
using System.Text;

namespace JungleBackCore.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public int IdPersona { get; set; }
        public string Rol { get; set; }
    }
}
