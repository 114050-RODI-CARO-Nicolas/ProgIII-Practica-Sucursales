namespace Practica_API_Sucursales.Domain
{
    public class TipoEntity
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } 

        public virtual ICollection<SucursalEntity> SucursalEntities { get; set; }

        public TipoEntity() {
            SucursalEntities = new HashSet<SucursalEntity>();
        } 


    }
}
