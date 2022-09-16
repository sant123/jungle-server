using JungleBackCore.Interfaces;
using JungleBackInfrastructure.Repositories;
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
    public class TipoDocumentoController : ControllerBase
    {
        private readonly ITipoDocumento _tipodocumentoRepository;
        public TipoDocumentoController(ITipoDocumento tipodocumentoRepository)
        {
            _tipodocumentoRepository = tipodocumentoRepository;

        }
        [HttpGet]
        public async Task<IActionResult> GetTipoDocumento()
        {
            var TipoDocumento = await _tipodocumentoRepository.ObtenerTipoDocumento();
            return Ok(TipoDocumento);
        }
    }
}
