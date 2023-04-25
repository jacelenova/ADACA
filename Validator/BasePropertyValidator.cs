using FluentValidation;
using FluentValidation.Validators;
using static ADACA.Constants.Decision;

namespace ADACA.Validator
{
    public class BasePropertyValidator<T, TProperty> : PropertyValidator<T, TProperty>
    {
        public string Decision { get; set; } = UNKNOWN;

        public override string Name => string.Empty;

        public override bool IsValid(ValidationContext<T> context, TProperty value) => true;

        protected virtual string ErrorMessage() => "'{PropertyName}' is not valid.";

        protected override string GetDefaultMessageTemplate(string errorCode) => $"{ErrorMessage()}|{Decision}";

        public virtual void SetDecision(TProperty value, bool isValid)
        {
            if (value is null || value.Equals(default(TProperty)))
            {
                Decision = UNKNOWN;
            }
            else if (typeof(TProperty) == typeof(string) && string.IsNullOrEmpty(value.ToString()))
            {
                Decision = UNKNOWN;
            }
            else if (isValid)
            {
                Decision = QUALIFIED;
            }
            else
            {
                Decision = UNQUALIFIED;
            }
        }
    }

    public class BasePropertyValidatorAsync<T, TProperty> : AsyncPropertyValidator<T, TProperty>
    {
        public string Decision { get; protected set; } = UNKNOWN;

        protected virtual string ErrorMessage() => "'{PropertyName}' is not valid.";

        public override string Name => string.Empty;

        public override async Task<bool> IsValidAsync(ValidationContext<T> context, TProperty value, CancellationToken token) => await Task.FromResult(true);

        protected override string GetDefaultMessageTemplate(string errorCode) => $"{ErrorMessage()}|{Decision}";

        public virtual void SetDecision(TProperty value, bool isValid)
        {
            if (value is null || value.Equals(default(TProperty)))
            {
                Decision = UNKNOWN;
            }
            else if (typeof(TProperty) == typeof(string) && string.IsNullOrEmpty(value.ToString()))
            {
                Decision = UNKNOWN;
            }
            else if (isValid)
            {
                Decision = QUALIFIED;
            }
            else
            {
                Decision = UNQUALIFIED;
            }
        }
    }
}
