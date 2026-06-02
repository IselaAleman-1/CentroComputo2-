using AutoMapper;
using Ein.DTOS;
using EIN.Entidades;

namespace CentroComputo2.Data.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<GeneracionSetDTO, GeneracionEntity>()
                 .ForMember(campo => campo.EstaActivo, asignar => asignar.MapFrom(valor => true));

            CreateMap<GeneracionEntity, GeneracionGetDTO>();

            CreateMap<GrupoSetDto, GrupoEntity> ()
                .ForMember(campo => campo.EstaActivo, asignar => asignar.MapFrom(valor => true));

            CreateMap<GrupoEntity, GeneracionGetDTO>()
                .ForMember(campo => campo.NombreGeneracion, asignar => asignar.MapFrom(valor => valor.Generacion.Nombre));
        }

    }
}