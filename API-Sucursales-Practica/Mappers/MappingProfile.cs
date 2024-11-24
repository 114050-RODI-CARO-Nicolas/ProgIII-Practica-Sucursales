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
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember !=null
                ));


            CreateMap<ConfiguracionDTO, ConfiguracionDTO>().ReverseMap();















        }
    }
}
