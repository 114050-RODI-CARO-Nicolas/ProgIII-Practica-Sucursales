using API_Sucursales_Practica.Domain;

namespace API_Sucursales_Practica.Repository.Interfaces
{
    public interface IConfiguracionRepository
    {
        Task<IEnumerable<ConfiguracionEntity>> GetAllAsync();
    }
}
