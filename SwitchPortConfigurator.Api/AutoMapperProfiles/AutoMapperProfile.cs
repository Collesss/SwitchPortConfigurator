using AutoMapper;
using SwitchPortConfigurator.Api.Dto.Port.Request;
using SwitchPortConfigurator.Api.Dto.Switch.Request;
using SwitchPortConfigurator.Api.Dto.Switch.Response;
using SwitchPortConfigurator.Api.Repository.Entities;
using SwitchPortConfigurator.Api.SwitchService.Data;

namespace SwitchPortConfigurator.Api.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<SwitchEntity, SwitchResponseDto>();
            CreateMap<SwitchEntity, SwitchSummaryResponseDto>();

            CreateMap<SwitchSummary, SwitchSummaryResponseDto>()
                .ForMember(ssrd => ssrd.Online, opts => opts.MapFrom(_ => true));

            CreateMap<Switch, SwitchResponseDto>()
                .ForMember(srd => srd.Online, opts => opts.MapFrom(_ => true));

            CreateMap<SwitchRequestAddDto, SwitchEntity>();

            CreateMap<PortAccessRequestDto, PortSetting>()
                .ForMember(ps => ps.Access, opts => opts.MapFrom(_ => true))
                .ForMember(ps => ps.Vlans, opts => opts.MapFrom(vr => new List<int>() { vr.Vlan }));


            CreateMap<PortTrunkRequestDto, PortSetting>();

            CreateMap<SwitchEntity, PortSetting>()
                .ForMember(ps => ps.SwitchIp, opts => opts.MapFrom(vr => vr.Ip));
        }
    }
}
