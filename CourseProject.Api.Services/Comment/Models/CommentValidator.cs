using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace CourseProject.Api.Services.Comment.Models
{
    class CommentValidator : AbstractValidator<Data.Model.Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Text).NotNull().Matches("[^a-zA-Z0-9]");
            RuleFor(x => x.CreatedDate).NotNull();
            RuleFor(x => x.Active).NotNull();
            RuleFor(x => x.ConspectId).NotNull();
        }
    }
}
