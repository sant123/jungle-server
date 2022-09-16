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
    public class InventarioController : ControllerBase
    {
        private readonly IInventario _inventarioRepository;
        public InventarioController(IInventario inventarioRepository)
        {
            _inventarioRepository = inventarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetInventario() 
        {
            var Inventario = await _inventarioRepository.ObtenerInventario();
            return Ok(Inventario);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdInventario(int id)
        {
            var Inventario = await _inventarioRepository.ObtenerByIdInventario(id);
            return Ok(Inventario);
        }


        [HttpPost]
        public async Task<ActionResult<InventarioDTO>> RegistrarInventario([FromForm] InventarioDTO inventario)
        {
            var inventarioRegistrado = await _inventarioRepository.Insertar(inventario);
            return Ok(inventarioRegistrado);
        }

        [HttpPut]
        public async Task<ActionResult<InventarioDTO>> ActualizarInventario([FromForm] InventarioDTO inventario)
        {
             await _inventarioRepository.Actualizar(inventario);
            return Ok();
        }
    }
}
