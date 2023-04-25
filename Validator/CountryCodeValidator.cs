using FluentValidation;

namespace ADACA.Validator
{
    public class CountryCodeValidator<T, TProperty> : BasePropertyValidator<T, string>
    {
        public override string Name => "CountryCodeValidator";

        public override bool IsValid(ValidationContext<T> context, string value)
        {
            var result = isValid(value);
            SetDecision(value, result);
            return result;
        }

        private bool isValid(string value)
        {
            return value == "AU";
        }
    }
}
