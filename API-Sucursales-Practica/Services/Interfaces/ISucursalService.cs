using API_Sucursales_Practica.DTOs;
using API_Sucursales_Practica.Repository.Interfaces;

namespace API_Sucursales_Practica.Services.Interfaces
{
    public interface ISucursalService 
    {

        Task<BaseResponse<SucursalDTO>> GetSucursalMostRecentNotBuenosAiresAsync();

        Task<BaseResponse<SucursalDTO>> UpdateSucursalAsync(UpdateSucursalDTO updateDTO);

        Task<BaseResponse<SucursalDTO>> CreateSucursalAsync(CreateSucursalDTO createDTO);


    }
}
