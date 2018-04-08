using FluentValidation;

namespace CourseProject.Api.Services.Rating.Models
{
    public class RatingValidator : AbstractValidator<Data.Model.Rating>
    { 
        public RatingValidator()
        {
            RuleFor(x => x.Id)
                .NotNull();
            RuleFor(x => x.Mark).ExclusiveBetween(1, 5).WithMessage("invalid value range");
            RuleFor(x => x.Active)
                .NotNull();
            RuleFor(x => x.ConspectId)
                .NotNull().WithMessage("field ConspectId is required");
        }
    }
}
