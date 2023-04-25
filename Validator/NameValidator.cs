using ADACA.Models;
using FluentValidation;
using static ADACA.Constants.Decision;

namespace ADACA.Validator
{
    public class NameValidator<T, TProperty> : BasePropertyValidator<Person, Person>
    {
        public override string Name => "NameValidator";

        public override bool IsValid(ValidationContext<Person> context, Person value)
        {
            var result = isValid(value);
            SetDecision(value, result);
            return result;
        }

        protected override string ErrorMessage() => "FirstName or LastName is required.";

        public override void SetDecision(Person value, bool isValid) => Decision = isValid ? QUALIFIED : UNQUALIFIED;

        private bool isValid(Person person)
        {
            var result = true;
            if (string.IsNullOrEmpty(person.FirstName) && string.IsNullOrEmpty(person.LastName))
            {
                result = false;
            }
            return result;
        }
    }
}
