using FluentValidation;

namespace CourseProject.Api.Services.Tag.Models
{
    public class TagValidator : AbstractValidator<Data.Model.Tag>
    {
        public TagValidator()
        {
            RuleFor(x => x.Id)
                .NotNull();
            RuleFor(x => x.Active)
                .NotNull();
            RuleFor(x => x.Text)
                .NotNull().WithMessage("this field is required");
            RuleFor(x => x.Text)
                .Length(1,15).WithMessage("length must not exceed 15 characters");
        }
    }
}
