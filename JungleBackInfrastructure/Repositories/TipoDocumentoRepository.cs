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
     public class TipoDocumentoRepository :ITipoDocumento
    {
        private readonly JungleBaseContext _context;
        public TipoDocumentoRepository(JungleBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TipoDocumentoDTOs>> ObtenerTipoDocumento()
        {
            var TipoDocumentoDTOs = await _context.TipoDocumento.Select(TipoDocumento => new TipoDocumentoDTOs
            {
                Id = TipoDocumento.Id,
                Nombre = TipoDocumento.Nombre,
                Descripcion = TipoDocumento.Descripcion
            }).ToListAsync();

            return TipoDocumentoDTOs;
        }

    }
}
