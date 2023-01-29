using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwitchPortConfigurator.Api.Dto.Area.Request;
using SwitchPortConfigurator.Api.Dto.Area.Response;
using SwitchPortConfigurator.Api.Repository.Entities;
using SwitchPortConfigurator.Api.Repository.Interfaces;

namespace SwitchPortConfigurator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly ILogger<AreaController> _logger;
        private readonly IAreaRepository _areaRepository;
        private readonly IMapper _mapper;

        public AreaController(ILogger<AreaController> logger, IAreaRepository areaRepository, IMapper mapper) 
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _areaRepository = areaRepository ?? throw new ArgumentNullException(nameof(areaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost()]
        public async Task<ActionResult<AreaResponseDto>> CreateArea(CreateAreaRequestDto createArea, CancellationToken cancellationToken) =>
            Ok(_mapper.Map<AreaEntity, AreaResponseDto>
                (await _areaRepository.Create(_mapper.Map<CreateAreaRequestDto, AreaEntity>(createArea), 
                    cancellationToken)));
    }
}
