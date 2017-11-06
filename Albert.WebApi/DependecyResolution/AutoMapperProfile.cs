using AutoMapper;
using AutoMapper.Mappers;

namespace Albert.WebApi.DependencyResolution
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // From Entity To EntityDTO
            AddConditionalObjectMapper()
            .Where((source, dest) =>
            source.Namespace.EndsWith(".Model") &&
            dest.Namespace.EndsWith(".DTO") &&
            source.Name + "DTO" == dest.Name);

            // From EntityDTO To Entity
            AddConditionalObjectMapper()
            .Where((source, dest) =>
            source.Namespace.EndsWith(".DTO") &&
            dest.Namespace.EndsWith(".Model") &&
            dest.Name + "DTO" == source.Name);
        }
    }
}