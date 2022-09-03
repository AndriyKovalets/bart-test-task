using FluentValidation;
using TestTask.Domain.Dtos.ContactDtos;

namespace TestTask.Core.Validations
{
    public class UpdateContactValidation : AbstractValidator<UpdateContactDto>
    {
        public UpdateContactValidation()
        {
            RuleFor(x => x.FirstName)
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(x => x.Email)
                .MinimumLength(2)
                .MaximumLength(100)
                .EmailAddress();
        }
    }
}
