using FluentValidation;
using TestTask.Domain.Dtos.IncidentDtos;

namespace TestTask.Core.Validations
{
    internal class UpdateIncidentValidation : AbstractValidator<UpdateIncidentDto>
    {
        public UpdateIncidentValidation()
        {
            RuleFor(x => x.Description)
                .MinimumLength(2)
                .MaximumLength(1000);
        }
    }
}
