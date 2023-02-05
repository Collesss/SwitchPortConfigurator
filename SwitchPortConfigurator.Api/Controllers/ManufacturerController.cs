using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwitchPortConfigurator.Api.Dto.Manufacturer.Request;
using SwitchPortConfigurator.Api.Dto.Manufacturer.Response;
using SwitchPortConfigurator.Api.Repository.Entities;
using SwitchPortConfigurator.Api.Repository.Interfaces;

namespace SwitchPortConfigurator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly ILogger<ManufacturerController> _logger;
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IMapper _mapper;

        public ManufacturerController(ILogger<ManufacturerController> logger, IManufacturerRepository manufacturerRepository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _manufacturerRepository = manufacturerRepository ?? throw new ArgumentNullException(nameof(manufacturerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost()]
        public async Task<ActionResult<ManufacturerResponseDto>> CreateManufacturer(CreateManufacturerRequestDto createManufacturer, CancellationToken cancellationToken) =>
            Ok(_mapper.Map<ManufacturerEntity, ManufacturerResponseDto>
                (await _manufacturerRepository.Create(_mapper.Map<CreateManufacturerRequestDto, ManufacturerEntity>(createManufacturer),
                    cancellationToken)));
        
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ManufacturerResponseDto>>> GetAllManufacturers(CancellationToken cancellationToken) =>
            Ok(_mapper.Map<IEnumerable<ManufacturerEntity>, IEnumerable<ManufacturerResponseDto>>(await _manufacturerRepository.GetAll(cancellationToken)));
    }
}
