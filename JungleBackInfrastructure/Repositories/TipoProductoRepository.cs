using JungleBackCore.DTOs;
using JungleBackCore.Interfaces;
using JungleBackInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JungleBackInfrastructure.Repositories
{
    public class TipoProductoRepository : ITipoProducto
    {
        private readonly JungleBaseContext _context;
        public TipoProductoRepository(JungleBaseContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<TipoProductoDTOs>> ObtenerTipoProducto()
        {
            var TipoProductoDTOs = await _context.TipoProducto.Select(TipoProducto => new TipoProductoDTOs
                {

                Id = TipoProducto.Id,
                Nombre = TipoProducto.Nombre

            }).ToListAsync();
            return TipoProductoDTOs;
        }
    }
}
