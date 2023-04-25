using FluentValidation;
using static ADACA.Constants.Decision;

namespace ADACA.Validator
{
    public class IndustryValidator<T, TProperty> : BasePropertyValidator<T, string>
    {
        public readonly string[] allowed = { "AllowedIndustry1", "AllowedIndustry2" };
        public readonly string[] banned = { "BannedIndustry1", "BannedIndustry2" };

        public override string Name => "IndustryValidator";

        public override bool IsValid(ValidationContext<T> context, string value)
        {
            var result = isValid(value);
            SetDecision(value, result);
            return result;
        }

        private bool isValid(string value)
        {
            var result = false;
            if (allowed.Contains(value))
            {
                Decision = QUALIFIED;
                result = true;
            }
            else if (banned.Contains(value))
            {
                Decision = UNQUALIFIED;
                result = false;
            }

            Decision = UNKNOWN;
            return result;
        }
    }
}
