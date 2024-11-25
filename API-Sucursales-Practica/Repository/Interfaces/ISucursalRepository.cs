using API_Sucursales_Practica.Domain;
using API_Sucursales_Practica.DTOs;
using Practica_API_Sucursales.Domain;

namespace API_Sucursales_Practica.Repository.Interfaces
{
    public interface ISucursalRepository
    {
        Task<SucursalEntity> GetSucursalMostRecentNotBuenosAiresAsync();

        Task<SucursalEntity> CreateSucursalAsync(CreateSucursalDTO createDTO);
        Task<SucursalEntity> UpdateSucursalByIdAsync(UpdateSucursalDTO updateDTO);

        Task<IEnumerable<SucursalEntity>> GetAllSucursalAsync();

        Task<IEnumerable<ProvinciaEntity>> GetAllProvinciaAsync();
        
        Task<IEnumerable<TipoEntity>> GetAllTipoAsync();




    }
}
