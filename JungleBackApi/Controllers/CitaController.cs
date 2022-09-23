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
    public class CitaController : ControllerBase
    {
        private readonly ICita _citaRepository;

        public CitaController(ICita citaRepository)
        {
            _citaRepository = citaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCita()
        {
            var Cita = await _citaRepository.ObtenerCita();
            return Ok(Cita);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCita(int id)
        {
            var Cita = await _citaRepository.ObtenerByIdCita(id);
            return Ok(Cita);
        }

        [HttpPost]
        public async Task<ActionResult<CitaDTO>> CitaAregistrar([FromForm] CitaDTO cita)
        {
            cita.IdEstado = 1;
            var CitaAregistrar = await _citaRepository.Insertar(cita);
            return Ok(CitaAregistrar);
        }

        [HttpPut]
        public async Task<ActionResult<CitaDTO>> ActualizarCita([FromForm] CitaDTO cita)
        {
            await _citaRepository.Actualizar(cita);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<CitaDTO>> EliminarCita([FromForm] CitaDTO cita)
        {
            var citaRegistrada = await _citaRepository.Insertar(cita);
            return Ok(citaRegistrada);
        }

        // api/[controller]/Barberos
        [HttpGet]
        [Route("Barberos")]
        public async Task<ActionResult<dynamic>> ObtenerBarberos() {
            var Barberos = await _citaRepository.ObtenerBarberos();
            return Ok(Barberos);
        }

        // api/[controller]/Clientes
        [HttpGet]
        [Route("Clientes")]
        public async Task<ActionResult<dynamic>> ObtenerClientes() {
            var Clientes = await _citaRepository.ObtenerClientes();
            return Ok(Clientes);
        }
    }
}
