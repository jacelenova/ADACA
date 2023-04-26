using FluentValidation;

namespace ADACA.Validator
{
    public class BusinessNumberValidator<T, TProperty> : BasePropertyValidatorAsync<T, string>
    {
        public override string Name => "BusinessNumberValidator";

        public async override Task<bool> IsValidAsync(ValidationContext<T> context, string value, CancellationToken token)
        {

            return await isValidAsync(value);
        }

        private async Task<bool> isValidAsync(string value)
        {
            var result = await isValid(value);
            SetDecision(value, result);
            return result;
        }


        // must be async according to test requirements
        private async Task<bool> isValid(string value)
        {
            await Task.Delay(1000);
            return await Task.FromResult(value.Length == 11);
        }
    }
}
