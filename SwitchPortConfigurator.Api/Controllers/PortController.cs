using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwitchPortConfigurator.Api.Dto.Port.Request;
using SwitchPortConfigurator.Api.Repository.Entities;
using SwitchPortConfigurator.Api.Repository.Interfaces;
using SwitchPortConfigurator.Api.SwitchService.Data;
using SwitchPortConfigurator.Api.SwitchService.Interfaces;

namespace SwitchPortConfigurator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortController : ControllerBase
    {
        private readonly ILogger<SwitchController> _logger;
        private readonly ISwitchRepository _switchRepository;
        private readonly ISwitchService _switchService;
        private readonly IMapper _mapper;

        public PortController(ILogger<SwitchController> logger, ISwitchRepository switchRepository, ISwitchService switchService, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _switchRepository = switchRepository ?? throw new ArgumentNullException(nameof(switchRepository));
            _switchService = switchService ?? throw new ArgumentNullException(nameof(switchService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost("access")]
        public async Task<IActionResult> SetAccessPort(PortAccessRequestDto portAccessSetting, CancellationToken cancellationToken)
        {
            SwitchEntity @switch = (await _switchRepository.GetById(portAccessSetting.SwitchId, cancellationToken)) 
                ?? throw new ArgumentException(nameof(portAccessSetting.SwitchId), "Not exist switch with this Id.");

            await _switchService.SetPortSetting(_mapper.Map(portAccessSetting, _mapper.Map<PortSetting>(@switch)), cancellationToken);

            return NoContent();
        }

        [HttpPost("trunk")]
        public async Task<IActionResult> SetTrunkPort(PortTrunkRequestDto portTrunkSetting, CancellationToken cancellationToken)
        {
            SwitchEntity @switch = (await _switchRepository.GetById(portTrunkSetting.SwitchId, cancellationToken))
                ?? throw new ArgumentException(nameof(portTrunkSetting.SwitchId), "Not exist switch with this Id.");

            await _switchService.SetPortSetting(_mapper.Map(portTrunkSetting, _mapper.Map<PortSetting>(@switch)), cancellationToken);

            return NoContent();
        }
    }
}
