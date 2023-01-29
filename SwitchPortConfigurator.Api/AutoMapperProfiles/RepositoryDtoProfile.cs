using AutoMapper;
using SwitchPortConfigurator.Api.Dto.Area.Request;
using SwitchPortConfigurator.Api.Dto.Area.Response;
using SwitchPortConfigurator.Api.Dto.Location.Request;
using SwitchPortConfigurator.Api.Dto.Location.Response;
using SwitchPortConfigurator.Api.Dto.Manufacturer.Request;
using SwitchPortConfigurator.Api.Dto.Manufacturer.Response;
using SwitchPortConfigurator.Api.Dto.Model.Request;
using SwitchPortConfigurator.Api.Dto.Model.Response;
using SwitchPortConfigurator.Api.Dto.Switch.Request;
using SwitchPortConfigurator.Api.Dto.Switch.Response;
using SwitchPortConfigurator.Api.Repository.Entities;

namespace SwitchPortConfigurator.Api.AutoMapperProfiles
{
    public class RepositoryDtoProfile : Profile
    {
        public RepositoryDtoProfile() 
        {
            CreateMap<CreateAreaRequestDto, AreaEntity>();
            CreateMap<AreaEntity, AreaResponseDto>();

            CreateMap<CreateLocationRequestDto, LocationEntity>();
            CreateMap<LocationEntity, LocationResponseDto>();

            CreateMap<CreateManufacturerRequestDto, ManufacturerEntity>();
            CreateMap<ManufacturerEntity, ManufacturerResponseDto>();

            CreateMap<CreateModelRequestDto, ModelEntity>();
            CreateMap<ModelEntity, ModelResponseDto>();

            CreateMap<CreateSwitchRequestDto, SwitchEntity>();
            CreateMap<SwitchEntity, SwitchResponseDto>();
        }
    }
}
