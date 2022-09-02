using FluentValidation;
using TestTask.Domain.Dtos.ContactDtos;

namespace TestTask.Core.Validations
{
    public class AddContactValidation: AbstractValidator<AddContactDto>
    {
        public AddContactValidation()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100)
                .EmailAddress();
        }
    }
}
