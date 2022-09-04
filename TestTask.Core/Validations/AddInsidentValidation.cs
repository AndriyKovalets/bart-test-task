using FluentValidation;
using TestTask.Domain.Dtos.IncidentDtos;

namespace TestTask.Core.Validations
{
    public class AddInsidentValidation : AbstractValidator<AddIncidentDto>
    {
        public AddInsidentValidation()
        {
            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(1000);

            RuleFor(x => x.AccountId)
                .NotNull()
                .NotEmpty();
        }
    }
}
