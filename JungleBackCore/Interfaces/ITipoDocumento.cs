using JungleBackCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JungleBackCore.Interfaces
{
   public interface ITipoDocumento
    {
        Task<IEnumerable<TipoDocumentoDTOs>> ObtenerTipoDocumento();
    }
}
