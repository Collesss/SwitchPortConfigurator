using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwitchPortConfigurator.Api.Dto.Common.Response;
using SwitchPortConfigurator.Api.Dto.Model.Request;
using SwitchPortConfigurator.Api.Dto.Model.Response;
using SwitchPortConfigurator.Api.Repository.Entities;
using SwitchPortConfigurator.Api.Repository.Interfaces;

namespace SwitchPortConfigurator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly ILogger<ModelController> _logger;
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public ModelController(ILogger<ModelController> logger, IModelRepository modelRepository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _modelRepository = modelRepository ?? throw new ArgumentNullException(nameof(modelRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost()]
        [ProducesResponseType(typeof(ModelResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InternalServerErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ModelResponseDto>> CreateModel(CreateModelRequestDto createModel, CancellationToken cancellationToken) =>
            Ok(_mapper.Map<ModelEntity, ModelResponseDto>
                (await _modelRepository.Create(_mapper.Map<CreateModelRequestDto, ModelEntity>(createModel),
                    cancellationToken)));

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ModelResponseDto>>> GetAllModels(CancellationToken cancellationToken) =>
            Ok(_mapper.Map<IEnumerable<ModelEntity>, IEnumerable<ModelResponseDto>>(await _modelRepository.GetAll(cancellationToken)));
    }
}
