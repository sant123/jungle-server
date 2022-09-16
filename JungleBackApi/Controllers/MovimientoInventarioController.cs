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
    public class MovimientoInventarioController : ControllerBase
    {
        private readonly IMovimientoInventario _movimientoinventarioRepository;
        public MovimientoInventarioController(IMovimientoInventario movimientoinventarioRepository)
        {
            _movimientoinventarioRepository = movimientoinventarioRepository;
        }

     

        [HttpGet("{idInventario}")]
        public async Task<IActionResult> GetMovimientoInventario(int idInventario)
        {
            var Movimientoinventario = await _movimientoinventarioRepository.ObtenerMovimientoInventario(idInventario);
            return Ok(Movimientoinventario);
        }


        [HttpPost]
        public async Task<ActionResult<MovimientoInventarioDTO>> RegistrarMovimientoInventario([FromForm] MovimientoInventarioDTO movimientoinventario)
        {
            var movimientoinventarioRegistrado = await _movimientoinventarioRepository.Insertar(movimientoinventario);
            return Ok(movimientoinventarioRegistrado);
        }

        [HttpPut]
        public async Task<ActionResult<MovimientoInventarioDTO>> EliminarInventario([FromForm] MovimientoInventarioDTO movimientoinventario)
        {
            var movimientoinventarioRegistrado = await _movimientoinventarioRepository.Insertar(movimientoinventario);
            return Ok(movimientoinventarioRegistrado);
        }
    }
}
