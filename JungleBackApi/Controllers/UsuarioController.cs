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

    public class UsuarioController : ControllerBase
    {
        private readonly IPersona _personaRepository;
        private readonly IUsuario _usuarioRepository;
        private readonly IUsuarioXrol _UsuarioXrolRepository;



        public UsuarioController(IPersona personaRepository,IUsuario usuarioRepository, IUsuarioXrol UsuarioXrolRepository)
        {
            _personaRepository = personaRepository;
            _usuarioRepository = usuarioRepository;
            _UsuarioXrolRepository = UsuarioXrolRepository;
        } 

        [HttpGet]
        public async Task<IActionResult> GetPersonas()
        {
            var Personas = await _personaRepository.ObtenerPersonas();
            return Ok(Personas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdPersona(int id)
        {
            var Persona = await _personaRepository.ObtenerByIdPersona(id);
            return Ok(Persona);
        }


        [HttpPost]
        public async Task<ActionResult<PersonaDTO>> LoginByPassword([FromForm] UsuarioDTO dataUser)
        {
            var usuarioLogin = await _usuarioRepository.ValidarIdentidad(dataUser);
            return Ok(usuarioLogin);
        }


        [HttpDelete]
        public async Task<ActionResult<PersonaDTO>> EliminarPersona([FromForm] PersonaDTO persona)
        {
            var personaRegistrada = await _personaRepository.Insertar(persona);
            return Ok(personaRegistrada);
        }


        [HttpPut]
        public async Task<ActionResult<PersonaDTO>> ActualizarPersona([FromForm] PersonaDTO persona)
        {
            await _personaRepository.Actualizar(persona);
            return Ok();
        }

    }
}
