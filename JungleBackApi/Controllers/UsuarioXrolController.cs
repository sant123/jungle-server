using JungleBackCore.DTOs;
using JungleBackCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioXrolController : ControllerBase
    {
        private readonly IUsuarioXrol _usuarioxrolRepository;





        public UsuarioXrolController(IUsuarioXrol usuarioxrolRepository, IUsuario usuarioRepository)
        {
            _usuarioxrolRepository = usuarioxrolRepository;
          


        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarioXrol()
        {
            var UsuarioXrol = await _usuarioxrolRepository.ObtenerUsuarioXrol();
            return Ok(UsuarioXrol);
        }



        [HttpPost]
        public async Task<ActionResult<UsuarioXrolDTO>> UsuarioXrolAregistrar([FromForm] UsuarioXrolDTO usuarioXrol)
        {
            var UsuarioXrolAregistrar = await _usuarioxrolRepository.Insertar(usuarioXrol);
            return Ok(UsuarioXrolAregistrar);
        }


        [HttpPut]
        public async Task<ActionResult<UsuarioXrolDTO>> EliminarUsuarioXrol([FromForm] UsuarioXrolDTO usuarioXrol)
        {
            var UsuarioXrolRegistrada = await _usuarioxrolRepository.Insertar(usuarioXrol);
            return Ok(UsuarioXrolRegistrada);
        }

    }
}
