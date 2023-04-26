using FluentValidation;
using static ADACA.Constants.Validation;

namespace ADACA.Validator
{
    public class TimeTradingValidator<T, TProperty> : BasePropertyValidator<T, string>
    {
        public override string Name => "TimeTradingValidator";

        public override bool IsValid(ValidationContext<T> context, string value)
        {
            var result = isValid(value);
            SetDecision(value, result);
            return result;
        }

        private bool isValid(string value)
        {
            if (int.TryParse(value, out var intValue))
            {
                return intValue > MIN_TIME_TRADING_EXCLUSIVE && intValue < MAX_TIME_TRADING_EXCLUSIVE;
            };

            return false;
        }
    }
}
