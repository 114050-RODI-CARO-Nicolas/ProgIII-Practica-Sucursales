namespace API_Sucursales_Practica.DTOs
{
    public class CreateSucursalDTO
    {
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string IdProvincia { get; set; } //Guid en la Entity
      
        public string IdTipo { get; set; } //Guid en la Entity
  

        public string Telefono { get; set; }
        public string NombreTitular { get; set; }
        public string ApellidoTitual { get; set; }

        public DateTime FechaAlta { get; set; }
    }
}
