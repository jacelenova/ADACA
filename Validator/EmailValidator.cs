using FluentValidation;

namespace ADACA.Validator
{
    public class EmailValidator<T, TProperty> : BasePropertyValidator<T, string>
    {
        public override string Name => "EmailValidator";

        public override bool IsValid(ValidationContext<T> context, string value)
        {
            var result = isValid(value);
            SetDecision(value, result);
            return result;
        }

        protected override string ErrorMessage() => "'{PropertyName}' is not valid.";

        private bool isValid(string value)
        {
            if (string.IsNullOrEmpty(value)) return true;

            int index = value.IndexOf('@');
            return
                index > 0 &&
                index != value.Length - 1 &&
                index == value.LastIndexOf('@');
        }
    }
}
