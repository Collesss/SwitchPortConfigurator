using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwitchPortConfigurator.Api.Dto.Common.Response;
using SwitchPortConfigurator.Api.Dto.Switch.Request;
using SwitchPortConfigurator.Api.Dto.Switch.Response;
using SwitchPortConfigurator.Api.Repository.Entities;
using SwitchPortConfigurator.Api.Repository.Interfaces;

namespace SwitchPortConfigurator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwitchController : ControllerBase
    {
        private readonly ILogger<SwitchController> _logger;
        private readonly ISwitchRepository _switchRepository;
        private readonly IMapper _mapper;

        public SwitchController(ILogger<SwitchController> logger, ISwitchRepository switchRepository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _switchRepository = switchRepository ?? throw new ArgumentNullException(nameof(switchRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost()]
        [ProducesResponseType(typeof(SwitchResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InternalServerErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SwitchResponseDto>> CreateSwitch(CreateSwitchRequestDto createSwitch, CancellationToken cancellationToken) =>
            Ok(_mapper.Map<SwitchEntity, SwitchResponseDto>
                (await _switchRepository.Create(_mapper.Map<CreateSwitchRequestDto, SwitchEntity>(createSwitch),
                    cancellationToken)));

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<SwitchResponseDto>>> GetAllSwitches(CancellationToken cancellationToken) =>
            Ok(_mapper.Map<IEnumerable<SwitchEntity>, IEnumerable<SwitchResponseDto>>(await _switchRepository.GetAll(cancellationToken)));
    }
}
