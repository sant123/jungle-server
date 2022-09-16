using JungleBackApi.Controllers;
using JungleBackCore.DTOs;
using JungleBackCore.Entities;
using JungleBackInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JungleBackInfrastructure.Repositories
{
    public class ServiciosRepository: IServicios
    {
        private readonly JungleBaseContext _context;
      

        public ServiciosRepository(JungleBaseContext context)
        {
            _context = context;
        }
        public async Task Actualizar(ServiciosDTOs servicios)
        {
           var serviciosActualizar= await _context.Servicios.Where(x => x.Id == servicios.Id).FirstOrDefaultAsync();
           serviciosActualizar.Nombre = servicios.Nombre;
            serviciosActualizar.Valor = servicios.Valor;
            await _context.SaveChangesAsync();
      }

        public async Task Eliminar(int idServicios)
        {
            var servicios = await _context.Servicios.Where(servicios => servicios.Id == idServicios).FirstOrDefaultAsync();
            _context.Servicios.Remove(servicios);
            await _context.SaveChangesAsync();
        }

        public async Task<ServiciosDTOs> Insertar(ServiciosDTOs Datoservicios) 

        {
            Servicios servicios1 = new Servicios();
            servicios1.Nombre = Datoservicios.Nombre;
            servicios1.Valor = Datoservicios.Valor;
            servicios1.FechaCreacion = DateTime.Now;
            _context.Servicios.Add(servicios1);
            await _context.SaveChangesAsync();
            Datoservicios.Id = servicios1.Id;
            return Datoservicios;

        }
        public async Task<IEnumerable<ServiciosDTOs>> ObtenerServicios() 
        {
            var ServiciosDTOs = await _context.Servicios.Select(Servicios => new ServiciosDTOs{
                Id = Servicios.Id,
                Nombre= Servicios.Nombre,
                Valor = Servicios.Valor,
                FechaCreacion = Servicios.FechaCreacion,
            }).ToListAsync();

            return ServiciosDTOs;
        }
         

        public async Task<ServiciosDTOs> ObtenerByIdServicios(int id)
        {
            var ServiciosDTOs = await _context.Servicios.Where (Servicios => Servicios.Id ==id).Select(Servicios => new ServiciosDTOs

                        {
                    Id = Servicios.Id,
                Nombre = Servicios.Nombre,
                Valor = Servicios.Valor,
                FechaCreacion = Servicios.FechaCreacion,
            }).FirstOrDefaultAsync();

            return ServiciosDTOs;
        }
    }
}
