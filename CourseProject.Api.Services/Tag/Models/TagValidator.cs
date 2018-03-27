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
                .NotNull();
            RuleFor(x => x.Text)
                .Length(1,15);
        }
    }
}
