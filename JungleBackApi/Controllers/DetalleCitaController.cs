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
    public class DetalleCitaController : ControllerBase
    {
        private readonly IDetalleCita _detalledetallecitaRepository;

        public DetalleCitaController(IDetalleCita detallecitaRepository)
        {
            _detalledetallecitaRepository = detallecitaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetDetalleCita()
        {
            var DetalleCita = await _detalledetallecitaRepository.ObtenerDetalleCita();
            return Ok(DetalleCita);
        }


        [HttpPost]
        public async Task<ActionResult<DetalleCitaDTO>> DetalleCitaAregistrar([FromForm] DetalleCitaDTO detallecita)
        {
            var DetalleCitaAregistrar = await _detalledetallecitaRepository.Insertar(detallecita);
            return Ok(DetalleCitaAregistrar);
        }


        [HttpPut]
        public async Task<ActionResult<DetalleCitaDTO>> EliminarDetalleCita([FromForm] DetalleCitaDTO detallecita)
        {
            var detallecitaRegistrada = await _detalledetallecitaRepository.Insertar(detallecita);
            return Ok(detallecitaRegistrada);
        }

    }
}
