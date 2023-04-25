using FluentValidation;

namespace ADACA.Validator
{
    public class AustralianNumberValidator<T, TProperty> : BasePropertyValidator<T, string> 
    {
        public override string Name => "AustralianNumberValidator";

        public override bool IsValid(ValidationContext<T> context, string value)
        {
            if (string.IsNullOrEmpty(value)) return true;

            return isAusMobileValidation(value) || isAusLandlineValidation(value);
        }

        private bool isAusMobileValidation(string number)
        {
            var result = false;
            var preAllowed = new List<string>() { "04", "+614" };
            if (number.StartsWith("04"))
            {
                result = number.Count() == 10;
            }
            else if (number.StartsWith("+614"))
            {
                result = number.Count() == 12;
            }
            return result;
        }

        private bool isAusLandlineValidation(string number)
        {
            var result = false;
            var preAllowed = new List<string>() { "02", "03", "07", "08" };
            var pre = number.Take(2).ToString();
            if (!string.IsNullOrEmpty(pre) && preAllowed.Contains(pre))
            {
                result = number.Count() == 10;
            }

            return result;
        }
    }
}
