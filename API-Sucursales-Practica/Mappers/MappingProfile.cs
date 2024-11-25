using API_Sucursales_Practica.Domain;
using API_Sucursales_Practica.DTOs;
using AutoMapper;
using Practica_API_Sucursales.Domain;

namespace API_Sucursales_Practica.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<CreateSucursalDTO, SucursalEntity>()
                .ForMember(dest => dest.IdTipo, opt => opt.MapFrom(src =>
                    string.IsNullOrEmpty(src.IdTipo) ? Guid.Empty : Guid.Parse(src.IdTipo)))
                .ForMember(dest => dest.IdProvincia, opt => opt.MapFrom(src =>
                    string.IsNullOrEmpty(src.IdProvincia) ? Guid.Empty : Guid.Parse(src.IdProvincia)
                ));

            CreateMap<SucursalEntity, SucursalDTO>()
                .ForMember(dest=> dest.Id, opt => opt.MapFrom( src =>
                src.Id.ToString()))
                .ForMember(dest => dest.IdTipo, opt=> opt.MapFrom(src => 
                src.IdTipo.ToString()))
                 .ForMember(dest => dest.IdProvincia, opt => opt.MapFrom(src =>
                src.IdProvincia.ToString()))

                .ForMember(dest => dest.TipoNombre, opt => opt.MapFrom(src =>
                src.Tipo != null ? src.Tipo.Nombre : string.Empty))
                .ForMember(dest => dest.ProvinciaNombre, opt => opt.MapFrom(src =>
                src.Provincia != null ? src.Provincia.Nombre : string.Empty
                ));


            CreateMap<UpdateSucursalDTO, SucursalEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src =>
                    Guid.Parse(src.Id)))
                .ForMember(dest => dest.IdTipo, opt => opt.MapFrom((src, dest) =>
                    !string.IsNullOrEmpty(src.IdTipo) ? Guid.Parse(src.IdTipo) : dest.IdTipo
                ))
                .ForMember(dest => dest.IdProvincia, opt => opt.MapFrom((src, dest) =>
                    !string.IsNullOrEmpty(src.IdProvincia) ? Guid.Parse(src.IdProvincia) : dest.IdProvincia
                ))
                .ForMember(dest => dest.FechaAlta, opt => opt.MapFrom((src, dest) =>
                    src.FechaAlta.HasValue ? src.FechaAlta.Value : dest.FechaAlta))
                  .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                        srcMember != null && (!(srcMember is string) || !string.IsNullOrEmpty((string)srcMember))));


            /*
             
            .ForMember(dest => dest.FechaAlta, opt => opt.MapFrom((src, dest) =>
                src.FechaAlta.HasValue ? src.FechaAlta.Value : dest.FechaAlta))

            dest.FechaAlta: el campo de destino en la entidad
            (src, dest) =>: nos da acceso tanto al source (DTO) como al destination (entity)
            src.FechaAlta.HasValue: verifica si el DTO tiene un valor para la fecha (porque ahora es nullable)
            Si tiene valor (?), usa ese valor (src.FechaAlta.Value)
            Si no tiene valor (:), mantiene el valor existente en la entidad (dest.FechaAlta)



  
            
            .ForAllMembers(): Aplica una configuración a todos los miembros del mapeo.
            opts.Condition((src, dest, srcMember) => srcMember != null):

            src: es el objeto fuente (UpdateSucursalDTO)
            dest: es el objeto destino (SucursalEntity)
            srcMember: es el valor específico del miembro que se está mapeando

            La condición srcMember != null significa que solo se realizará el mapeo si el valor en el DTO no es null
            
            
            -La condicion srcMember != null && (!(srcMember is string) || !string.IsNullOrEmpty((string)srcMember))

                    tiene dos partes unidas por AND (&&):

                    srcMember != null: el valor no debe ser null
                    (!(srcMember is string) || !string.IsNullOrEmpty((string)srcMember)):

                    Si NO es string (!(srcMember is string)), la condición es verdadera
                    Si ES string (||), debe NO estar vacío (!string.IsNullOrEmpty)


                    En otras palabras, solo se mapeará un campo si:

                    No es null Y
                    Si es string, no está vacío
                    Si no es string, se mapea normalmente



            */



            CreateMap<ConfiguracionEntity, ConfiguracionDTO>().ReverseMap();















        }
    }
}
