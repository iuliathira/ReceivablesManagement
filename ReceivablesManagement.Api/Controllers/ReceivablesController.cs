using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ReceivablesManagement.Business.DTOs;
using ReceivablesManagement.Business.Services;

namespace ReceivablesManagement.Api.Controllers
{
    [Route("api/receivables")]
    public class ReceivablesController : Controller
    {
        private readonly IReceivablesServices _receivablesServices;
        private readonly ILogger<ReceivablesController> _logger;
        private readonly IValidator<ReceivableDTO> _validator;

        public ReceivablesController(
            IReceivablesServices receivablesServices,
            ILogger<ReceivablesController> logger,
            IValidator<ReceivableDTO> validator)
        {
            _receivablesServices = receivablesServices;
            _logger = logger;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReceivableDTO>>> GetAllAsync()
        {
            try
            {
                var result = await _receivablesServices.GetAllAsync();
                return Ok(result);

            } catch(Exception ex)
            {
                _logger.LogError("[ReceivablesController] - GetAllAsync error {error}", ex.Message);
                return BadRequest(ex);
            }
        }

        [HttpPost("summary")]
        public async Task<ActionResult<ReceivableSummaryDTO>> GetSummaryAsync([FromBody] ReceivableFilterDTO filter)
        {
            try
            {
                var summary = await _receivablesServices.GetSummaryAsync(filter);

                return Ok(summary);

            }
            catch (Exception ex)
            {
                _logger.LogError("[ReceivablesController] - GetSummaryAsync {error}", ex.Message);
                return BadRequest(ex);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> AddAsync([FromBody] ReceivableDTO receivableDTO)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(receivableDTO);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors);

                var createdReceivableId = await _receivablesServices.AddAsync(receivableDTO);
                return Ok(createdReceivableId);

            } catch(Exception ex)
            {
                _logger.LogError("[ReceivablesController] - AddAsync error: {error} for receivable {data}", ex.Message, receivableDTO);
                return BadRequest(ex);
            } 
        }
    }
}

