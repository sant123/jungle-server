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
    public class RolesController : ControllerBase
    {
        private readonly IRoles _rolesRepository;

        public RolesController(IRoles rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var Roles = await _rolesRepository.ObtenerRoles();
            

            return Ok(Roles);
        }




        [HttpPost]
        public async Task<ActionResult<RolesDTO>> RolesAregistrar([FromForm] RolesDTO roles)
        {
            var rolesAregistrar = await _rolesRepository.Insertar(roles);
            return Ok(rolesAregistrar);
        }


        [HttpPut]
        public async Task<ActionResult<RolesDTO>> EliminarRoles([FromForm] RolesDTO roles)
        {
            var rolesRegistrada = await _rolesRepository.Insertar(roles);
            return Ok(rolesRegistrada);
        }

    }
}
