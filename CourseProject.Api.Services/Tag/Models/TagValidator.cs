using FluentValidation;

namespace CourseProject.Api.Services.Tag.Models
{
    class TagValidator : AbstractValidator<Data.Model.Tag>
    {
        public TagValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Active).NotNull();
            RuleFor(x => x.Text).NotNull().Length(1,15).Matches("[^a-zA-Z]");
        }
    }
}
