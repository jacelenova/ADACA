using static ADACA.Constants.Decision;

namespace ADACA.Models
{
    public class ApplicantResult
    {
        public string Decision { get; set; } = string.Empty;
        public List<ValidationResult> ValidationResult { get; set; }  = new List<ValidationResult>();

        public ApplicantResult(FluentValidation.Results.ValidationResult result)
        {
            var unqualified = false;
            foreach (var error in result.Errors)
            {
                var msg = error.ErrorMessage.Split('|');
                var res = new ValidationResult()
                {
                    Rule = error.ErrorCode,
                    Message = msg[0],
                    Decision = msg[1]
                };
                ValidationResult.Add(res);

                if (msg[1] == UNQUALIFIED) unqualified = true;
            }

            if (result.Errors.Count == 0)
            {
                Decision = QUALIFIED;
            }
            else if (unqualified)
            {
                Decision = UNQUALIFIED;
            }
            else
            {
                Decision = UNKNOWN;
            }
        }

        public ApplicantResult() { }
    }

    public class ValidationResult
    {
        public string Rule { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Decision { get; set; } = string.Empty;
    }
}
