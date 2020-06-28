using FluentValidation;
using Posts.Application.Commands;

namespace Posts.Application.Validators
{
    public class CreatePostValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostValidator()
        {
            RuleFor(p => p.Text)
                .Length(1, 300);
        }
    }
}