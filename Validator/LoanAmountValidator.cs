using FluentValidation;
using static ADACA.Constants.Validation;

namespace ADACA.Validator
{
    public class LoanAmountValidator<T, TProperty> : BasePropertyValidator<T, decimal>
    {
        public override string Name => "LoanAmountValidator";

        public override bool IsValid(ValidationContext<T> context, decimal value)
        {
            var result = isValid(value);
            SetDecision(value, result);
            return result;
        }

        protected override string ErrorMessage() => "'{PropertyName}' is not valid.";

        private bool isValid(decimal value)
        {
            return value > MIN_LOAN_EXCLUSIVE && value < MAX_LOAN_EXCLUSIVE;
        }
    }
}
