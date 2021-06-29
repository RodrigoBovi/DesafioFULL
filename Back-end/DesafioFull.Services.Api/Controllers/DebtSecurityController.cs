using DesafioFull.Application.Services;
using DesafioFull.Application.ViewModels.DebtSecurity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DesafioFull.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtSecurityController : ControllerBase
    {
        private readonly ILogger<DebtSecurityController> _logger;
        private readonly DebtSecurityService _debtSecurityService;

        public DebtSecurityController(
            ILogger<DebtSecurityController> logger,
            DebtSecurityService debtSecurityService
            )
        {
            _logger = logger;
            _debtSecurityService = debtSecurityService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="debtSecurityViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateDebtSecurity")]
        public async Task<IActionResult> CreateDebtSecurity([FromBody] DebtSecurityViewModel debtSecurityViewModel)
        {
            try
            {
                DebtSecurityResponseViewModel debtSecurityResponse = await _debtSecurityService.CreateDebtSecurity(debtSecurityViewModel);
                return Ok(debtSecurityResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
