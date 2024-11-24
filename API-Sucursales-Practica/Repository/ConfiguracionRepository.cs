using API_Sucursales_Practica.Context;
using API_Sucursales_Practica.Domain;
using API_Sucursales_Practica.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_Sucursales_Practica.Repository
{
    public class ConfiguracionRepository : IConfiguracionRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public ConfiguracionRepository(ApplicationContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }

        public async Task<IEnumerable<ConfiguracionEntity>> GetAllAsync()
        {
            var configuraciones = await _context.Configuraciones.ToListAsync();
            return configuraciones;
        }
    }
}
