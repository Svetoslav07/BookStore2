using BookStore.Models.Requests;
using FluentValidation;

namespace UniAPI.Validators
{
    public class AddBookValidator : AbstractValidator<AddBookRequest>

    {
        public AddBookValidator()
        {
            RuleFor(x => x.Name.Length)
                   .GreaterThan(4)
                   .WithMessage("Minimum 4 characters")
                   .LessThan(20).WithMessage("Maximux 20 characters");
            RuleFor(x => x.Id)
                   .NotEmpty()
                   .NotNull()
                   .LessThan(5).WithMessage("Maximux 4 characters");


        }
    }
}
 