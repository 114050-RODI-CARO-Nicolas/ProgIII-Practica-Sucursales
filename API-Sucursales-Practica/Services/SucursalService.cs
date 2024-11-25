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

        public async Task<BaseResponse<IEnumerable<ProvinciaDTO>>> GetAllProvinciasAsync()
        {
           var response = new BaseResponse<IEnumerable<ProvinciaDTO>>();
            try
            {
                var provincias = await _sucursalRepository.GetAllProvinciaAsync();
                if (provincias==null)
                {
                    response.Success = false;
                    response.Data = null;
                    response.Message = "Hubo un error al obtener las provincias";
                    return response;
                }
                response.Success = true;
                response.Data = _mapper.Map<List<ProvinciaDTO>>(provincias);
                return response;

            }
            catch (Exception ex)
            {

                response.Success=false;
                response.Data = null;
                response.Message=ex.Message + " " + ex.InnerException;
                return response;
            }
     
        }

        public async Task<BaseResponse<IEnumerable<TipoDTO>>> GetAllTiposAsync()
        {
            var response = new BaseResponse<IEnumerable<TipoDTO>>();
            try
            {
                var tipos = await _sucursalRepository.GetAllTipoAsync();
                if (tipos==null)
                {
                    response.Success = false;
                    response.Data = null;
                    response.Message = "Hubo un error al obtener los tipos";
                    return response;
                }
                response.Success = true;
                response.Data = _mapper.Map<List<TipoDTO>>(tipos);
                return response;

            }
            catch (Exception ex)
            {

                response.Success=false;
                response.Data = null;
                response.Message=ex.Message + " " + ex.InnerException;
                return response;
            }

        }

       

        public async Task<BaseResponse<IEnumerable<SucursalDTO>>> GetAllSucursalesAsync()
        {
           var response = new BaseResponse<IEnumerable<SucursalDTO>>();
            try
            {
                var sucursales = await _sucursalRepository.GetAllSucursalAsync();

                if (sucursales==null)
                {
                    response.Success = false;
                    response.Data = null;
                    response.Message = "Hubo un problema buscando las sucursales";
                    return response;
                }
                response.Success = true;
                response.Data=_mapper.Map<List<SucursalDTO>>(sucursales);
                return response;
         
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Data = null;
                response.Message = "Error obteniendo o mapeando las sucursales : " + ex.InnerException;
                return response;
            }
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
