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
    public class TipoMovimientoInventarioController : ControllerBase
    {
        private readonly ITipoMovimientoInventario _tipoMovimientoInventarioRepository;

        public TipoMovimientoInventarioController(ITipoMovimientoInventario tipoMovimientoInventarioRepository)
        {
            _tipoMovimientoInventarioRepository = tipoMovimientoInventarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTipoMovimientoInventario()
        {
            var TipoMovimientoInventario = await _tipoMovimientoInventarioRepository.ObtenerTipoMovimientoInventario();
            return Ok(TipoMovimientoInventario);
        }

        [HttpPost]
        public async Task<ActionResult<TipoMovimientoInventarioDTO>> ProductoAregistrar([FromForm] TipoMovimientoInventarioDTO tipoMovimientoInventario)
        {
            var TipoMovimientoInventarioAregistrar = await _tipoMovimientoInventarioRepository.Insertar(tipoMovimientoInventario);
            return Ok(TipoMovimientoInventarioAregistrar);
        }
    }
}
