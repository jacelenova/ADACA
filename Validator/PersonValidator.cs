using ADACA.Models;
using FluentValidation;

namespace ADACA.Validator
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            // must have either firstname or lastname
            RuleFor(x => x).SetValidator(new NameValidator<Person, Person>());

            // must have email or phone
            RuleFor(x => x).SetValidator(new EmailPhoneValidator<Person, Person>());
            RuleFor(x => x.EmailAddress).SetValidator(new EmailValidator<Person, string>());
            RuleFor(x => x.PhoneNumber).SetValidator(new AustralianNumberValidator<Person, string>());

            // must be called asyncronously, from test requirements
            RuleFor(x => x.BusinessNumber).SetAsyncValidator(new BusinessNumberValidator<Person, string>());

            RuleFor(x => x.LoanAmount).SetValidator(new LoanAmountValidator<Person, decimal>());

            RuleFor(x => x.CitizenshipStatus).SetValidator(new CitizenshipStatusValidator<Person, string>());

            RuleFor(x => x.TimeTrading).SetValidator(new TimeTradingValidator<Person, string>());

            RuleFor(x => x.CountryCode).SetValidator(new CountryCodeValidator<Person, string>());

            RuleFor(x => x.Industry).SetValidator(new IndustryValidator<Person, string>());
        }
    }
}
