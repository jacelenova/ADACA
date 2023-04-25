using FluentValidation;

namespace ADACA.Validator
{
    public class CitizenshipStatusValidator<T, TProperty> : BasePropertyValidator<T, string>
    {
        private const string CITIZEN = "Citizen";
        private const string PERMANENT_RESIDENT = "Permanent Resident";
        private readonly string[] citizenStatus = { CITIZEN, PERMANENT_RESIDENT }; 

        public override string Name => "CitizenshipStatusValidator";


        public override bool IsValid(ValidationContext<T> context, string value)
        {
            var result = isValid(value);
            SetDecision(value, result);
            return result;
        }

        protected override string ErrorMessage() => "'{PropertyName}' must be a Citizen or Permanent Resident.";

        private bool isValid(string status)
        {
            return citizenStatus.Contains(status, StringComparer.OrdinalIgnoreCase);
        }
    }
}
