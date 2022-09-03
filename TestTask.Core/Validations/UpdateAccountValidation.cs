using FluentValidation;
using TestTask.Domain.Dtos.AccountDtos;

namespace TestTask.Core.Validations
{
    public class UpdateAccountValidation : AbstractValidator<UpdateAccountDto>
    {
        public UpdateAccountValidation()
        {
            RuleFor(x => x.Name)
               .MinimumLength(2)
               .MaximumLength(50);
        }
    }
}
