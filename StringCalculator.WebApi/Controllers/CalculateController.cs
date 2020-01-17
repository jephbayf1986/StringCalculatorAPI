using Microsoft.AspNetCore.Mvc;
using StringCalculator.Application;

namespace StringCalculator.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        private readonly ICalculator _calculator;

        public CalculateController(ICalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpGet]
        public string Get()
        {
            return "Include an expression in the body of your POST request such as \"4+5\"";
        }

        [HttpPost]
        public decimal Post([FromBody] string expression)
        {
            return _calculator.Calculate(expression);
        }

    }
}