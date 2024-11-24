using System.ComponentModel.DataAnnotations.Schema;

namespace Practica_API_Sucursales.Domain
{
    public class SucursalEntity
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }

        public string Ciudad {  get; set; }
        
        public Guid IdTipo { get; set; }
        [ForeignKey("IdTipo")]
        public TipoEntity Tipo { get; set; }

        public Guid IdProvincia { get; set; }
        [ForeignKey("IdProvincia")]
        public ProvinciaEntity Provincia { get; set; }

        public string Telefono { get; set; }
        public string NombreTitular { get; set; }
        public string ApellidoTitular { get; set; }

        public DateTime FechaAlta { get; set; }


    }
}
