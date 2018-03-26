using System.Linq;
using CourseProject.Data.Model.Context;
using FluentValidation;

namespace CourseProject.Api.Services.Rating.Models
{
    public class RatingValidator : AbstractValidator<Data.Model.Rating>
    {
        private readonly ApplicationContext context;

        public RatingValidator(ApplicationContext context)
        {
            this.context = context;
            RuleFor(x => x)
                .Must(UserVerification)
                .WithMessage("Custom validation message");
            RuleFor(x => x.Id)
                .NotNull();
            RuleFor(x => x.Mark)
                .LessThanOrEqualTo(5);
            RuleFor(x => x.UserId)
                .NotNull();
            RuleFor(x => x.Active)
                .NotNull();
            RuleFor(x => x.ConspectId)
                .NotNull();
        }

        public bool UserVerification(Data.Model.Rating rating)
        {
            return context.Conspects
                .Where(x => x.UserId == rating.UserId)
                .Any(x => x.Id == rating.ConspectId);
        }
    }
}
