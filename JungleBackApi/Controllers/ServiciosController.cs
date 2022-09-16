using JungleBackCore.DTOs;
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
    public class serviciosController : ControllerBase
    {
        private readonly IServicios _serviciosRepository;
        public serviciosController(IServicios serviciosRepository)
        {
            _serviciosRepository = serviciosRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetServicios()
        {
            var Servicios = await _serviciosRepository.ObtenerServicios();
            return Ok(Servicios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdServicios(int id)
        {
            var Servicios = await _serviciosRepository.ObtenerByIdServicios(id);
            return Ok(Servicios);
        }


        [HttpPost]

        public async Task<ActionResult <ServiciosDTOs>> servicios1([FromForm] ServiciosDTOs servicios)
        {
            var servicios1 = await _serviciosRepository.Insertar(servicios);
            return Ok(servicios1);
        }


        [HttpPut]
        public async Task<ActionResult<ServiciosDTOs>> ActualizarServicios([FromForm] ServiciosDTOs servicios)
        {
            await _serviciosRepository.Actualizar(servicios);
            return Ok();
        }
    }
}
