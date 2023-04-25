using System.Security.Principal;

namespace ADACA.Models
{
    public class Person
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string BusinessNumber { get; set; } = string.Empty;
        public decimal LoanAmount { get; set; }
        public string CitizenshipStatus { get; set; } = string.Empty;
        public string TimeTrading { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
    }
}
