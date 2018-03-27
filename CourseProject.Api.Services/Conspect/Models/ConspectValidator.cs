using FluentValidation;

namespace CourseProject.Api.Services.Conspect.Models
{
    public class ConspectValidator : AbstractValidator<Data.Model.Conspect>
    {
        public ConspectValidator()
        {
            RuleFor(x => x.Id)
                .NotNull();
            RuleFor(x => x.Name)
                .NotNull();
            RuleFor(x => x.Name)
                .Length(1, 50).WithMessage("don't like length");
            RuleFor(x => x.SpecialityNumberId)
                .NotNull();
            RuleFor(x => x.SpecialityNumberId)
                .LessThanOrEqualTo(500);
            RuleFor(x => x.Content)
                .NotNull();
            RuleFor(x => x.CreatedDate)
                .NotNull();
            RuleFor(x => x.Active)
                .NotNull();
        }
    }
}
