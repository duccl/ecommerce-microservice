using FluentValidation.Results;

namespace Microservices.Ordering.Application.Exceptions
{
    public class ValidationException: ApplicationException
    {
        public IDictionary<string,string[]> Errors { get; set; } = new Dictionary<string,string[]>();

        public ValidationException(): base("One or more validations failed!"){}
        public ValidationException(IEnumerable<ValidationFailure> validationFailures): this()
        {
            Errors = validationFailures
                        .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                        .ToDictionary(group => group.Key, group => group.ToArray());
        }
    }
}
