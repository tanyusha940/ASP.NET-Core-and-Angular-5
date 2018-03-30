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
                .NotNull().WithMessage("field Name is required");
            RuleFor(x => x.Name)
                .Length(1, 50).WithMessage("length field Name must not exceed 50 characters");
            RuleFor(x => x.SpecialityNumberId)
                .NotNull().WithMessage("field SpecialityNumberId is required");
            RuleFor(x => x.SpecialityNumberId)
                .LessThanOrEqualTo(500).WithMessage("incorrectly entered the number of the specialty");
            RuleFor(x => x.Content)
                .NotNull().WithMessage("field Content is required");
            RuleFor(x => x.CreatedDate)
                .NotNull();
            RuleFor(x => x.Active)
                .NotNull();
        }
    }
}
