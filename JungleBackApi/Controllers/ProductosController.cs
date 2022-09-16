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
    public class ProductosController : ControllerBase
    {
        private readonly IProductos _productosRepository;

        public ProductosController(IProductos productosRepository)
        {
            _productosRepository = productosRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var Productos = await _productosRepository.ObtenerProductos();
            return Ok(Productos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerByIdProductos(int id)
        {
            var Productos = await _productosRepository.ObtenerbyIdProductos(id);
            return Ok(Productos);
        }

        [HttpPost]
        public async Task<ActionResult<ProductosDTO>> ProductoAregistrar([FromForm] ProductosDTO productos)
        {
            var ProductoAregistrar = await _productosRepository.Insertar(productos);
            return Ok(ProductoAregistrar);
        }

        [HttpPut]
        public async Task<ActionResult<ProductosDTO>> ActualizarProducto([FromForm] ProductosDTO productos)
        {
            await _productosRepository.Actualizar(productos);
            return Ok();
        }
    }
}
