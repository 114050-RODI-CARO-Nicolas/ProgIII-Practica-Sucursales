using API_Sucursales_Practica.DTOs;
using API_Sucursales_Practica.Repository.Interfaces;
using API_Sucursales_Practica.Services.Interfaces;
using AutoMapper;

namespace API_Sucursales_Practica.Services
{
    public class SucursalService : ISucursalService
    {
        private readonly ISucursalRepository _sucursalRepository;
        private readonly IMapper _mapper;

        public SucursalService(ISucursalRepository sucursalRepository, IMapper mapper)
        {
           


            this._sucursalRepository=sucursalRepository;
            this._mapper = mapper;
        }

    
        public async Task<BaseResponse<SucursalDTO>> GetSucursalMostRecentNotBuenosAiresAsync()
        {
            var response = new BaseResponse<SucursalDTO>();
            try
            {
                var sucursal = await _sucursalRepository.GetSucursalMostRecentNotBuenosAiresAsync();
                if( sucursal == null)
                {
                    response.Success = false;
                    response.Data = null;
                    response.Message = "No se encontró una sucursal con el criterio solicitado";
                    return response;
                }
                response.Success = true;
                response.Data = _mapper.Map<SucursalDTO>(sucursal);
                return response;

            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Data = null;
                response.Message = "Error obteniendo o mapeando la sucursal: " + ex.Message;
                return response;
            }
         
        }

        public async Task<BaseResponse<SucursalDTO>> UpdateSucursalAsync(UpdateSucursalDTO updateDTO)
        {
            var response = new BaseResponse<SucursalDTO>();

            try
            {
                var updatedSucursal = await _sucursalRepository.UpdateSucursalByIdAsync(updateDTO);
                if(updatedSucursal == null)
                {
                    response.Success = false;
                    response.Data = null;
                    response.Message = "La sucursal a actualizar no fue encontrada por ID";
                    return response;
                }

                response.Data = _mapper.Map<SucursalDTO>(updatedSucursal);
                response.Success = true;
                return response;

            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Data = null;
                response.Message = "Error actualizando o mapeando la sucursal: " + ex.Message;
                return response;
            }
        }


        public async Task<BaseResponse<SucursalDTO>> CreateSucursalAsync(CreateSucursalDTO createDTO)
        {
            var response = new BaseResponse<SucursalDTO>();
            try
            {
                if(createDTO == null)
                {
                    response.Success = false;
                    response.Data = null;
                    response.Message = "Los datos de la sucursal no pueden ser nulos";
                    return response;
                }
                var createdSucursal = await _sucursalRepository.CreateSucursalAsync(createDTO);
                if(createdSucursal == null)
                {
                    response.Success = false;
                    response.Message = "Error al crear la sucursal";
                    return response;
                }
                response.Data = _mapper.Map<SucursalDTO>(createdSucursal);
                response.Success = true;
                return response;

            }
            catch (Exception ex)
            {

                response.Success=false;
                response.Message = "Error al crear la sucursal: " + ex.Message;
                return response;
            }

        }

    }
}
