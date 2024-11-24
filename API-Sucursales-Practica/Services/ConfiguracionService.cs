using API_Sucursales_Practica.DTOs;
using API_Sucursales_Practica.Repository.Interfaces;
using API_Sucursales_Practica.Services.Interfaces;
using AutoMapper;

namespace API_Sucursales_Practica.Services
{
    public class ConfiguracionService : IConfiguracionService
    {

        private readonly IConfiguracionRepository _configuracionRepository;
        private readonly IMapper _mapper;

        public ConfiguracionService(IConfiguracionRepository configuracionRepository, IMapper mapper)
        {
            _configuracionRepository=configuracionRepository;
            _mapper=mapper;
        }

        public async Task<BaseResponse<List<ConfiguracionDTO>>> GetConfiguracionesAsync()
        {
            var response = new BaseResponse<List<ConfiguracionDTO>>();


            try
            {
              var configuraciones = await _configuracionRepository.GetAllAsync();
              var configuracionesDtoList = _mapper.Map<List<ConfiguracionDTO>>(configuraciones);
              response.Success=true;
              response.Data = configuracionesDtoList;
              return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<ConfiguracionDTO>>
                {
                    Success=false,
                    Message="Error al obtener las configuraciones: "+ ex.Message,
                    Data=null
                };

                
            }
          
        }
    }
}
