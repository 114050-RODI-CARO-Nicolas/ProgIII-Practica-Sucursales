using API_Sucursales_Practica.Context;
using API_Sucursales_Practica.Domain;
using API_Sucursales_Practica.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Practica_API_Sucursales.Domain;

namespace API_Sucursales_Practica.Repository
{
    public class SucursalRepository : ISucursalRepository
    {

        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public SucursalRepository(ApplicationContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }

   
        public async Task<SucursalEntity> GetSucursalMostRecentNotBuenosAiresAsync()
        {
            var sucursalMostRecentNotBsAS = await _context.Sucursales.Where(x =>
                x.Provincia.Nombre != "Buenos Aires"
            ).OrderByDescending(x => x.FechaAlta)
            .Include(x => x.Provincia)
            .Include(x => x.Tipo)
            .FirstOrDefaultAsync();

            return sucursalMostRecentNotBsAS;
        }

        public async Task<SucursalEntity> UpdateSucursalByIdAsync(SucursalEntity sucursalUpdate)
        {
            var foundSucursal = await _context.Sucursales.Where(x =>
            x.Id == sucursalUpdate.Id
            ).FirstOrDefaultAsync();

            if (foundSucursal != null)
            {
                //


            }

            return null;
        }
    }
}
