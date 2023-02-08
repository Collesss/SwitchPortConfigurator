using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwitchPortConfigurator.Api.Dto.Common.Response;
using SwitchPortConfigurator.Api.Dto.Location.Request;
using SwitchPortConfigurator.Api.Dto.Location.Response;
using SwitchPortConfigurator.Api.Repository.Entities;
using SwitchPortConfigurator.Api.Repository.Interfaces;

namespace SwitchPortConfigurator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<LocationController> _logger;
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationController(ILogger<LocationController> logger, ILocationRepository locationRepository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _locationRepository = locationRepository ?? throw new ArgumentNullException(nameof(locationRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost()]
        [ProducesResponseType(typeof(LocationResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InternalServerErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LocationResponseDto>> LocationArea(CreateLocationRequestDto createLocation, CancellationToken cancellationToken) =>
            Ok(_mapper.Map<LocationEntity, LocationResponseDto>
                (await _locationRepository.Create(_mapper.Map<CreateLocationRequestDto, LocationEntity>(createLocation),
                    cancellationToken)));

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<LocationResponseDto>>> GetAllLocations(CancellationToken cancellationToken) =>
            Ok(_mapper.Map<IEnumerable<LocationEntity>, IEnumerable<LocationResponseDto>>(await _locationRepository.GetAll(cancellationToken)));
    }
}
