using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwitchPortConfigurator.Api.Dto.Switch.Request;
using SwitchPortConfigurator.Api.Dto.Switch.Response;
using SwitchPortConfigurator.Api.Repository.Entities;
using SwitchPortConfigurator.Api.Repository.Interfaces;
using SwitchPortConfigurator.Api.SwitchService.Exceptions;
using SwitchPortConfigurator.Api.SwitchService.Interfaces;

namespace SwitchPortConfigurator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwitchController : ControllerBase
    {
        private readonly ILogger<SwitchController> _logger;
        private readonly ISwitchRepository _switchRepository;
        private readonly ISwitchService _switchService;
        private readonly IMapper _mapper;

        public SwitchController(ILogger<SwitchController> logger, ISwitchRepository switchRepository, ISwitchService switchService, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _switchRepository = switchRepository ?? throw new ArgumentNullException(nameof(switchRepository));
            _switchService = switchService ?? throw new ArgumentNullException(nameof(switchService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SwitchResponseDto>> GetSwitch([FromRoute]int id, CancellationToken cancellationToken)
        {
            SwitchEntity entity = (await _switchRepository.GetById(id, cancellationToken)) ?? throw new ArgumentException(nameof(id), "Not exist switch with this Id.");

            SwitchResponseDto switchResponseDto = _mapper.Map<SwitchResponseDto>(entity);

            try
            {
                return Ok(_mapper.Map(await _switchService.GetSwitch(entity.Ip, cancellationToken), switchResponseDto));
            }
            catch(SwitchServiceException)
            {
                return switchResponseDto;
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SwitchSummaryResponseDto>>> GetSwitches(CancellationToken cancellationToken)
        {
            var result = await Task.WhenAll((await _switchRepository.GetAll(cancellationToken))
                .Select(async entity =>
                {
                    SwitchSummaryResponseDto @switch = _mapper.Map<SwitchSummaryResponseDto>(entity);

                    try
                    {
                        return _mapper.Map(await _switchService.GetSwitchSummary(entity.Ip, cancellationToken), @switch);
                    }
                    catch (SwitchServiceException)
                    {
                        return @switch;
                    }
                }));

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddSwitch([FromBody]SwitchRequestAddDto @switch, CancellationToken cancellationToken)
        {
            int id = await _switchRepository.Add(_mapper.Map<SwitchEntity>(@switch), cancellationToken);

            return CreatedAtAction("GetSwitch", new { id }, id);
        }

        
    }
}
