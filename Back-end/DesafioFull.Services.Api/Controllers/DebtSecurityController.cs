using DesafioFull.Application.Services;
using DesafioFull.Application.ViewModels.DebtSecurity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioFull.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtSecurityController : ControllerBase
    {
        private readonly ILogger<DebtSecurityController> _logger;
        private readonly DebtSecurityService _debtSecurityService;
        private readonly DebtInstallmentService _debtInstallmentService;

        public DebtSecurityController(
            ILogger<DebtSecurityController> logger,
            DebtSecurityService debtSecurityService,
            DebtInstallmentService debtInstallmentService
            )
        {
            _logger = logger;
            _debtSecurityService = debtSecurityService;
            _debtInstallmentService = debtInstallmentService;
        }

        /// <summary>
        /// Return DebtSecurities of user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUserDebtSecurities")]
        public async Task<IActionResult> GetUserDebtSecurities(int userId)
        {
            try
            {
                List<DebtSecurityResponseViewModel> debtSecurityResponse = await _debtSecurityService.GetUserDebtSecurities(userId);
                return Ok(debtSecurityResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Create DebtSecurity at Database
        /// </summary>
        /// <param name="debtSecurityViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateDebtSecurity")]
        public async Task<IActionResult> CreateDebtSecurity([FromBody] DebtSecurityViewModel debtSecurityViewModel)
        {
            try
            {
                List<DebtSecurityResponseViewModel> debtSecurityResponse = await _debtSecurityService.CreateDebtSecurity(debtSecurityViewModel);
                return Ok(debtSecurityResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
