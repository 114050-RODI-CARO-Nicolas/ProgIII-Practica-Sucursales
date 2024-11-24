using Practica_API_Sucursales.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Sucursales_Practica.DTOs
{
    public class SucursalDTO
    {

        public String Id { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string? IdProvincia { get; set; } //Guid en la Entity
        public string ProvinciaNombre { get; set; }
        public string? IdTipo { get; set; } //Guid en la Entity
        public string TipoNombre { get; set; }
        public string Telefono { get; set; }
        public string NombreTitular { get; set; }
        public string ApellidoTitual { get; set; }

        public DateTime FechaAlta { get; set; }

    }
}
