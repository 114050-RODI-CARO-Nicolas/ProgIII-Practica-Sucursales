namespace API_Sucursales_Practica.DTOs
{
    public class UpdateSucursalDTO
    {
        public string Id { get; set; }
        public string? Nombre { get; set; }
        public string? Ciudad { get; set; }
        public string? IdProvincia { get; set; } //Guid en la Entity
        public string? IdTipo { get; set; } //Guid en la Entity
        public string? Telefono { get; set; }
        public string? NombreTitular { get; set; }
        public string? ApellidoTitular { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
