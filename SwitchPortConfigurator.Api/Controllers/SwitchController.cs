using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SwitchPortConfigurator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwitchController : ControllerBase
    {
        private readonly ILogger<SwitchController> _logger;

        public SwitchController(ILogger<SwitchController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
