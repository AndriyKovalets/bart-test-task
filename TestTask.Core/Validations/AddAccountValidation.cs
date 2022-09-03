using FluentValidation;
using TestTask.Domain.Dtos.AccountDtos;

namespace TestTask.Core.Validations
{
    public class AddAccountValidation : AbstractValidator<AddAccountDto>
    {
        public AddAccountValidation()
        {
            RuleFor(x => x.Name)
                .MinimumLength(2)
                .MaximumLength(50)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.ContactId)
               .NotNull()
               .NotEmpty();
        }
    }
}
