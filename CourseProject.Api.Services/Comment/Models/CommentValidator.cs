using FluentValidation;

namespace CourseProject.Api.Services.Comment.Models
{
    public class CommentValidator : AbstractValidator<Data.Model.Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.Id)
                .NotNull();
            RuleFor(x => x.Text)
                .NotNull();
            RuleFor(x => x.CreatedDate)
                .NotNull();
            RuleFor(x => x.Active)
                .NotNull();
            RuleFor(x => x.ConspectId)
                .NotNull();
        }
    }
}
