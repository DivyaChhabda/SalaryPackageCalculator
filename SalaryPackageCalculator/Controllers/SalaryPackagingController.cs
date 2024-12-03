using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalaryPackagingCalculator.Models;
using SalaryPackagingCalculator.Services;

namespace SalaryPackagingCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryPackagingController : ControllerBase
    {
        private readonly SalaryPackagingCalculator.Services.SalaryPackagingCalculator _calculator;

        public SalaryPackagingController()
        {
            _calculator = new SalaryPackagingCalculator.Services.SalaryPackagingCalculator();
        }

        [HttpPost]
        public IActionResult CalculateLimit([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest("Invalid input data");

            var result = _calculator.CalculateSalaryPackagingLimit(employee);
            return Ok(new { Limit = result });
        }
    }

}
