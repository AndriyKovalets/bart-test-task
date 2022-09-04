using FluentValidation;
using TestTask.Domain.Dtos.IncidentDtos;

namespace TestTask.Core.Validations
{
    public class AddIncidentFullInfoValidation : AbstractValidator<AddIncidentFullInfoDto>
    {
        public AddIncidentFullInfoValidation()
        {
            RuleFor(x => x.AccountName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(x => x.ContactFirstName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(x => x.ContactLastName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(x => x.ContactEmail)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100)
                .EmailAddress();

            RuleFor(x => x.IncidentDescription)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(1000);
        }
    }
}
