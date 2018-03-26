using FluentValidation;

namespace CourseProject.Api.Services.Conspect.Models
{
    public class ConspectValidator : AbstractValidator<Data.Model.Conspect>
    {
        public ConspectValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull().Length(1,50);
            RuleFor(x => x.Name).Matches("[^a-zA-Z]");
            RuleFor(x => x.SpecialityNumberId).NotNull().LessThanOrEqualTo(500);
            RuleFor(x => x.Content).NotNull().Matches("[^a-zA-Z0-9]");
            RuleFor(x => x.CreatedDate).NotNull();
            RuleFor(x => x.Active).NotNull();
        }
    }
}
