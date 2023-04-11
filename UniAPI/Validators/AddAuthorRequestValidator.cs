using BookStore.Models.Requests;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace UniAPI.Validators
{
    public class AddAuthorRequestValidator : AbstractValidator<AddAuthorRequest>
    {
        public AddAuthorRequestValidator()
        {
            RuleFor(x => x.Bio)
                   .NotNull()
                   .NotEmpty().WithMessage("Bio can not be empty!");
            RuleFor(x => x.Bio.Length)
                   .GreaterThan(5)
                   .WithMessage("Minimum 5 characters")
                   .LessThan(10).WithMessage("Maximux 10 characters");


        }
    }
}
