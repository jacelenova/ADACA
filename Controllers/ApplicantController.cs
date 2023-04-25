using ADACA.Attributes;
using ADACA.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ADACA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicantController : ControllerBase
    {
        private readonly IValidator<Person> _validator;
        public ApplicantController(IValidator<Person> validator)
        {
            _validator = validator;
        }

        [HttpGet]
        public bool Get()
        {
            return true;
        }

        [HttpPost]
        [CacheResult]
        public async Task<ApplicantResult> Post(Person person)
        {
            var validationResult = await _validator.ValidateAsync(person);
            return new ApplicantResult(validationResult);
        }
    }
}
