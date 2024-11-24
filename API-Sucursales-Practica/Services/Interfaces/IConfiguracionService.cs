using API_Sucursales_Practica.DTOs;

namespace API_Sucursales_Practica.Services.Interfaces
{
    public interface IConfiguracionService
    {
        Task<BaseResponse<List<ConfiguracionDTO>>> GetConfiguracionesAsync();
    }
}
