using API_Sucursales_Practica.Context;
using API_Sucursales_Practica.Domain;
using API_Sucursales_Practica.DTOs;
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

        public async Task<IEnumerable<ProvinciaEntity>> GetAllProvinciaAsync()
        {
            var allProvincias = await _context.Provincias.ToListAsync();
            return allProvincias;
        }

        public async Task<IEnumerable<TipoEntity>> GetAllTipoAsync()
        {
            var allTipos = await _context.Tipos.ToListAsync();
            return allTipos;

        }


        public async Task<IEnumerable<SucursalEntity>> GetAllSucursalAsync()
        {
           var allSucursales = await _context.Sucursales.ToListAsync();
           return allSucursales;
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

        public async Task<SucursalEntity> UpdateSucursalByIdAsync(UpdateSucursalDTO updateDTO)
        {

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
            var foundSucursal = await _context.Sucursales
           .Include(x => x.Provincia)
           .Include(x => x.Tipo)
           .FirstOrDefaultAsync(x => x.Id == Guid.Parse(updateDTO.Id));
                if (foundSucursal == null)
                {
                    return null;
                }
                _mapper.Map(updateDTO, foundSucursal);
                await _context.SaveChangesAsync();

                //Recargar la entidad

                var updatedSucursal = await _context.Sucursales
                    .Include(x => x.Provincia)
                    .Include(x => x.Tipo)
                    .FirstOrDefaultAsync(x => x.Id == foundSucursal.Id);

                await transaction.CommitAsync();
                return updatedSucursal;

            }
            catch 
            {
                await transaction.RollbackAsync();
                throw;
            }
           
        }


        public async Task<SucursalEntity> CreateSucursalAsync(CreateSucursalDTO createDTO)
        {
           using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var newSucursal = _mapper.Map<SucursalEntity>(createDTO);
                await _context.Sucursales.AddAsync(newSucursal);
                await _context.SaveChangesAsync();

                //Recargar la entidad

                var createdSucursal = await _context.Sucursales
                    .Include(x => x.Provincia)
                    .Include(x => x.Tipo)
                    .FirstOrDefaultAsync(x => x.Id == newSucursal.Id);

                await transaction.CommitAsync();
                return createdSucursal;

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }

        }

        
    }
}
