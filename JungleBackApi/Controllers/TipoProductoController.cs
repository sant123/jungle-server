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
    public class TipoProductoController : ControllerBase
    {
        private readonly ITipoProducto _tipoproductoRepository;

        public TipoProductoController(ITipoProducto tipoproductoRepository) 
        {
            _tipoproductoRepository = tipoproductoRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetTipoProducto()
        {
            var TipoProducto = await _tipoproductoRepository.ObtenerTipoProducto();
            return Ok(TipoProducto);
        }
    }

}
