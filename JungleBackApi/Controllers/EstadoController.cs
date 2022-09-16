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
    public class EstadoController : ControllerBase
    {
        private readonly IEstado _estadoRepository;

        public EstadoController(IEstado estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEstado()

        {
            var Estado = await _estadoRepository.ObtenerEstado();
            return Ok(Estado);
        }


        [HttpPost]
        public async Task<ActionResult<EstadoDTO>> EstadoAregistrar([FromForm] EstadoDTO estado)
        {
            var estadoAregistrar = await _estadoRepository.Insertar(estado);
            return Ok(estadoAregistrar);
        }


        [HttpPut]
        public async Task<ActionResult<EstadoDTO>> EliminarEstado([FromForm] EstadoDTO estado)
        {
            var estadoRegistrada = await _estadoRepository.Insertar(estado);
            return Ok(estadoRegistrada);
        }

    }
}
